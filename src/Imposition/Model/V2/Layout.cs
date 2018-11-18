using System.Collections.Generic;

namespace Imposition.Model.V2
{
    // all values are in points
    public class Layout
    {
        public int PapCode { get; set; }
        // todo: printer
        // todo: finishing
        public float SheetWidth { get; set; }

        public float SheetHeight { get; set; }

        //public List<Element> Elements { get; set; }
        public List<Tile> FrontTiles { get; set; }
        public List<Tile> BackTiles { get; set; }
    }

    public class Tile
    {
        /// <summary>
        /// Used to specify position of the tile on the sheet
        /// </summary>
        public int ColumnIndex { get; set; }

        public int RowIndex { get; set; }

        /// <summary>
        /// Box for main content of the tile, usually customer's image. Dimensions there are relative to the Tile.
        /// </summary>
        public Box MediaBox { get; set; }

        /// <summary>
        /// Box for cutting. Dimensions there are relative to the Tile.
        /// </summary>
        public Box CutBox { get; set; }

        public CutmarksConfig CutmarksConfig { get; set; }
    }

    public class Box
    {
        public float Left { get; set; }
        public float Bottom { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }

    public class CutmarksConfig
    {
        public CutmarksConfig()
        {

        }

        // todo: builder
        public CutmarksConfig(float oneOffsetForAll)
        {
            TopLeftOffset = oneOffsetForAll;
            TopRightOffset = oneOffsetForAll;
            BottomLeftOffset = oneOffsetForAll;
            BottomRightOffset = oneOffsetForAll;
        }

        public float MarkLength { get; set; }
        public float TopLeftOffset { get; set; }
        public float TopRightOffset { get; set; }
        public float BottomLeftOffset { get; set; }
        public float BottomRightOffset { get; set; }
    }
}