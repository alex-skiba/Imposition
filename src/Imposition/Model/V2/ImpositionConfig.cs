using System.Collections.Generic;

namespace Imposition.Model.V2
{
    public class ImpositionConfig
    {
        public Size MediaBoxSize { get; set; }
        public float MediaRotationAngle { get; set; }
        public SourcePagesImpositionOrder SourcePagesImpositionOrder { get; set; }
        public SheetImpositionStartPoint FrontStartPoint { get; set; }
        public SheetImpositionStartPoint BackStartPoint { get; set; }
        public SheetImpositionDirection FrontDirection { get; set; }
        public SheetImpositionDirection BackDirection { get; set; }
        public List<Element> ProductLeaderContent { get; set; }
    }

    public class Element
    {
        public ElementType Type { get; set; }

        /// <summary>
        /// Unique key that allows to find the content of the element
        /// </summary>
        public string Key { get; set; }
        public Point Location { get; set; }
        public float RotationAngle { get; set; }
    }

    public enum ElementType
    {
        Text,
        Image
    }

    public class Point
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    public class Size
    {
        public float Width { get; set; }
        public float Height { get; set; }
    }

    public enum SourcePagesImpositionOrder
    {
        Direct,
        Reversed
    }

    public enum SheetImpositionStartPoint
    {
        BottomRight
    }

    public enum SheetImpositionDirection
    {
        Up
    }

    public enum Orientation
    {
        Portrait,
        Landscape,
        Square
    }
}
