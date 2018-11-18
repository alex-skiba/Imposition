using System.Collections.Generic;
using System.Linq;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.DataModel.Output;

namespace Albelli.Impose.DataModel.Extensions
{
    public static class TileExtensions
    {
        public static Tile At(this IEnumerable<Tile> tiles, int row, int col)
        {
            return tiles.Single(t => t.RowIndex == row && t.ColumnIndex == col);
        }

        public static Tile At(this IEnumerable<Tile> tiles, TilePosition position)
        {
            return tiles.Single(t => t.RowIndex == position.RowIndex && t.ColumnIndex == position.ColumnIndex);
        }
    }
}