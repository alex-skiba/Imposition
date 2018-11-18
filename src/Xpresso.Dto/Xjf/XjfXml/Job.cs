using System.Collections.Generic;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "job")]
    public class Job
    {
        [XmlElement(ElementName = "layout")]
        public List<Layout> Layout { get; set; }

        [XmlAttribute(AttributeName = "file")]
        public string File { get; set; }

        [XmlAttribute(AttributeName = "batchid")]
        public string BatchId { get; set; }

        [XmlAttribute(AttributeName = "batchbarcode")]
        public string BatchBarcode { get; set; }

        [XmlAttribute(AttributeName = "pressid")]
        public string PressId { get; set; }

        [XmlAttribute(AttributeName = "press")]
        public string Press { get; set; }

        [XmlAttribute(AttributeName = "presstype")]
        public string PressType { get; set; }

        [XmlAttribute(AttributeName = "spinewidth")]
        public string SpineWidth { get; set; }

        [XmlAttribute(AttributeName = "substrateid")]
        public string SubstrateId { get; set; }

        [XmlAttribute(AttributeName = "substrate")]
        public string Substrate { get; set; }

        [XmlAttribute(AttributeName = "gloss")]
        public string Gloss { get; set; }

        [XmlAttribute(AttributeName = "profile")]
        public string Profile { get; set; }

        [XmlAttribute(AttributeName = "priority")]
        public string Priority { get; set; }

        [XmlAttribute(AttributeName = "flysheets")]
        public string Flysheets { get; set; }

        [XmlAttribute(AttributeName = "splitsheet")]
        public string SplitSheet { get; set; }

        [XmlAttribute(AttributeName = "tumble")]
        public string PsTumble { get; set; }

        [XmlAttribute(AttributeName = "reverse")]
        public string PsReverse { get; set; }

        [XmlAttribute(AttributeName = "ticketindex")]
        public string TicketIndex { get; set; }
    }
}