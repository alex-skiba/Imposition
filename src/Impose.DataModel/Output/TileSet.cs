using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Albelli.Impose.DataModel.Output
{
    public class OutputTileSet : IEnumerable<OutputTile>
    {
        private readonly OutputTile[,] _tiles;

        public OutputTileSet(int rows, int columns)
        {
            _tiles = new OutputTile[rows, columns];

            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    _tiles[row, column] = new OutputTile(new TilePosition(row, column));
                }
            }
        }

        public OutputTile this[int row, int column] => _tiles[row, column];
        public OutputTile this[TilePosition tilePosition] => this[tilePosition.RowIndex, tilePosition.ColumnIndex];

        public IEnumerator<OutputTile> GetEnumerator()
        {
            return _tiles.Cast<OutputTile>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}