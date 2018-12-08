using System;
using System.Collections.Generic;
using System.Linq;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.DataModel.Output;
using Albelli.Impose.Logic.Engines;
using NUnit.Framework;
using Shouldly;

namespace Albelli.Impose.Logic.Tests.Engines
{
    [TestFixture]
    public class DuplexSmartStackerOutputFileBuilderTests
    {
        private DuplexSmartStackerOutputFileBuilder _target;

        [SetUp]
        public void SetUp()
        {
            var layout = new Layout
            {
                Tiles = new List<Tile>
                {
                    new Tile {RowIndex = 0, ColumnIndex = 0},
                    new Tile {RowIndex = 0, ColumnIndex = 1},
                    new Tile {RowIndex = 1, ColumnIndex = 0},
                    new Tile {RowIndex = 1, ColumnIndex = 1}
                }
            };
            _target = new DuplexSmartStackerOutputFileBuilder(layout, new Imposition());
        }

        [Test]
        public void Build_ShouldPlacePagesInRightOrder_ForOneProductOneSheet4Up()
        {
            var sourceFiles = new List<SourceFile>
            {
                new SourceFile
                {
                    FileName = "test_file_name.pdf",
                    Pages = GetFakeSourcePages(8)
                }
            };

            var actual = _target.Build(sourceFiles);

            actual.Pages.Count.ShouldBe(2);
            actual.Pages.ShouldAllBe(p => p.ColumnsCount == 2);
            actual.Pages.ShouldAllBe(p => p.RowsCount == 2);
            var frontPage = actual.Pages.First();
            var backPage = actual.Pages.Last();

            frontPage.Tiles[0, 0].SourcePage.Number.ShouldBe(7);
            frontPage.Tiles[0, 1].SourcePage.Number.ShouldBe(3);
            frontPage.Tiles[1, 0].SourcePage.Number.ShouldBe(5);
            frontPage.Tiles[1, 1].SourcePage.Number.ShouldBe(1);
            backPage.Tiles[0, 0].SourcePage.Number.ShouldBe(6);
            backPage.Tiles[0, 1].SourcePage.Number.ShouldBe(2);
            backPage.Tiles[1, 0].SourcePage.Number.ShouldBe(8);
            backPage.Tiles[1, 1].SourcePage.Number.ShouldBe(4);
        }

        [Test]
        public void Build_ShouldPlacePagesInRightOrder_ForOneProductTwoSheets4Up()
        {
            var sourceFiles = new List<SourceFile>
            {
                new SourceFile
                {
                    FileName = "test_file_name.pdf",
                    Pages = GetFakeSourcePages(16)
                }
            };

            var actual = _target.Build(sourceFiles);

            actual.Pages.Count.ShouldBe(4);
            actual.Pages.ShouldAllBe(p => p.ColumnsCount == 2);
            actual.Pages.ShouldAllBe(p => p.RowsCount == 2);
            var firstSheetFrontPage = actual.Pages[0];
            var firstSheetBackPage = actual.Pages[1];

            firstSheetFrontPage.Tiles[0, 0].SourcePage.Number.ShouldBe(15);
            firstSheetFrontPage.Tiles[0, 1].SourcePage.Number.ShouldBe(11);
            firstSheetFrontPage.Tiles[1, 0].SourcePage.Number.ShouldBe(13);
            firstSheetFrontPage.Tiles[1, 1].SourcePage.Number.ShouldBe(9);
            firstSheetBackPage.Tiles[0, 0].SourcePage.Number.ShouldBe(14);
            firstSheetBackPage.Tiles[0, 1].SourcePage.Number.ShouldBe(10);
            firstSheetBackPage.Tiles[1, 0].SourcePage.Number.ShouldBe(16);
            firstSheetBackPage.Tiles[1, 1].SourcePage.Number.ShouldBe(12);

            var secondSheetFrontPage = actual.Pages[2];
            var secondSheetBackPage = actual.Pages[3];

            secondSheetFrontPage.Tiles[0, 0].SourcePage.Number.ShouldBe(7);
            secondSheetFrontPage.Tiles[0, 1].SourcePage.Number.ShouldBe(3);
            secondSheetFrontPage.Tiles[1, 0].SourcePage.Number.ShouldBe(5);
            secondSheetFrontPage.Tiles[1, 1].SourcePage.Number.ShouldBe(1);
            secondSheetBackPage.Tiles[0, 0].SourcePage.Number.ShouldBe(6);
            secondSheetBackPage.Tiles[0, 1].SourcePage.Number.ShouldBe(2);
            secondSheetBackPage.Tiles[1, 0].SourcePage.Number.ShouldBe(8);
            secondSheetBackPage.Tiles[1, 1].SourcePage.Number.ShouldBe(4);
        }

