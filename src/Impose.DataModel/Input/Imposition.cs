using System.Collections.Generic;

namespace Albelli.Impose.DataModel.Input
{
    public class Imposition
    {
        public string Key { get; set; }
        public int PapCode { get; set; }

        public PrintSurface PrintSurfaceType { get; set; }
        public float MediaRotationAngle { get; set; }

        public bool IsDuplex => PrintSurfaceType != PrintSurface.Simplex;

        // not used for now
        public SourcePagesImpositionOrder SourcePagesImpositionOrder { get; set; }
        public SheetImpositionStartPoint ImpositionStartPoint { get; set; }
        public SheetImpositionDirection ImpositionDirection { get; set; }
        public List<Element> ProductLeaderContent { get; set; }
    }

    public enum SourcePagesImpositionOrder
    {
        /// <summary>
        /// pages are being impositioned from the first source page to the last
        /// </summary>
        Direct,
        /// <summary>
        /// pages are being impositioned from the last source page to the first
        /// </summary>
        Reversed
    }

    public enum SheetImpositionStartPoint
    {
        /// <summary>
        /// pages are being impositioned starting from the bottom right corner of the layout
        /// </summary>
        BottomRight
    }

    public enum SheetImpositionDirection
    {
        /// <summary>
        /// pages are being impositioned starting from the last row towards the first row
        /// </summary>
        Up,
        /// <summary>
        /// pages are being impositioned starting from the last column towards the first column
        /// </summary>
        Left
    }

    public enum Orientation
    {
        Portrait,
        Landscape,
        Square
    }
}