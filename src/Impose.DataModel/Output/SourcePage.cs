using Albelli.Impose.DataModel.Input;

namespace Albelli.Impose.DataModel.Output
{
    public class SourcePage
    {
        public Size SheetSize { get; set; } = new Size();
        public float RotationAngle { get; set; }
        public Box CropBox { get; set; } = new Box();
        public int Number { get; set; }
    }
}