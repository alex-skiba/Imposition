using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Classes
{
    [XmlRoot]
    [Serializable]
    public class XpressoData
    {
        public List<ArticleType> ArticleTypes { get; set; }
        public List<Press> Presses { get; set; }

        [XmlArrayItem(typeof(XpressoDataLayout), ElementName = "Layout")]
        public List<XpressoDataLayout> Layouts { get; set; }
    }
}