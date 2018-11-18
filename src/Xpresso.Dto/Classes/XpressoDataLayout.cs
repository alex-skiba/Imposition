using System;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Classes
{
    [XmlRoot(ElementName = "Layout")]
    [Serializable]
    public class XpressoDataLayout
    {
        [XmlAttribute]
        public int ID { get; set; }
        [XmlAttribute]
        public string Name { get; set; }
    }
}