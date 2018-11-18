using System;
using System.Globalization;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "file")]
    public class ResourceFile
    {
        private string repeat;
        private string bleed;

        [XmlElement(ElementName = "variables")]
        public Variables Variables { get; set; }

        [XmlAttribute(AttributeName = "dealerid")]
        public string DealerId { get; set; }

        [XmlAttribute(AttributeName = "vendorid")]
        public string VendorId { get; set; }

        [XmlAttribute(AttributeName = "albumid")]
        public string AlbumId { get; set; }

        [XmlAttribute(AttributeName = "orderid")]
        public string OrderId { get; set; }

        [XmlAttribute(AttributeName = "orderlineid")]
        public string OrderlineId { get; set; }

        [XmlAttribute(AttributeName = "ticketid")]
        public string TicketId { get; set; }

        [XmlAttribute(AttributeName = "ticketbarcode")]
        public string TicketBarcode { get; set; }

        [XmlAttribute(AttributeName = "firstpage")]
        public string FirstPage { get; set; }

        [XmlAttribute(AttributeName = "lastpage")]
        public string LastPage { get; set; }

        [XmlAttribute(AttributeName = "bleed")]
        public string Bleed
        {
            get => bleed;
            set
            {
                bleed = value;
                BleedDouble = double.TryParse(value, out double result) ? result : 0d;
            }
        }

        [XmlIgnore]
        public double BleedDouble { get; private set; }

        [XmlAttribute(AttributeName = "shift")]
        public string Shift { get; set; }

        [XmlAttribute(AttributeName = "margin")]
        public string Margin { get; set; }

        [XmlAttribute(AttributeName = "tumble")]
        public string Tumble { get; set; }

        [XmlAttribute(AttributeName = "quantity")]
        public string Quantity { get; set; }

        [XmlAttribute(AttributeName = "repeat")]
        public string Repeat
        {
            get => repeat;
            set
            {
                repeat = value;
                var repeatValue = int.TryParse(value, out int result) ? result : 1;
                RepeatInt = repeatValue == 0 ? 1 : repeatValue;
            }
        }

        [XmlIgnore]
        public int RepeatInt { get; private set; }

        [XmlAttribute(AttributeName = "binroute")]
        public string BinRoute { get; set; }

        [XmlAttribute(AttributeName = "glosstype")]
        public string GlossType { get; set; }

        [XmlAttribute(AttributeName = "frameCode")]
        public string FrameCode { get; set; }

        [XmlAttribute(AttributeName = "transpose")]
        public string Transpose { get; set; }

        [XmlAttribute(AttributeName = "vendorname")]
        public string VendorName { get; set; }

        [XmlAttribute(AttributeName = "netgateproductid")]
        public string NetgateProductId { get; set; }

        [XmlAttribute(AttributeName = "spinewidth")]
        public string SpineWidth { get; set; }

        [XmlAttribute(AttributeName = "endofstack")]
        public string EndOfStack { get; set; }

        [XmlAttribute(AttributeName = "shipdate")]
        public string ShipDateValue { get; set; }

        [XmlIgnore]
        public DateTime? ShipDate => string.IsNullOrEmpty(ShipDateValue)
            ? default(DateTime?)
            : DateTime.ParseExact(ShipDateValue, "yyyy.MM.dd HH:mm:ss", CultureInfo.InvariantCulture);
    }
}