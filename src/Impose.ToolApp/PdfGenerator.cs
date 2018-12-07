using System;
using System.IO;
using System.Text;
using Albelli.Impose.DataModel.Output;
using Albelli.Impose.Logic.Contract;
using Albelli.Pdf;

namespace Albelli.Impose.ToolApp
{
    public class PdfGenerator : IPdfGenerator
    {
        private readonly string _outputDirectory;

        public PdfGenerator(string outputDirectory)
        {
            _outputDirectory = outputDirectory;
        }

        public string Generate(OutputFile outputFile)
        {
            var outputFileName = $"{DateTime.Now:yyyyMMdd-HHmmss}_test.pdf";
            var outputFilePath = Path.Combine(_outputDirectory, outputFileName);
            var pdf = new PdfLibWrapper("W900205-010045-139339-E74DE2-79Q6F2");
            InitializeLikeXpresso(pdf, outputFilePath);

            BuildPdf(pdf, outputFile);

            pdf.end_document(string.Empty);

            return outputFilePath;
        }

        private static void BuildPdf(PdfLibWrapper pdf, OutputFile outputFile)
        {
            foreach (var outputPage in outputFile.Pages)
            {
                pdf.begin_page_ext(outputFile.SheetSize.Width, outputFile.SheetSize.Height, string.Empty);

                foreach (var tile in outputPage.Tiles)
                {
                    var sourcePdf = pdf.open_pdi_document(tile.SourceFilePath, string.Empty);
                    // open source pdf and use all its content (not only visible part), see pdflib api reference
                    var sourcePage = pdf.open_pdi_page(sourcePdf, tile.SourcePageNumber, "pdiusebox=media");
                    // todo: use source file cropbox to clip tile content with bleed.
                    // in current implementation it places one visible source page twice
                    var orientation = GetOrientationFromAngle(tile.MediaRotationAngle);
                    var tilePlacementOptions = $"boxsize={{{tile.MediaBox.Width} {tile.MediaBox.Height}}} orientate={orientation} fitmethod=clip";
                    pdf.fit_pdi_page(sourcePage, tile.MediaBox.Left, tile.MediaBox.Bottom, tilePlacementOptions);
                    pdf.close_pdi_page(sourcePage);
                }

                pdf.end_page_ext(string.Empty);
            }
        }

        private static string GetOrientationFromAngle(float rotationAngle)
        {
            switch (rotationAngle)
            {
                case 0:
                    return "north";
                case 90:
                    return "east";
                case 180:
                    return "south";
                case 270:
                    return "west";
                default:
                    throw new ArgumentException($"Cannot convert angle {rotationAngle} to orientation");
            }
        }

        private static void InitializeLikeXpresso(PdfLibWrapper pdf, string pdfFileName)
        {
            var options = new StringBuilder();
            options.Append("compatibility={1.5}");
            options.Append(" inmemory=false");
            options.Append(" linearize=true");
            options.Append(" optimize=true");
            options.Append(" viewerpreferences={hidemenubar=false hidetoolbar=false hidewindowui=false}");
            options.Append(" destination {type fitwindow page 1}");

            var createDocumentResult = pdf.begin_document(pdfFileName, options.ToString());
            if (createDocumentResult != 1)
            {
                throw new Exception($"PDFLib failed to create file '{pdfFileName}'");
            }

            pdf.create_gstate("blendmode=Normal opacityfill=1 opacitystroke=1 overprintmode=1 renderingintent=RelativeColorimetric");

            pdf.set_info("Creator", "Xpresso [http://www.albelli.com]");
            pdf.set_info("Title", "XpressoLight");
        }
    }
}