using System;
using System.Collections.Generic;
using Albelli.Impose.DataModel.Common;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.DataModel.Output;
using Albelli.Impose.Logic.Tests.Extensions;
using Albelli.Impose.Logic.Validation;
using NUnit.Framework;
using Shouldly;

namespace Albelli.Impose.Logic.Tests.Validation
{
    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void Validate_ShouldNotThrowWhenLayoutHasIdenticalTiles()
        {
            var layout = new Layout
            {
                Tiles = new List<Tile>
                {
                    GetDefaultTile(),
                    GetDefaultTile()
                }
            };

            var target = new Validator();

            target.ValidateLayout(layout);
        }

        [Test]
        public void Validate_ShouldNotThrowWhenSourcePageCropBoxSizeMatchLayoutCutBoxSize()
        {
            var imposition = new Imposition();
            var layout = new Layout
            {
                Tiles = new List<Tile>
                {
                    GetDefaultTile(),
                    GetDefaultTile()
                }
            };
            var sourceFiles = new List<SourceFile>
            {
                new SourceFile
                {
                    Pages = new List<SourcePage>
                    {
                        new SourcePage
                        {
                            CropBox = new Box {Width = layout.Tiles[0].CutBox.Width, Height = layout.Tiles[0].CutBox.Height}
                        }
                    }
                }
            };

            var target = new Validator();

            target.ValidateSourceFiles(sourceFiles, layout, imposition);
        }

        [Test]
        public void Validate_ShouldNotThrowWhenSourcePageCropBoxSizeMatchLayoutCutBoxSize_ButImpositionRequiresRotation()
        {
            var imposition = new Imposition {MediaRotationAngle = 90f};
            var layout = new Layout
            {
                Tiles = new List<Tile>
                {
                    GetDefaultTile(),
                    GetDefaultTile()
                }
            };
            var sourceFiles = new List<SourceFile>
            {
                new SourceFile
                {
                    Pages = new List<SourcePage>
                    {
                        new SourcePage
                        {
                            CropBox = new Box {Width = layout.Tiles[0].CutBox.Height, Height = layout.Tiles[0].CutBox.Width}
                        }
                    }
                }
            };

            var target = new Validator();

            target.ValidateSourceFiles(sourceFiles, layout, imposition);
        }

        [Test]
        public void Validate_ShouldThrowWhenLayoutHasTilesWithDifferentCutBoxSize()
        {
            var layout = new Layout
            {
                Tiles = new List<Tile>
                {
                    GetDefaultTile(),
                    GetDefaultTile().With(t => t.CutBox = new Box {Width = t.CutBox.Width, Height = t.CutBox.Height + 1})
                }
            };

            var target = new Validator();

            Should.Throw<ApplicationException>(() => target.ValidateLayout(layout));
        }

        [Test]
        public void Validate_ShouldThrowWhenLayoutHasTilesWithDifferentMediaBoxSize()
        {
            var layout = new Layout
            {
                Tiles = new List<Tile>
                {
                    GetDefaultTile(),
                    GetDefaultTile().With(t => t.MediaBox = new Box {Width = t.MediaBox.Width, Height = t.MediaBox.Height + 1})
                }
            };

            var target = new Validator();

            Should.Throw<ApplicationException>(() => target.ValidateLayout(layout));
        }

        [Test]
        public void Validate_ShouldThrowWhenSourcePageCropBoxSizeDoesntMatchLayoutCutBoxSize()
        {
            var imposition = new Imposition();
            var layout = new Layout
            {
                Tiles = new List<Tile>
                {
                    GetDefaultTile(),
                    GetDefaultTile()
                }
            };
            var sourceFiles = new List<SourceFile>
            {
                new SourceFile
                {
                    Pages = new List<SourcePage>
                    {
                        new SourcePage
                        {
                            CropBox = new Box {Width = layout.Tiles[0].CutBox.Width + 1, Height = layout.Tiles[0].CutBox.Height}
                        }
                    }
                }
            };

            var target = new Validator();

            Should.Throw<ApplicationException>(() => target.ValidateSourceFiles(sourceFiles, layout, imposition));
        }

        private static Tile GetDefaultTile()
        {
            return new Tile
            {
                RowIndex = 0,
                ColumnIndex = 0,
                MediaBox = new Box {Left = 0, Bottom = 100, Width = 100, Height = 100},
                CutBox = new Box {Left = 10, Bottom = 110, Width = 80, Height = 80}
            };
        }
    }
}