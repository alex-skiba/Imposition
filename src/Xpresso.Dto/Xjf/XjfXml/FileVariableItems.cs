using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Xml.Serialization;

namespace Albumprinter.Plant.Xpresso.Xjf.XjfXml
{
    [XmlRoot(ElementName = "items")]
    [SuppressMessage("ReSharper", "StringLiteralTypo")]
    public class FileVariableItems
    {
        [XmlElement(ElementName = "batchid")]
        public int BatchId { get; set; }

        [XmlElement(ElementName = "batchbarcode")]
        public string BatchBarcode { get; set; }

        //legacy compatibility issue - empty strings cannot be translated to default(int)
        [XmlElement(ElementName = "associatedbatchid")]
        public string AssociatedBatchId { get; set; }

        // a XmlSerializer tweak - controls optional field
        [XmlIgnore]
        public bool AssociatedBatchIdSpecified;

        [XmlElement(ElementName = "press")]
        public string Press { get; set; }

        [XmlElement(ElementName = "presstype")]
        public string PressType { get; set; }

        [XmlElement(ElementName = "impositionname")]
        public string ImpositionName { get; set; }

        [XmlElement(ElementName = "layoutcode")]
        public string LayoutCode { get; set; }

        [XmlElement(ElementName = "finish")]
        public string Finish { get; set; }

        [XmlElement(ElementName = "finishfillcolor")]
        public string FinishFillColor { get; set; }

        [XmlElement(ElementName = "bluewrapper")]
        public string BlueWrapper { get; set; }

        [XmlElement(ElementName = "premiumlayflat")]
        public string PremiumLayFlat { get; set; }

        [XmlElement(ElementName = "automatch")]
        public string AutoMatch { get; set; }

        [XmlElement(ElementName = "automatchtextcolor")]
        public string AutoMatchTextColor { get; set; }

        [XmlElement(ElementName = "comment")]
        public string Comment { get; set; }

        [XmlElement(ElementName = "prioritytext")]
        public string PriorityText { get; set; }

        [XmlElement(ElementName = "prioritytextcolor")]
        public string PriorityTextColor { get; set; }

        [XmlElement(ElementName = "priorityfillcolor")]
        public string PriorityFillColor { get; set; }

        [XmlElement(ElementName = "postalzone")]
        public string PostalZone { get; set; }

        //legacy compatibility issue - empty strings cannot be translated to default(int)
        [XmlElement(ElementName = "maxsheetcount")]
        public string MaxSheetCount { get; set; }

        [XmlElement(ElementName = "spinewidth")]
        public string SpineWidthValue { get; set; }

        [XmlElement(ElementName = "minshipdate")]
        public string MinShipDateValue { get; set; }

        [XmlIgnore]
        public DateTime? MinShipDate => string.IsNullOrEmpty(MinShipDateValue)
            ? default(DateTime?)
            : DateTime.ParseExact(MinShipDateValue, "yyyy.MM.dd HH:mm:ss", CultureInfo.InvariantCulture);
    }
}