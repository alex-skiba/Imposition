using System.Collections.Generic;
using System.Linq;

namespace Albelli.Impose.DataModel.Input
{
    // all values are in points
    public class Layout
    {
        public string Key { get; set; }
        public int PapCode { get; set; }

        // todo: substrate
        // todo: gloss (or modifiers)
        // todo: printer
        // todo: finishing

        public Size SheetSize { get; set; }

        public List<Tile> Tiles { get; set; }

        public int ColumnsCount => Tiles.Max(t => t.ColumnIndex) + 1;
        public int RowsCount => Tiles.Max(t => t.RowIndex) + 1;
    }
}