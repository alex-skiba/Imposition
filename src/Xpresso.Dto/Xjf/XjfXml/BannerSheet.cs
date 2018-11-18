using System.Diagnostics.CodeAnalysis;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "BannerSheet")]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public class BannerSheet
    {
        [XmlElement(ElementName = "vendorname")]
        public string VendorName { get; set; }

        [XmlElement(ElementName = "vendorurl")]
        public string VendorUrl { get; set; }

        //that field name is pascal-cased
        [XmlElement(ElementName = "CoverCode")]
        public string CoverCode { get; set; }

        [XmlElement(ElementName = "lasercode")]
        public string LaserCode { get; set; }

        [XmlElement(ElementName = "linecount")]
        public string LineCount { get; set; }
    }
}