using System.Collections.Generic;

namespace Imposition.Model
{
    // all values are in points
    public class Layout
    {
        public int PapCode { get; set; }
        public float SheetWidth { get; set; }
        public float SheetHeight { get; set; }
        public List<Element> Elements { get; set; }
    }

    public class Element
    {
        public ElementType Type { get; set; }
        public ElementResource Resource { get; set; }
        public float Left { get; set; }
        public float Bottom { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Rotate { get; set; }
    }

    public class ElementResource
    {
        public string Name { get; set; }
        public string FileName { get; set; }
    }
}