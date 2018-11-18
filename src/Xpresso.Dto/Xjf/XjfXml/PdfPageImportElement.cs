using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    //hack: the inheritance is not true inheritance, it just to fit legacy logic
    public abstract class PdfPageImportElement: PageResourceElement
    {
        [XmlAttribute(AttributeName = "page")]
        public string PageNumber { get; set; }

        [XmlAttribute(AttributeName = "fitmethod")]
        public string FitMethod { get; set; }

        [XmlAttribute(AttributeName = "position")]
        public string Position { get; set; }

        [XmlAttribute(AttributeName = "orientate")]
        public string Orientate { get; set; }
    }
}