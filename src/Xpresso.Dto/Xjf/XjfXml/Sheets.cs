using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "sheets", Namespace = "")]
    public class Sheets
    {
        [XmlAttribute(AttributeName = "size")]
        public string Size { get; set; }

        [XmlAttribute(AttributeName = "resource")]
        public string Resource { get; set; }
    }
}