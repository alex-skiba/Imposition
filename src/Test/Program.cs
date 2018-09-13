using Imposition.DAL;
using Imposition.Model;
using SelectPdf;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var layouts = LayoutRepository.GetAll();

            foreach (var layout in layouts)
            {
                GeneratePdf(layout);
            }
        }

        private static void GeneratePdf(Layout layout)
        {
            var doc = new PdfDocument();
            var page = doc.AddPage(new PdfCustomPageSize(layout.SheetWidth, layout.SheetHeight), PdfMargins.Empty);

            foreach (var element in layout.Elements)
            {
                var tmp = new PdfDocument();

                PdfImageElement img1 = new PdfImageElement(element.Left, element.Bottom, element.Width, element.Resource.FileName.Replace("pdf", "png"));
                page.Add(img1);
            }

            string fileName = $"{layout.PapCode}.pdf";
            // save pdf document
            doc.Save(fileName);

            // close pdf document
            doc.Close();
        }
    }
}