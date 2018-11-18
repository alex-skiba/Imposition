using System.Collections.Generic;

namespace Imposition.Model
{
    // all values are in points
    public class Layout
    {
        public int PapCode { get; set; }
        public float SheetWidth { get; set; }
        public float SheetHeight { get; set; }
        public List<Element> Elements { get; set; }
        public List<Tile> Tiles { get; set; }
    }

    public class Tile
    {
        /// <summary>
        /// Box describes location of the tile on the Layout sheet.
        /// </summary>
        public Box Box { get; set; }

        /// <summary>
        /// Box for main content of the tile, usually customer's image. Dimensions there are relative to the Tile.
        /// </summary>
        public Box MediaBox { get; set; }

        /// <summary>
        /// Box for cutting. Dimensions there are relative to the Tile.
        /// </summary>
        public Box CutBox { get; set; }

        /// <summary>
        /// Some tile-specific elements, like barcodes or logos. Dimensions there are relative to the Tile.
        /// </summary>
        public List<Element> Elements { get; set; }
    }

        public class Element
        {
            public ElementType Type { get; set; }

            /// <summary>
            /// Unique key that allows to find the content of the element
            /// </summary>
            public string Key { get; set; }

            public Box Box { get; set; }
            public float Rotate { get; set; }
        }

    public class Box
    {
        public float Left { get; set; }
        public float Bottom { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
    }
}