        [Test]
        public void Build_ShouldPlacePagesInRightOrder_ForTwoProducts_WasteInTheEnd()
        {
            var firstProductFileName = "test_file_name_1.pdf";
            var secondProductFileName = "test_file_name_2.pdf";
            var sourceFiles = new List<SourceFile>
            {
                new SourceFile
                {
                    FileName = firstProductFileName,
                    Pages = GetFakeSourcePages(4)
                },
                new SourceFile
                {
                    FileName = secondProductFileName,
                    Pages = GetFakeSourcePages(6)
                }
            };

            var actual = _target.Build(sourceFiles);

            actual.Pages.Count.ShouldBe(4);
            actual.Pages.ShouldAllBe(p => p.ColumnsCount == 2);
            actual.Pages.ShouldAllBe(p => p.RowsCount == 2);
            var firstSheetFrontPage = actual.Pages[0];
            var firstSheetBackPage = actual.Pages[1];

            firstSheetFrontPage.Tiles[0, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetFrontPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            firstSheetFrontPage.Tiles[1, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetFrontPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);
            firstSheetBackPage.Tiles[0, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetBackPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            firstSheetBackPage.Tiles[1, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetBackPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);

            var secondSheetFrontPage = actual.Pages[2];
            var secondSheetBackPage = actual.Pages[3];

            secondSheetFrontPage.Tiles.ShouldAllBe(t => t.SourceFilePath == secondProductFileName);
            secondSheetBackPage.Tiles.ShouldAllBe(t => t.SourceFilePath == secondProductFileName);
            secondSheetFrontPage.Tiles[0, 1].IsEmpty.ShouldBeTrue();
            secondSheetFrontPage.Tiles[1, 0].IsEmpty.ShouldBeTrue();
            secondSheetFrontPage.Tiles[1, 1].IsEmpty.ShouldBeTrue();
            secondSheetBackPage.Tiles[0, 0].IsEmpty.ShouldBeTrue();
            secondSheetBackPage.Tiles[0, 1].IsEmpty.ShouldBeTrue();
            secondSheetBackPage.Tiles[1, 1].IsEmpty.ShouldBeTrue();
        }

        [Test]
        public void Build_ShouldPlacePagesInRightOrder_ForTwoProductsOneSheetEach4Up()
        {
            var firstProductFileName = "test_file_name_1.pdf";
            var secondProductFileName = "test_file_name_2.pdf";
            var sourceFiles = new List<SourceFile>
            {
                new SourceFile
                {
                    FileName = firstProductFileName,
                    Pages = GetFakeSourcePages(8)
                },
                new SourceFile
                {
                    FileName = secondProductFileName,
                    Pages = GetFakeSourcePages(8)
                }
            };

            var actual = _target.Build(sourceFiles);

            actual.Pages.Count.ShouldBe(4);
            actual.Pages.ShouldAllBe(p => p.ColumnsCount == 2);
            actual.Pages.ShouldAllBe(p => p.RowsCount == 2);
            var firstSheetFrontPage = actual.Pages[0];
            var firstSheetBackPage = actual.Pages[1];

            firstSheetFrontPage.Tiles[0, 0].SourcePage.Number.ShouldBe(7);
            firstSheetFrontPage.Tiles[0, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetFrontPage.Tiles[0, 1].SourcePage.Number.ShouldBe(3);
            firstSheetFrontPage.Tiles[0, 1].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetFrontPage.Tiles[1, 0].SourcePage.Number.ShouldBe(5);
            firstSheetFrontPage.Tiles[1, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetFrontPage.Tiles[1, 1].SourcePage.Number.ShouldBe(1);
            firstSheetFrontPage.Tiles[1, 1].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetBackPage.Tiles[0, 0].SourcePage.Number.ShouldBe(6);
            firstSheetBackPage.Tiles[0, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetBackPage.Tiles[0, 1].SourcePage.Number.ShouldBe(2);
            firstSheetBackPage.Tiles[0, 1].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetBackPage.Tiles[1, 0].SourcePage.Number.ShouldBe(8);
            firstSheetBackPage.Tiles[1, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetBackPage.Tiles[1, 1].SourcePage.Number.ShouldBe(4);
            firstSheetBackPage.Tiles[1, 1].SourceFilePath.ShouldBe(firstProductFileName);

            var secondSheetFrontPage = actual.Pages[2];
            var secondSheetBackPage = actual.Pages[3];

            secondSheetFrontPage.Tiles[0, 0].SourcePage.Number.ShouldBe(7);
            secondSheetFrontPage.Tiles[0, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[0, 1].SourcePage.Number.ShouldBe(3);
            secondSheetFrontPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[1, 0].SourcePage.Number.ShouldBe(5);
            secondSheetFrontPage.Tiles[1, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[1, 1].SourcePage.Number.ShouldBe(1);
            secondSheetFrontPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[0, 0].SourcePage.Number.ShouldBe(6);
            secondSheetBackPage.Tiles[0, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[0, 1].SourcePage.Number.ShouldBe(2);
            secondSheetBackPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[1, 0].SourcePage.Number.ShouldBe(8);
            secondSheetBackPage.Tiles[1, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[1, 1].SourcePage.Number.ShouldBe(4);
            secondSheetBackPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);
        }

        [Test]
        public void Build_ShouldPlacePagesInRightOrder_ForTwoProductsOneSheetEach4Up_OneTileWaste()
        {
            var firstProductFileName = "test_file_name_1.pdf";
            var secondProductFileName = "test_file_name_2.pdf";
            var sourceFiles = new List<SourceFile>
            {
                new SourceFile
                {
                    FileName = firstProductFileName,
                    Pages = GetFakeSourcePages(6)
                },
                new SourceFile
                {
                    FileName = secondProductFileName,
                    Pages = GetFakeSourcePages(8)
                }
            };

            var actual = _target.Build(sourceFiles);

            actual.Pages.Count.ShouldBe(4);
            actual.Pages.ShouldAllBe(p => p.ColumnsCount == 2);
            actual.Pages.ShouldAllBe(p => p.RowsCount == 2);
            var firstSheetFrontPage = actual.Pages[0];
            var firstSheetBackPage = actual.Pages[1];

            firstSheetFrontPage.Tiles[0, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetFrontPage.Tiles[0, 1].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetFrontPage.Tiles[1, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetFrontPage.Tiles[1, 1].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetFrontPage.Tiles[1, 1].IsEmpty.ShouldBeTrue();
            firstSheetBackPage.Tiles[0, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetBackPage.Tiles[0, 1].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetBackPage.Tiles[0, 1].IsEmpty.ShouldBeTrue();
            firstSheetBackPage.Tiles[1, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetBackPage.Tiles[1, 1].SourceFilePath.ShouldBe(firstProductFileName);

            var secondSheetFrontPage = actual.Pages[2];
            var secondSheetBackPage = actual.Pages[3];

            secondSheetFrontPage.Tiles[0, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[1, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[0, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[1, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);
        }

        [Test]
        public void Build_ShouldPlacePagesInRightOrder_ForTwoProductsOneSheetEach4Up_ThreeTilesWaste()
        {
            var firstProductFileName = "test_file_name_1.pdf";
            var secondProductFileName = "test_file_name_2.pdf";
            var sourceFiles = new List<SourceFile>
            {
                new SourceFile
                {
                    FileName = firstProductFileName,
                    Pages = GetFakeSourcePages(2)
                },
                new SourceFile
                {
                    FileName = secondProductFileName,
                    Pages = GetFakeSourcePages(8)
                }
            };

            var actual = _target.Build(sourceFiles);

            actual.Pages.Count.ShouldBe(4);
            actual.Pages.ShouldAllBe(p => p.ColumnsCount == 2);
            actual.Pages.ShouldAllBe(p => p.RowsCount == 2);
            var firstSheetFrontPage = actual.Pages[0];
            var firstSheetBackPage = actual.Pages[1];

            firstSheetFrontPage.Tiles[0, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetFrontPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            firstSheetFrontPage.Tiles[1, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetFrontPage.Tiles[1, 0].IsEmpty.ShouldBeTrue();
            firstSheetFrontPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);
            firstSheetBackPage.Tiles[0, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetBackPage.Tiles[0, 0].IsEmpty.ShouldBeTrue();
            firstSheetBackPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            firstSheetBackPage.Tiles[1, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetBackPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);

            var secondSheetFrontPage = actual.Pages[2];
            var secondSheetBackPage = actual.Pages[3];

            secondSheetFrontPage.Tiles[0, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[0, 1].IsEmpty.ShouldBeTrue();
            secondSheetFrontPage.Tiles[1, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[1, 1].IsEmpty.ShouldBeTrue();
            secondSheetBackPage.Tiles[0, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[0, 1].IsEmpty.ShouldBeTrue();
            secondSheetBackPage.Tiles[1, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[1, 1].IsEmpty.ShouldBeTrue();
        }

        [Test]
        public void Build_ShouldPlacePagesInRightOrder_ForTwoProductsOneSheetEach4Up_TwoTilesWaste()
        {
            var firstProductFileName = "test_file_name_1.pdf";
            var secondProductFileName = "test_file_name_2.pdf";
            var sourceFiles = new List<SourceFile>
            {
                new SourceFile
                {
                    FileName = firstProductFileName,
                    Pages = GetFakeSourcePages(4)
                },
                new SourceFile
                {
                    FileName = secondProductFileName,
                    Pages = GetFakeSourcePages(8)
                }
            };

            var actual = _target.Build(sourceFiles);

            actual.Pages.Count.ShouldBe(4);
            actual.Pages.ShouldAllBe(p => p.ColumnsCount == 2);
            actual.Pages.ShouldAllBe(p => p.RowsCount == 2);
            var firstSheetFrontPage = actual.Pages[0];
            var firstSheetBackPage = actual.Pages[1];

            firstSheetFrontPage.Tiles[0, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetFrontPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            firstSheetFrontPage.Tiles[1, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetFrontPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);
            firstSheetBackPage.Tiles[0, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetBackPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            firstSheetBackPage.Tiles[1, 0].SourceFilePath.ShouldBe(firstProductFileName);
            firstSheetBackPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);

            var secondSheetFrontPage = actual.Pages[2];
            var secondSheetBackPage = actual.Pages[3];

            secondSheetFrontPage.Tiles[0, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[0, 1].IsEmpty.ShouldBeTrue();
            secondSheetFrontPage.Tiles[1, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetFrontPage.Tiles[1, 1].IsEmpty.ShouldBeTrue();
            secondSheetBackPage.Tiles[0, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[0, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[0, 1].IsEmpty.ShouldBeTrue();
            secondSheetBackPage.Tiles[1, 0].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[1, 1].SourceFilePath.ShouldBe(secondProductFileName);
            secondSheetBackPage.Tiles[1, 1].IsEmpty.ShouldBeTrue();
        }

        [Test]
        public void Build_ShouldSetCorrectTileParameters()
        {
            // todo: move tile building to a separate testable class
            var layout = new Layout
            {
                Tiles = new List<Tile>
                {
                    new Tile
                    {
                        RowIndex = 0,
                        ColumnIndex = 0,
                        MediaBox = new Box {Left = 0, Bottom = 100, Width = 100, Height = 100},
                        CutBox = new Box {Left = 10, Bottom = 110, Width = 80, Height = 80}
                    },
                    new Tile
                    {
                        RowIndex = 0,
                        ColumnIndex = 1,
                        MediaBox = new Box {Left = 100, Bottom = 100, Width = 100, Height = 100},
                        CutBox = new Box {Left = 110, Bottom = 110, Width = 80, Height = 80}
                    },
                    new Tile
                    {
                        RowIndex = 1,
                        ColumnIndex = 0,
                        MediaBox = new Box {Left = 0, Bottom = 0, Width = 100, Height = 100},
                        CutBox = new Box {Left = 10, Bottom = 10, Width = 80, Height = 80}
                    },
                    new Tile
                    {
                        RowIndex = 1,
                        ColumnIndex = 1,
                        MediaBox = new Box {Left = 100, Bottom = 0, Width = 100, Height = 100},
                        CutBox = new Box {Left = 110, Bottom = 10, Width = 80, Height = 80}
                    }
                }
            };
            var imposition = new Imposition
            {
                MediaRotationAngle = 90.0f
            };
            var target = new DuplexSmartStackerOutputFileBuilder(layout, imposition);

            var sourceFiles = new List<SourceFile>
            {
                new SourceFile
                {
                    FileName = "test_file_name.pdf",
                    Pages = GetFakeSourcePages(8)
                }
            };

            var actual = target.Build(sourceFiles);

            void ValidateTiles(List<OutputTile> tilesToValidate, Tile layoutTile)
            {
                foreach (var outputTile in tilesToValidate)
                {
                    outputTile.MediaBox.ShouldBe(layoutTile.MediaBox);
                    outputTile.CutBox.ShouldBe(layoutTile.CutBox);
                    outputTile.MediaRotationAngle.ShouldBe(imposition.MediaRotationAngle);
                }
            }

            ValidateTiles(actual.Pages.Select(p => p.Tiles[0, 0]).ToList(), layout.Tiles[0]);
            ValidateTiles(actual.Pages.Select(p => p.Tiles[0, 1]).ToList(), layout.Tiles[1]);
            ValidateTiles(actual.Pages.Select(p => p.Tiles[1, 0]).ToList(), layout.Tiles[2]);
            ValidateTiles(actual.Pages.Select(p => p.Tiles[1, 1]).ToList(), layout.Tiles[3]);
        }

        [Test]
        public void Build_ShouldSetValuesFromLayout()
        {
            var sourceFiles = new List<SourceFile>
            {
                new SourceFile
                {
                    FileName = "test_file_name.pdf",
                    Pages = GetFakeSourcePages(2)
                }
            };
            var layout = new Layout {Tiles = new List<Tile> {new Tile()}, SheetSize = new Size {Width = 300, Height = 320}};
            var target = new DuplexSmartStackerOutputFileBuilder(layout, new Imposition());

            var actual = target.Build(sourceFiles);

            actual.SheetSize.ShouldBe(layout.SheetSize);
        }

        [Test]
        public void Build_ShouldThrow_WhenProductHasNoPages()
        {
            var fakeEmptyProduct = new SourceFile {Pages = new List<SourcePage>()};

            Should.Throw<ArgumentException>(() => _target.Build(new List<SourceFile> {fakeEmptyProduct}));
        }

        [Test]
        public void Build_ShouldThrow_WhenProductIsNotDuplex()
        {
            var fakeSimplexProduct = new SourceFile {Pages = new List<SourcePage> {new SourcePage()}};

            Should.Throw<ArgumentException>(() => _target.Build(new List<SourceFile> {fakeSimplexProduct}));
        }

        private static List<SourcePage> GetFakeSourcePages(int amount)
        {
            return Enumerable.Range(1, amount).Select(number => new SourcePage {Number = number}).ToList();
        }
    }

    public static class LoggingExtensions
    {
        public static string AsString(this Layout layout)
        {
            return $"pap_{layout.PapCode}";
        }

        public static string AsString(this Box box)
        {
            return $"{box.Left} {box.Bottom} {box.Width} {box.Height}";
        }

        public static string AsString(this Size size)
        {
            return $"{size.Width} {size.Height}";
        }
    }
}