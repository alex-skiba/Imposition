using System;
using System.Xml;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlInclude(typeof(Caption))]
    [XmlInclude(typeof(TicketBarcode))]
    [XmlInclude(typeof(TicketBarcodePlainText))]
    public abstract class PageTextElement: PageElement
    {
        [XmlAttribute(AttributeName = "font")]
        public string Font { get; set; }

        //legacy issue: sometimes boolean value is passed as int
        [XmlAttribute(AttributeName = "bold")]
        public string Bold { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool BoldSpecified;

        //legacy issue: sometimes boolean value is passed as int
        [XmlAttribute(AttributeName = "italic")]
        public string Italic { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool ItalicSpecified;

        [XmlAttribute(AttributeName = "size")]
        public int Size { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool SizeSpecified;

        [XmlAttribute(AttributeName = "leading")]
        public int Leading { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool LeadingSpecified;

        [XmlAttribute(AttributeName = "alignment")]
        public int Alignment { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool AlignmentSpecified;

        [XmlIgnore]
        public string Text { get; set; }

        [XmlIgnore] [Newtonsoft.Json.JsonIgnore] private XmlNode[] rawContent;

        [XmlText]
        [Newtonsoft.Json.JsonIgnore]
        public XmlNode[] Content
        {
            get => rawContent;
            set
            {
                rawContent = value;
                if (value == null)
                {
                    Text = null;
                    return;
                }
                if (value.Length != 1)
                {
                    throw new NotImplementedException("Unexpected element definition");
                }
                var cdata = value[0] as XmlCDataSection;
                Text = cdata != null ? cdata.Data : value[0].Value;
            }
        }

        [XmlAttribute(AttributeName = "color")]
        public string Color { get; set; }

        [XmlAttribute(AttributeName = "bgcolor")]
        public string BgColor { get; set; }

        [XmlAttribute(AttributeName = "linecolor")]
        public string LineColor { get; set; }

        [XmlAttribute(AttributeName = "linewidth")]
        public string LineWidth { get; set; }

        [XmlIgnore]
        public double LineWidthDouble => double.TryParse(LineWidth, out double result) ? result : 0;
    }
}