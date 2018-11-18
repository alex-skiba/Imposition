using System.Collections.Generic;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "xpresso", Namespace = "")]
    public class XpressoModel
    {
        [XmlElement(ElementName = "mockups")]
        public Mockups Mockups { get; set; }

        [XmlElement(ElementName = "templates")]
        public Templates Templates { get; set; }

        [XmlElement(ElementName = "job")]
        public List<Job> Jobs { get; set; }

        [XmlAttribute(AttributeName = "pdfjobfilename")]
        public string PdfJobFilename { get; set; }

        [XmlAttribute(AttributeName = "psjobfilename")]
        public string PsJobFilename { get; set; }

        [XmlAttribute(AttributeName = "StatusCallBackURL")]
        public string StatusCallBackUrl { get; set; }

        [XmlAttribute(AttributeName = "account")]
        public string Account { get; set; }

        [XmlAttribute(AttributeName = "password")]
        public string Password { get; set; }

        [XmlAttribute(AttributeName = "psjob")]
        public string PsJob { get; set; }
    }
}