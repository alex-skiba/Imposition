using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "page")]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public class Page: PdfPageImportElement
    {
        [XmlElement(ElementName = "caption", Type = typeof(Caption))]
        [XmlElement(ElementName = "picture", Type = typeof(Picture))]
        [XmlElement(ElementName = "ticketbarcode", Type = typeof(TicketBarcode))]
        [XmlElement(ElementName = "ticketbarcodeplaintext", Type = typeof(TicketBarcodePlainText))]
        public List<PageElement> PageElement { get; set; }

        [XmlAttribute(AttributeName = "index")]
        public string Index { get; set; }

        //hack: a nonsense had to put due to inheritance
        [XmlAttribute(AttributeName = "data")]
        public override string Data { get; set; }

        [XmlAttribute(AttributeName = "suppressEyeMarks")]
        public bool SuppressEyeMarks { get; set; }
    }
}