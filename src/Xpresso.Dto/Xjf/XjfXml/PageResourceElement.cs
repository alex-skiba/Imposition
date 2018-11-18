using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    public abstract class PageResourceElement : PageElement
    {
        [XmlAttribute(AttributeName = "resource")]
        public string Resource { get; set; }
    }
}