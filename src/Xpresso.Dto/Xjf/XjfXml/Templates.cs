using System.Collections.Generic;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "templates", Namespace = "")]
    public class Templates
    {
        [XmlElement(ElementName = "pages")]
        public List<Pages> Pages { get; set; }

        [XmlAttribute(AttributeName = "units")]
        public string Units { get; set; }
    }
}