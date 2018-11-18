using Albelli.Impose.DataModel.Output;

namespace Albelli.Impose.Logic.Engines.Iterator
{
    // _col0_col1_
    // |____|____|  -- row 0
    // |____|____|  -- row 1
    public interface IDuplexTileIterator
    {
        bool IsInitial { get; }

        TilePosition CurrentFrontPosition { get; }

        TilePosition CurrentBackPosition { get; }

        TilePosition InitialFrontPosition { get; }

        void MoveForward();
    }
}