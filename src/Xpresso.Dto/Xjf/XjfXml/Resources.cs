using System.Collections.Generic;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "resources", Namespace = "")]
    public class Resources
    {
        [XmlElement(ElementName = "file")]
        public List<ResourceFile> Files { get; set; }

        [XmlAttribute(AttributeName = "size")]
        public string Size { get; set; }

        [XmlAttribute(AttributeName = "tile")]
        public string Tile { get; set; }

        [XmlAttribute(AttributeName = "calendarrotate")]
        public bool CalendarRotate { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool CalendarRotateSpecified;

        [XmlAttribute(AttributeName = "dustcovermarks")]
        public bool DustCoverMarks { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool DustCoverMarksSpecified;

        [XmlAttribute(AttributeName = "fillemptytileswithmagenta")]
        public bool FillEmptyTilesWithMagenta { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool FillEmptyTilesWithMagentaSpecified;

        [XmlAttribute(AttributeName = "foldmarks")]
        public bool FoldMarks { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool FoldMarksSpecified;

        [XmlAttribute(AttributeName = "purmarkoffset")]
        public string PurMarkOffset { get; set; }

        [XmlAttribute(AttributeName = "cutmarkoffset")]
        public string CutMarkOffset { get; set; }

        [XmlAttribute(AttributeName = "smallproductrotate")]
        public bool SmallProductRotate { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool SmallProductRotateSpecified;

        [XmlAttribute(AttributeName = "splitmarks")]
        public bool SplitMarks { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool SplitMarksSpecified;

        [XmlAttribute(AttributeName = "transposegrip")]
        public bool TransposeGrip { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool TransposeGripSpecified;
    }
}