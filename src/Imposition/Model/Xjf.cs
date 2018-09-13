namespace Imposition
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class xpresso
    {

        private xpressoMockups mockupsField;

        private xpressoTemplates templatesField;

        private xpressoJob jobField;

        private string pdfjobfilenameField;

        private string psjobfilenameField;

        private string statusCallBackURLField;

        private string accountField;

        private string passwordField;

        private string psjobField;

        /// <remarks/>
        public xpressoMockups mockups
        {
            get
            {
                return this.mockupsField;
            }
            set
            {
                this.mockupsField = value;
            }
        }

        /// <remarks/>
        public xpressoTemplates templates
        {
            get
            {
                return this.templatesField;
            }
            set
            {
                this.templatesField = value;
            }
        }

        /// <remarks/>
        public xpressoJob job
        {
            get
            {
                return this.jobField;
            }
            set
            {
                this.jobField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pdfjobfilename
        {
            get
            {
                return this.pdfjobfilenameField;
            }
            set
            {
                this.pdfjobfilenameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string psjobfilename
        {
            get
            {
                return this.psjobfilenameField;
            }
            set
            {
                this.psjobfilenameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string StatusCallBackURL
        {
            get
            {
                return this.statusCallBackURLField;
            }
            set
            {
                this.statusCallBackURLField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string account
        {
            get
            {
                return this.accountField;
            }
            set
            {
                this.accountField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string psjob
        {
            get
            {
                return this.psjobField;
            }
            set
            {
                this.psjobField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class xpressoMockups
    {

        private xpressoMockupsFile fileField;

        /// <remarks/>
        public xpressoMockupsFile File
        {
            get
            {
                return this.fileField;
            }
            set
            {
                this.fileField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class xpressoMockupsFile
    {

        private ushort idField;

        private string paperTypeField;

        private byte duplexField;

        private string remarksField;

        private string contentSizeField;

        private string contentBleedField;

        private byte pagesField;

        private byte spreadField;

        private byte cropBoxField;

        private byte hideBleedField;

        private decimal pdfVersionField;

        private byte spineWidthField;

        private byte hasSymmetricBleedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort ID
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PaperType
        {
            get
            {
                return this.paperTypeField;
            }
            set
            {
                this.paperTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Duplex
        {
            get
            {
                return this.duplexField;
            }
            set
            {
                this.duplexField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Remarks
        {
            get
            {
                return this.remarksField;
            }
            set
            {
                this.remarksField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ContentSize
        {
            get
            {
                return this.contentSizeField;
            }
            set
            {
                this.contentSizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ContentBleed
        {
            get
            {
                return this.contentBleedField;
            }
            set
            {
                this.contentBleedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Pages
        {
            get
            {
                return this.pagesField;
            }
            set
            {
                this.pagesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte Spread
        {
            get
            {
                return this.spreadField;
            }
            set
            {
                this.spreadField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte CropBox
        {
            get
            {
                return this.cropBoxField;
            }
            set
            {
                this.cropBoxField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte HideBleed
        {
            get
            {
                return this.hideBleedField;
            }
            set
            {
                this.hideBleedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal PdfVersion
        {
            get
            {
                return this.pdfVersionField;
            }
            set
            {
                this.pdfVersionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte SpineWidth
        {
            get
            {
                return this.spineWidthField;
            }
            set
            {
                this.spineWidthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte HasSymmetricBleed
        {
            get
            {
                return this.hasSymmetricBleedField;
            }
            set
            {
                this.hasSymmetricBleedField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class xpressoTemplates
    {

        private xpressoTemplatesPages pagesField;

        private string unitsField;

        /// <remarks/>
        public xpressoTemplatesPages pages
        {
            get
            {
                return this.pagesField;
            }
            set
            {
                this.pagesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string units
        {
            get
            {
                return this.unitsField;
            }
            set
            {
                this.unitsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class xpressoTemplatesPages
    {

        private xpressoTemplatesPagesPage pageField;

        private string templateField;

        /// <remarks/>
        public xpressoTemplatesPagesPage page
        {
            get
            {
                return this.pageField;
            }
            set
            {
                this.pageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string template
        {
            get
            {
                return this.templateField;
            }
            set
            {
                this.templateField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class xpressoTemplatesPagesPage
    {

        private xpressoTemplatesPagesPagePicture[] pictureField;

        private byte indexField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("picture")]
        public xpressoTemplatesPagesPagePicture[] picture
        {
            get
            {
                return this.pictureField;
            }
            set
            {
                this.pictureField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte index
        {
            get
            {
                return this.indexField;
            }
            set
            {
                this.indexField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class xpressoTemplatesPagesPagePicture
    {

        private string dataField;

        private string resourceField;

        private byte rotateField;

        private string fitmethodField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string resource
        {
            get
            {
                return this.resourceField;
            }
            set
            {
                this.resourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte rotate
        {
            get
            {
                return this.rotateField;
            }
            set
            {
                this.rotateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string fitmethod
        {
            get
            {
                return this.fitmethodField;
            }
            set
            {
                this.fitmethodField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class xpressoJob
    {

        private xpressoJobLayout layoutField;

        private string fileField;

        private ushort batchidField;

        private string batchbarcodeField;

        private byte pressidField;

        private string pressField;

        private string presstypeField;

        private byte substrateidField;

        private string substrateField;

        private string glossField;

        private string profileField;

        private string priorityField;

        private string flysheetsField;

        private bool tumbleField;

        private bool reverseField;

        private byte ticketindexField;

        /// <remarks/>
        public xpressoJobLayout layout
        {
            get
            {
                return this.layoutField;
            }
            set
            {
                this.layoutField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string file
        {
            get
            {
                return this.fileField;
            }
            set
            {
                this.fileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort batchid
        {
            get
            {
                return this.batchidField;
            }
            set
            {
                this.batchidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string batchbarcode
        {
            get
            {
                return this.batchbarcodeField;
            }
            set
            {
                this.batchbarcodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte pressid
        {
            get
            {
                return this.pressidField;
            }
            set
            {
                this.pressidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string press
        {
            get
            {
                return this.pressField;
            }
            set
            {
                this.pressField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string presstype
        {
            get
            {
                return this.presstypeField;
            }
            set
            {
                this.presstypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte substrateid
        {
            get
            {
                return this.substrateidField;
            }
            set
            {
                this.substrateidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string substrate
        {
            get
            {
                return this.substrateField;
            }
            set
            {
                this.substrateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string gloss
        {
            get
            {
                return this.glossField;
            }
            set
            {
                this.glossField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string profile
        {
            get
            {
                return this.profileField;
            }
            set
            {
                this.profileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string priority
        {
            get
            {
                return this.priorityField;
            }
            set
            {
                this.priorityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string flysheets
        {
            get
            {
                return this.flysheetsField;
            }
            set
            {
                this.flysheetsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool tumble
        {
            get
            {
                return this.tumbleField;
            }
            set
            {
                this.tumbleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool reverse
        {
            get
            {
                return this.reverseField;
            }
            set
            {
                this.reverseField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte ticketindex
        {
            get
            {
                return this.ticketindexField;
            }
            set
            {
                this.ticketindexField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class xpressoJobLayout
    {

        private xpressoJobLayoutResources resourcesField;

        private string sizeField;

        private bool autorotateField;

        private bool duplexField;

        private bool coverField;

        private bool mirrorField;

        private string impositionField;

        private string articletypeField;

        /// <remarks/>
        public xpressoJobLayoutResources resources
        {
            get
            {
                return this.resourcesField;
            }
            set
            {
                this.resourcesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool autorotate
        {
            get
            {
                return this.autorotateField;
            }
            set
            {
                this.autorotateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool duplex
        {
            get
            {
                return this.duplexField;
            }
            set
            {
                this.duplexField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool cover
        {
            get
            {
                return this.coverField;
            }
            set
            {
                this.coverField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool mirror
        {
            get
            {
                return this.mirrorField;
            }
            set
            {
                this.mirrorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string imposition
        {
            get
            {
                return this.impositionField;
            }
            set
            {
                this.impositionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string articletype
        {
            get
            {
                return this.articletypeField;
            }
            set
            {
                this.articletypeField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class xpressoJobLayoutResources
    {

        private xpressoJobLayoutResourcesFile fileField;

        private string sizeField;

        private string tileField;

        private bool calendarrotateField;

        private bool dustcovermarksField;

        private bool fillemptytileswithmagentaField;

        private bool foldmarksField;

        private string purmarkoffsetField;

        private byte cutmarkoffsetField;

        private bool smallproductrotateField;

        private bool splitmarksField;

        private bool transposegripField;

        /// <remarks/>
        public xpressoJobLayoutResourcesFile file
        {
            get
            {
                return this.fileField;
            }
            set
            {
                this.fileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string size
        {
            get
            {
                return this.sizeField;
            }
            set
            {
                this.sizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string tile
        {
            get
            {
                return this.tileField;
            }
            set
            {
                this.tileField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool calendarrotate
        {
            get
            {
                return this.calendarrotateField;
            }
            set
            {
                this.calendarrotateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool dustcovermarks
        {
            get
            {
                return this.dustcovermarksField;
            }
            set
            {
                this.dustcovermarksField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool fillemptytileswithmagenta
        {
            get
            {
                return this.fillemptytileswithmagentaField;
            }
            set
            {
                this.fillemptytileswithmagentaField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool foldmarks
        {
            get
            {
                return this.foldmarksField;
            }
            set
            {
                this.foldmarksField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string purmarkoffset
        {
            get
            {
                return this.purmarkoffsetField;
            }
            set
            {
                this.purmarkoffsetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte cutmarkoffset
        {
            get
            {
                return this.cutmarkoffsetField;
            }
            set
            {
                this.cutmarkoffsetField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool smallproductrotate
        {
            get
            {
                return this.smallproductrotateField;
            }
            set
            {
                this.smallproductrotateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool splitmarks
        {
            get
            {
                return this.splitmarksField;
            }
            set
            {
                this.splitmarksField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool transposegrip
        {
            get
            {
                return this.transposegripField;
            }
            set
            {
                this.transposegripField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class xpressoJobLayoutResourcesFile
    {

        private xpressoJobLayoutResourcesFileVariables variablesField;

        private ushort dealeridField;

        private ushort vendoridField;

        private ushort albumidField;

        private ushort orderidField;

        private ushort orderlineidField;

        private ushort ticketidField;

        private ushort ticketbarcodeField;

        private byte firstpageField;

        private byte lastpageField;

        private byte bleedField;

        private byte shiftField;

        private byte marginField;

        private bool tumbleField;

        private byte quantityField;

        private byte repeatField;

        private string binrouteField;

        private string glosstypeField;

        private string frameCodeField;

        private bool transposeField;

        private string vendornameField;

        private string netgateproductidField;

        private byte spinewidthField;

        private bool endofstackField;

        /// <remarks/>
        public xpressoJobLayoutResourcesFileVariables variables
        {
            get
            {
                return this.variablesField;
            }
            set
            {
                this.variablesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort dealerid
        {
            get
            {
                return this.dealeridField;
            }
            set
            {
                this.dealeridField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort vendorid
        {
            get
            {
                return this.vendoridField;
            }
            set
            {
                this.vendoridField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort albumid
        {
            get
            {
                return this.albumidField;
            }
            set
            {
                this.albumidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort orderid
        {
            get
            {
                return this.orderidField;
            }
            set
            {
                this.orderidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort orderlineid
        {
            get
            {
                return this.orderlineidField;
            }
            set
            {
                this.orderlineidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort ticketid
        {
            get
            {
                return this.ticketidField;
            }
            set
            {
                this.ticketidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort ticketbarcode
        {
            get
            {
                return this.ticketbarcodeField;
            }
            set
            {
                this.ticketbarcodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte firstpage
        {
            get
            {
                return this.firstpageField;
            }
            set
            {
                this.firstpageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte lastpage
        {
            get
            {
                return this.lastpageField;
            }
            set
            {
                this.lastpageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte bleed
        {
            get
            {
                return this.bleedField;
            }
            set
            {
                this.bleedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte shift
        {
            get
            {
                return this.shiftField;
            }
            set
            {
                this.shiftField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte margin
        {
            get
            {
                return this.marginField;
            }
            set
            {
                this.marginField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool tumble
        {
            get
            {
                return this.tumbleField;
            }
            set
            {
                this.tumbleField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte repeat
        {
            get
            {
                return this.repeatField;
            }
            set
            {
                this.repeatField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string binroute
        {
            get
            {
                return this.binrouteField;
            }
            set
            {
                this.binrouteField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string glosstype
        {
            get
            {
                return this.glosstypeField;
            }
            set
            {
                this.glosstypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string frameCode
        {
            get
            {
                return this.frameCodeField;
            }
            set
            {
                this.frameCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool transpose
        {
            get
            {
                return this.transposeField;
            }
            set
            {
                this.transposeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string vendorname
        {
            get
            {
                return this.vendornameField;
            }
            set
            {
                this.vendornameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string netgateproductid
        {
            get
            {
                return this.netgateproductidField;
            }
            set
            {
                this.netgateproductidField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte spinewidth
        {
            get
            {
                return this.spinewidthField;
            }
            set
            {
                this.spinewidthField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool endofstack
        {
            get
            {
                return this.endofstackField;
            }
            set
            {
                this.endofstackField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class xpressoJobLayoutResourcesFileVariables
    {

        private xpressoJobLayoutResourcesFileVariablesBannerSheet bannerSheetField;

        /// <remarks/>
        public xpressoJobLayoutResourcesFileVariablesBannerSheet BannerSheet
        {
            get
            {
                return this.bannerSheetField;
            }
            set
            {
                this.bannerSheetField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class xpressoJobLayoutResourcesFileVariablesBannerSheet
    {

        private string vendornameField;

        private string vendorurlField;

        private ushort coverCodeField;

        private string lasercodeField;

        private string linecountField;

        /// <remarks/>
        public string vendorname
        {
            get
            {
                return this.vendornameField;
            }
            set
            {
                this.vendornameField = value;
            }
        }

        /// <remarks/>
        public string vendorurl
        {
            get
            {
                return this.vendorurlField;
            }
            set
            {
                this.vendorurlField = value;
            }
        }

        /// <remarks/>
        public ushort CoverCode
        {
            get
            {
                return this.coverCodeField;
            }
            set
            {
                this.coverCodeField = value;
            }
        }

        /// <remarks/>
        public string lasercode
        {
            get
            {
                return this.lasercodeField;
            }
            set
            {
                this.lasercodeField = value;
            }
        }

        /// <remarks/>
        public string linecount
        {
            get
            {
                return this.linecountField;
            }
            set
            {
                this.linecountField = value;
            }
        }
    }


}