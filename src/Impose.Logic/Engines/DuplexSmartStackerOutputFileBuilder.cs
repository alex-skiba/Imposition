using System;
using System.Collections.Generic;
using System.Linq;
using Albelli.Impose.DataModel.Extensions;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.DataModel.Output;
using Albelli.Impose.Logic.Engines.Iterator;

// ReSharper disable PossibleNullReferenceException

namespace Albelli.Impose.Logic.Engines
{
    public class DuplexSmartStackerOutputFileBuilder : IOutputFileBuilder
    {
        private readonly Imposition _imposition;
        private readonly Layout _layout;

        /// <summary>
        ///     PrintSurface: duplex
        ///     Source files: first to last
        ///     Source file pages: last to first
        ///     Iterator: YFlipBackSideTileIterator
        /// </summary>
        /// <param name="layout"></param>
        /// <param name="imposition"></param>
        public DuplexSmartStackerOutputFileBuilder(Layout layout, Imposition imposition)
        {
            _layout = layout ?? throw new ArgumentNullException(nameof(layout));
            _imposition = imposition ?? throw new ArgumentNullException(nameof(imposition));
        }

        public OutputFile Build(List<SourceFile> products)
        {
            ValidateProducts(products);

            // impositioning algorithm:
            // - define order of products (direct/reversed)
            // - define order of product pages (direct/reversed)
            // - create iterator (layout size, start point, direction)
            // - define top-up algorithm
            // for each product:
            // store product start position
            // for each next pages pair:
            // - if iterator is in zero point, add new OutputPage (front & back)
            //     - get next tile position (front & back)
            //     - place page to tile of the OutputPage (front & back)
            // - move iterator
            //     store product end position and number of tiles
            // if top-up defined
            // top-up last column (front & back)
            // store number of waste tiles for the product
            // if top-up defined
            // top-up last OutputPage (front & back)
            // add number of waste tiles to the waste of the last product

            // todo: take imposition setting into account to choose an iterator
            var iterator = new YFlipBackSideTileIterator(_layout.RowsCount, _layout.ColumnsCount) as IDuplexTileIterator;
            var wasteCountPerProduct = new Dictionary<SourceFile, int>();
            var outputPages = new List<OutputPage>();
            OutputPage frontOutputPage = null;
            OutputPage backOutputPage = null;

            // direct order of products
            foreach (var product in products)
            {
                wasteCountPerProduct[product] = 0;
                // reversed order of product pages todo: strategy
                for (var frontSourcePageIndex = product.Pages.Count - 2; frontSourcePageIndex >= 0; frontSourcePageIndex -= 2)
                {
                    var frontSourcePage = product.Pages[frontSourcePageIndex];
                    var backSourcePage = product.Pages[frontSourcePageIndex + 1];

                    if (iterator.IsInitial)
                    {
                        frontOutputPage = new OutputPage {Tiles = new OutputTileSet(_layout.RowsCount, _layout.ColumnsCount)};
                        backOutputPage = new OutputPage {Tiles = new OutputTileSet(_layout.RowsCount, _layout.ColumnsCount)};
                        outputPages.Add(frontOutputPage);
                        outputPages.Add(backOutputPage);
                    }

                    var frontLayoutTile = _layout.Tiles.At(iterator.CurrentFrontPosition);
                    var frontTile = frontOutputPage.Tiles[iterator.CurrentFrontPosition];
                    frontTile.MediaBox = frontLayoutTile.MediaBox;
                    frontTile.CutBox = frontLayoutTile.CutBox;
                    frontTile.MediaRotationAngle = _imposition.MediaRotationAngle;
                    frontTile.SourceFilePath = product.FileName;
                    frontTile.SourcePageNumber = frontSourcePage.Number;

                    var backLayoutTile = _layout.Tiles.At(iterator.CurrentBackPosition);
                    var backTile = backOutputPage.Tiles[iterator.CurrentBackPosition];
                    backTile.MediaBox = backLayoutTile.MediaBox;
                    backTile.CutBox = backLayoutTile.CutBox;
                    backTile.MediaRotationAngle = _imposition.MediaRotationAngle;
                    backTile.SourceFilePath = product.FileName;
                    backTile.SourcePageNumber = backSourcePage.Number;

                    iterator.MoveForward();
                }

                // add waste to fill current column
                while (iterator.CurrentFrontPosition.RowIndex != iterator.InitialFrontPosition.RowIndex)
                {
                    var frontTile = frontOutputPage.Tiles[iterator.CurrentFrontPosition];
                    frontTile.SourceFilePath = product.FileName;
                    frontTile.SourcePageNumber = 0;

                    var backTile = backOutputPage.Tiles[iterator.CurrentBackPosition];
                    backTile.SourceFilePath = product.FileName;
                    backTile.SourcePageNumber = 0;

                    iterator.MoveForward();
                }
            }

            // add waste to fill current page
            while (iterator.CurrentFrontPosition.ColumnIndex != iterator.InitialFrontPosition.ColumnIndex)
            {
                var product = products.Last();

                var frontTile = frontOutputPage.Tiles[iterator.CurrentFrontPosition];
                frontTile.SourceFilePath = product.FileName;
                frontTile.SourcePageNumber = 0;

                var backTile = backOutputPage.Tiles[iterator.CurrentBackPosition];
                backTile.SourceFilePath = product.FileName;
                backTile.SourcePageNumber = 0;

                iterator.MoveForward();
            }

            return new OutputFile
            {
                SheetSize = _layout.SheetSize,
                Pages = outputPages,
                IsDuplex = true
            };
        }

        private static void ValidateProducts(List<SourceFile> products)
        {
            if (products.Count == 0)
            {
                throw new ArgumentException("You must specify at least one product to be impositioned", nameof(products));
            }

            if (products.Any(p => p.Pages?.Count == 0))
            {
                throw new ArgumentException("One of the specified products contains no pages");
            }

            if (products.Any(p => p.Pages.Count.IsOdd()))
            {
                throw new ArgumentException("One of the specified duplex products contains an odd number of pages");
            }
        }
    }
}