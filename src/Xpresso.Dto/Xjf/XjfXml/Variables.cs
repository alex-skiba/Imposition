using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "variables", Namespace = "")]
    public class Variables
    {
        [XmlElement(ElementName = "BannerSheet")]
        public BannerSheet BannerSheet { get; set; }

        [XmlElement(ElementName = "items")]
        public FileVariableItems Items { get; set; }
    }
}