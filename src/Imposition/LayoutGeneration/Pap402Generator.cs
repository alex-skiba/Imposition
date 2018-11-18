using System.Collections.Generic;
using Imposition.Extensions;
using Imposition.Model.V2;

namespace Imposition.LayoutGeneration
{
    public static class Pap402Generator
    {
        public static Layout Generate()
        {
            return new Layout
            {
                PapCode = 402,
                SheetWidth = 640f.MmToPoints(),
                SheetHeight = 460f.MmToPoints(),
                FrontTiles = BuildFrontTiles(),
                BackTiles = BuildBackTiles()
            };
        }

        private static List<Tile> BuildFrontTiles()
        {
            return new List<Tile>
            {
                new Tile
                {
                    ColumnIndex = 0,
                    RowIndex = 0,
                    CutBox = new Box
                    {
                        Left = 37f.MmToPoints(),
                        Bottom = 233f.MmToPoints(),
                        Width = 280f.MmToPoints(),
                        Height = 210f.MmToPoints()
                    },
                    MediaBox = new Box
                    {
                        Left = 34f.MmToPoints(),
                        Bottom = 230f.MmToPoints(),
                        Width = 286f.MmToPoints(),
                        Height = 216f.MmToPoints()
                    },
                    CutmarksConfig = new CutmarksConfig(3f.MmToPoints()) {MarkLength = 10f.MmToPoints()}
                },
                new Tile
                {
                    ColumnIndex = 0,
                    RowIndex = 1,
                    CutBox = new Box
                    {
                        Left = 37f.MmToPoints(),
                        Bottom = 17f.MmToPoints(),
                        Width = 280f.MmToPoints(),
                        Height = 210f.MmToPoints()
                    },
                    MediaBox = new Box
                    {
                        Left = 34f.MmToPoints(),
                        Bottom = 14f.MmToPoints(),
                        Width = 286f.MmToPoints(),
                        Height = 216f.MmToPoints()
                    },
                    CutmarksConfig = new CutmarksConfig(3f.MmToPoints()) {MarkLength = 10f.MmToPoints()}
                },
                new Tile
                {
                    ColumnIndex = 1,
                    RowIndex = 0,
                    CutBox = new Box
                    {
                        Left = 323f.MmToPoints(),
                        Bottom = 233f.MmToPoints(),
                        Width = 280f.MmToPoints(),
                        Height = 210f.MmToPoints()
                    },
                    MediaBox = new Box
                    {
                        Left = 320f.MmToPoints(),
                        Bottom = 230f.MmToPoints(),
                        Width = 286f.MmToPoints(),
                        Height = 216f.MmToPoints()
                    },
                    CutmarksConfig = new CutmarksConfig(3f.MmToPoints()) {MarkLength = 10f.MmToPoints()}
                },
                new Tile
                {
                    ColumnIndex = 1,
                    RowIndex = 1,
                    CutBox = new Box
                    {
                        Left = 323f.MmToPoints(),
                        Bottom = 17f.MmToPoints(),
                        Width = 280f.MmToPoints(),
                        Height = 210f.MmToPoints()
                    },
                    MediaBox = new Box
                    {
                        Left = 320f.MmToPoints(),
                        Bottom = 14f.MmToPoints(),
                        Width = 286f.MmToPoints(),
                        Height = 216f.MmToPoints()
                    },
                    CutmarksConfig = new CutmarksConfig(3f.MmToPoints()) {MarkLength = 10f.MmToPoints()}
                }
            };
        }

        private static List<Tile> BuildBackTiles()
        {
            return BuildFrontTiles();
        }
    }
}