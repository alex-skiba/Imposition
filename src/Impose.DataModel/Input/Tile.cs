namespace Albelli.Impose.DataModel.Input
{
    public class Tile
    {
        // todo: TilePosition
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
}