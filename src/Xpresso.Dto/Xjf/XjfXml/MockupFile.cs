using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "File")]
    public class MockupFile
    {
        [XmlAttribute(AttributeName = "ID")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "PaperType")]
        public string PaperType { get; set; }

        [XmlAttribute(AttributeName = "Duplex")]
        public string Duplex { get; set; }

        [XmlAttribute(AttributeName = "Remarks")]
        public string Remarks { get; set; }

        [XmlAttribute(AttributeName = "CoverSize")]
        public string CoverSize { get; set; }

        [XmlAttribute(AttributeName = "CoverBleed")]
        public string CoverBleed { get; set; }

        [XmlAttribute(AttributeName = "ContentSize")]
        public string ContentSize { get; set; }

        [XmlAttribute(AttributeName = "ContentBleed")]
        public string ContentBleed { get; set; }

        [XmlAttribute(AttributeName = "Pages")]
        public string Pages { get; set; }

        [XmlAttribute(AttributeName = "Spread")]
        public string Spread { get; set; }

        [XmlAttribute(AttributeName = "CropBox")]
        public string CropBox { get; set; }

        [XmlAttribute(AttributeName = "HideBleed")]
        public string HideBleed { get; set; }

        [XmlAttribute(AttributeName = "PdfVersion")]
        public string PdfVersion { get; set; }

        [XmlAttribute(AttributeName = "HasSymmetricBleed")]
        public string HasSymmetricBleed { get; set; }

        [XmlAttribute(AttributeName = "SpineWidth")]
        public string SpineWidth { get; set; }

        [XmlAttribute(AttributeName = "VariableWidths")]
        public string VariableWidths { get; set; }

        [XmlAttribute(AttributeName = "PageColor")]
        public string PageColor { get; set; }
    }
}