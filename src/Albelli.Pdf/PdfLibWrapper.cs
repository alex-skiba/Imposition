using PDFlib_dotnet;

namespace Albelli.Pdf
{
    // todo: composition instead of inheritance
    public class PdfLibWrapper : PDFlib
    {
        public PdfLibWrapper(string license)
        {
            if (!string.IsNullOrEmpty(license))
            {
                set_parameter("license", license);
            }
        }
    }
}