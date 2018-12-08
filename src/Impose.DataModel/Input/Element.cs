using Albelli.Impose.DataModel.Common;

namespace Albelli.Impose.DataModel.Input
{
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
}