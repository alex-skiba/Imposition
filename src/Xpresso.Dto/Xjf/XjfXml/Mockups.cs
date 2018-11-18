using System.Collections.Generic;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "mockups")]
    public class Mockups
    {
        [XmlElement(ElementName = "File")]
        public List<MockupFile> Files { get; set; }
    }
}