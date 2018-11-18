using System;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "layout")]
    public class Layout
    {
        [XmlElement(ElementName = "resources")]
        public Resources Resources { get; set; }

        [XmlAttribute(AttributeName = "size")]
        public string Size { get; set; }

        [XmlAttribute(AttributeName = "autorotate")]
        public string AutoRotate { get; set; }

        [XmlAttribute(AttributeName = "duplex")]
        public string Duplex { get; set; }

        [XmlAttribute(AttributeName = "cover")]
        public string Cover { get; set; }

        [XmlAttribute(AttributeName = "mirror")]
        public string Mirror { get; set; }

        [XmlAttribute(AttributeName = "imposition")]
        public string Imposition
        {
            get => imposition;
            set
            {
                imposition = value;
                ImpositionType = Enum.TryParse(value.Replace("&", ""), true, out ImpositionTypes result)
                    ? result
                    : ImpositionTypes.MoreUp;
            }
        }

        [XmlIgnore]
        public ImpositionTypes ImpositionType { get; private set; }


        [XmlAttribute(AttributeName = "articletype")]
        public string ArticleType { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool TypeSpecified;

        private string imposition;
    }
}