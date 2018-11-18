using System;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Classes
{
    [Serializable]
    public class Press
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string Type { get; set; }
    }
}