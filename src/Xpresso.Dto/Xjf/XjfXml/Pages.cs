using System.Collections.Generic;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "pages", Namespace = "")]
    public class Pages
    {
        [XmlElement(ElementName = "sheets")]
        public Sheets Sheets { get; set; }

        [XmlElement(ElementName = "page")]
        public List<Page> Page { get; set; }

        [XmlAttribute(AttributeName = "template")]
        public string Template { get; set; }
    }
}