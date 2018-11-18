using Albelli.Impose.DataModel.Output;

namespace Albelli.Impose.Logic.Engines.Iterator
{
    //Front:                            Y axis
    // _col0_col1_                      ^
    // |_0__|_2__|  -- row 0            |
    // |_1__|_3__|  -- row 1            |
    //Back --------------------------------------> X axis
    // _col0_col1_                      |
    // |_1__|_3__|  -- row 0            |
    // |_0__|_2__|  -- row 1            |
    // todo: because of production specific, it should be upside down
    public class YFlipBackSideTileIterator : IDuplexTileIterator
    {
        private readonly int _maxAllowedIndex;
        private int _current;

        public YFlipBackSideTileIterator(int rowsCount, int columnsCount)
        {
            _current = 0;
            RowsCount = rowsCount;
            ColumnsCount = columnsCount;
            _maxAllowedIndex = RowsCount * ColumnsCount - 1;
        }

        protected int RowsCount { get; }

        protected int ColumnsCount { get; }

        public bool IsInitial => _current == 0;
        public TilePosition CurrentFrontPosition => new TilePosition(GetFrontRow(_current), GetFrontColumn(_current));
        public TilePosition CurrentBackPosition => new TilePosition(GetBackRow(_current), GetBackColumn(_current));
        public TilePosition InitialFrontPosition => new TilePosition(GetFrontRow(0), GetFrontColumn(0));

        public void MoveForward()
        {
            _current++;
            if (_current > _maxAllowedIndex)
            {
                _current = 0;
            }
        }

        protected virtual int GetFrontRow(int currentIndex)
        {
            return currentIndex % ColumnsCount;
        }

        protected virtual int GetBackRow(int currentIndex)
        {
            return RowsCount - GetFrontRow(currentIndex) - 1;
        }

        protected virtual int GetFrontColumn(int currentIndex)
        {
            return currentIndex / RowsCount;
        }

        protected int GetBackColumn(int currentIndex)
        {
            return currentIndex / RowsCount;
        }
    }
}