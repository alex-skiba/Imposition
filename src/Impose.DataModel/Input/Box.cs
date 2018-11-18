namespace Albelli.Impose.DataModel.Input
{
    public struct Box
    {
        public float Left { get; set; }
        public float Rigth => Left + Width;
        public float Bottom { get; set; }
        public float Top => Bottom + Height;
        public float Width { get; set; }
        public float Height { get; set; }
    }
}