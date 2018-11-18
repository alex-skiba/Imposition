using System.Collections.Generic;
using Albumprinter.Plant.Xpresso.Xjf.XjfXml;
using Imposition.Model;
using Layout = Imposition.Model.Layout;

namespace Imposition.LayoutGeneration
{
    public static class Pap720Generator
    {
        public static Layout BuildPap720(int papCode, XpressoModel xjf)
        {
            var separator = new[] {' '};
            // todo: check if we can always assume Points as size units
            var sheetWidthPoints = float.Parse(xjf.Jobs[0].Layout[0].Size.Split(separator)[0]);
            var sheetHeightPoints = float.Parse(xjf.Jobs[0].Layout[0].Size.Split(separator)[1]);
            var layout = new Layout
            {
                PapCode = papCode,
                SheetHeight = sheetHeightPoints,
                SheetWidth = sheetWidthPoints,
                Tiles = GenerateTiles()
            };
            return layout;
        }

        private static List<Tile> GenerateTiles()
        {
            var tiles = new List<Tile>();
            var tileWidth = 694.4882f;
            var tileHeight = 334.4881f;

            // one sheet has 3 mug prints
            for (var tileIndex = 0; tileIndex < 3; tileIndex++)
            {
                tiles.Add(new Tile
                {
                    Box = new Box
                    {
                        Left = 0,
                        Bottom = tileHeight * tileIndex,
                        Width = tileWidth,
                        Height = tileHeight
                    },
                    MediaBox = new Box
                    {
                        Left = 0,
                        Bottom = 0,
                        Width = tileWidth,
                        Height = tileHeight
                    },
                    CutBox = new Box
                    {
                        Left = 20,
                        Bottom = 20,
                        Width = tileWidth - 40,
                        Height = tileHeight - 40
                    },
                    Elements = GenerateTileElements()
                });
            }

            return tiles;
        }

        private static List<Element> GenerateTileElements()
        {
            var elements = new List<Element>
            {
                new Element
                {
                    Type = ElementType.Barcode,
                    Key = "ticketbarcode",
                    Box = new Box
                    {
                        Left = 190,
                        Bottom = 316,
                        Width = 120,
                        Height = 28.3464012f
                    }
                },
                new Element
                {
                    Type = ElementType.Barcode,
                    Key = "ticketbarcode",
                    Box = new Box
                    {
                        Left = 480,
                        Bottom = 316,
                        Width = 120,
                        Height = 28.3464012f
                    }
                },
                new Element
                {
                    Type = ElementType.Text,
                    Key = "ticketbarcodeplaintext",
                    Box = new Box
                    {
                        Left = 250,
                        Bottom = 323,
                        Width = 120,
                        Height = 28.3464012f
                    }
                },
                new Element
                {
                    Type = ElementType.CutMark,
                    Key = "cutmarks"
                }
            };

            return elements;
        }
    }
}