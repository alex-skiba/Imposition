using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlInclude(typeof(Caption))]
    [XmlInclude(typeof(TicketBarcode))]
    [XmlInclude(typeof(TicketBarcodePlainText))]
    [XmlInclude(typeof(Picture))]
    public abstract class PageElement
    {
        [XmlAttribute(AttributeName = "data")]
        public virtual string Data { get; set; }

        [XmlAttribute(AttributeName = "rotate")]
        public string Rotate { get; set; }
    }
}