namespace Albelli.Impose.DataModel.Common
{
    public struct Box
    {
        public float Left { get; set; }
        public float Bottom { get; set; }
        public float Right => Left + Width;
        public float Top => Bottom + Height;
        public float Width { get; set; }
        public float Height { get; set; }
        public Size Size => new Size {Width = Width, Height = Height};
    }
}