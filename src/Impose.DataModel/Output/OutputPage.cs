using System.Linq;

namespace Albelli.Impose.DataModel.Output
{
    public class OutputPage
    {
        public OutputTileSet Tiles { get; set; }
        public int RowsCount => Tiles.Max(t => t.Position.RowIndex) + 1;
        public int ColumnsCount => Tiles.Max(t => t.Position.ColumnIndex) + 1;
    }
}