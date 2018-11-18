namespace Albelli.Impose.DataModel.Output
{
    // _col0_col1_
    // |____|____|  -- row 0
    // |____|____|  -- row 1
    public struct TilePosition
    {
        public TilePosition(int rowIndex, int columnIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = columnIndex;
        }

        public int RowIndex { get; }

        public int ColumnIndex { get; }
    }
}
