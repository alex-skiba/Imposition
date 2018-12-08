namespace Albelli.Impose.DataModel.Input
{
    public struct CutmarksConfig
    {
        // todo: builder
        public CutmarksConfig(float oneOffsetForAll)
        {
            TopLeftOffset = oneOffsetForAll;
            TopRightOffset = oneOffsetForAll;
            BottomLeftOffset = oneOffsetForAll;
            BottomRightOffset = oneOffsetForAll;
            MarkLength = 10.0f;
        }

        public float MarkLength { get; set; }
        public float TopLeftOffset { get; set; }
        public float TopRightOffset { get; set; }
        public float BottomLeftOffset { get; set; }
        public float BottomRightOffset { get; set; }
    }
}