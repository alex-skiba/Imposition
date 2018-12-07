using Albelli.Impose.DataModel.Input;

namespace Albelli.Impose.DataModel.Output
{
    public class OutputTile
    {
        public OutputTile(TilePosition position)
        {
            Position = position;
        }

        public bool IsEmpty => SourcePageNumber <= 0;

        // layout
        public TilePosition Position { get; }
        public Box MediaBox { get; set; } = new Box();
        public Box CutBox { get; set; } = new Box();

        // imposition
        public float MediaRotationAngle { get; set; }

        // source
        public string SourceFilePath { get; set; }
        public int SourcePageNumber { get; set; }
    }
}