using System;
using System.Drawing;
using System.Linq;
using System.Text;
using Albelli.Pdf;
using PDFlib_dotnet;
using XpressoLight.DAL;

namespace XpressoLight
{
    class Program
    {
        static void Main(string[] args)
        {
            var pdfFileName = "test.pdf";
            var pdf = new PdfLibWrapper("W900205-010045-139339-E74DE2-79Q6F2");
            Initialize(pdf, pdfFileName);

            //DrawTestPage(pdf);
            //DrawSourcePdf(pdf);
            //DrawBarcode(pdf);
            GeneratePap720Pdf(pdf);

            pdf.end_document(string.Empty);

            Console.WriteLine("Done");
            Console.ReadKey();
        }

        private static void GeneratePap720Pdf(PdfLibWrapper pdf)
        {
            var sourceFilePath = @"base_source.pdf";
            var layout = LayoutRepository.GetAll().Single(l => l.PapCode == 720);

            pdf.begin_page_ext(layout.SheetWidth, layout.SheetHeight, string.Empty);

            foreach (var page in layout.Pages)
            {
                var sourcePdf = pdf.open_pdi_document(sourceFilePath, string.Empty);

                var pdfPage = pdf.open_pdi_page(sourcePdf, 1, "");
                // todo: move mirroring setting to Layout
                pdf.fit_pdi_page(pdfPage, 0, 0, $"boxsize={{{page.Width} {page.Height}}} fitmethod=meet scale={{-1 1}}");
                pdf.close_pdi_page(pdfPage);

                foreach (var pageElement in page.Elements)
                {
                    pdf.setcolor("stroke", "rgb", 1.0, 1.0, 0.0, 0.0);
                    pdf.rect(pageElement.Left, pageElement.Bottom, pageElement.Width, pageElement.Height);
                    pdf.stroke();

                    var fontHandle = pdf.load_font(pageElement.Resource.FontName, "unicode", "errorpolicy=return");
                    pdf.setfont(fontHandle, pageElement.Resource.FontSize);
                    pdf.fit_textline(
                        pageElement.Resource.FileName,
                        pageElement.Left,
                        pageElement.Bottom,
                        string.Empty);
                }
            }

            pdf.end_page_ext(string.Empty);
        }

        private static void DrawBarcode(PdfLibWrapper pdf)
        {
            pdf.begin_page_ext(500, 500, string.Empty);

            var fontHandle = pdf.load_font("Code-39-20", "unicode", "embedding=true errorpolicy=return");
            pdf.setfont(fontHandle, 20);
            pdf.fit_textline(
                "*X01882E2*",
                20,
                20,
                string.Empty);

            pdf.end_page_ext(string.Empty);
        }

        private static void DrawSourcePdf(PdfLibWrapper pdf)
        {
            var sourcePdf = pdf.open_pdi_document("base_source.pdf", string.Empty);
            var pagesCount = pdf.pcos_get_number(sourcePdf, "length:pages");

            Console.WriteLine($"Pages count in source pdf: {pagesCount}");

            for (var pageNumber = 1; pageNumber <= pagesCount; pageNumber++)
            {
                var page = pdf.open_pdi_page(sourcePdf, pageNumber, "");

                pdf.begin_page_ext(500, 500, string.Empty);
                pdf.setcolor("stroke", "rgb", 1.0, 0.0, 0.0, 0.0);
                pdf.rect(5, 5, 490, 490);
                pdf.stroke();
                pdf.fit_pdi_page(page, 10, 10, "boxsize={480 480} fitmethod=entire");
                pdf.close_pdi_page(page);
                pdf.end_page_ext(string.Empty);
            }
        }

        private static void DrawTestPage(PdfLibWrapper pdf)
        {
            pdf.begin_page_ext(500, 500, string.Empty);
            pdf.setcolor("stroke", "rgb", 1.0, 0.0, 0.0, 0.0);
            pdf.rect(5, 5, 490, 490);
            pdf.stroke();
            pdf.end_page_ext(string.Empty);
        }

        private static void Initialize(PdfLibWrapper pdf, string pdfFileName)
        {
            var options = new StringBuilder();
            options.Append("compatibility={1.5}");
            options.Append(" inmemory=false");
            options.Append(" linearize=true");
            options.Append(" optimize=true");
            options.Append(" viewerpreferences={hidemenubar=false hidetoolbar=false hidewindowui=false}");
            options.Append(" destination {type fitwindow page 1}");
            options.Append($"");
            options.Append($"");

            var createDocumentResult = pdf.begin_document(pdfFileName, options.ToString());
            if (createDocumentResult != 1)
            {
                throw new Exception($"PDFLib failed to create file '{pdfFileName}'");
            }

            var defaultExtGState = pdf.create_gstate("blendmode=Normal opacityfill=1 opacitystroke=1 overprintmode=1 renderingintent=RelativeColorimetric");

            pdf.set_info("Creator", "Xpresso [http://www.albelli.com]");
            pdf.set_info("Title", "XpressoLight");
        }

        public static void DrawFilledBox(PdfLibWrapper pdf, double left, double bottom, double width, double height, Color color)
        {
            pdf.setcolor("fill", color.PdfColorSpace(), color.R / 255.0, color.G / 255.0, color.B / 255.0, 0);
            pdf.rect(left, bottom, width, height);
            pdf.fill();
        }
    }

    public static class ColorExt
    {
        public static string PdfColorSpace(this Color self)
        {
            return self.R == self.G && self.G == self.B ? "gray" : "rgb";
        }
    }
}
