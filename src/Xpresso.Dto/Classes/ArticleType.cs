using System;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Classes
{
    [Serializable]
    public class ArticleType
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public string ArticleCodes { get; set; }
    }
}