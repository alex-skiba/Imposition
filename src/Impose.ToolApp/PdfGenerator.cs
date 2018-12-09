using System;
using System.IO;
using System.Text;
using Albelli.Impose.DataModel.Common;
using Albelli.Impose.DataModel.Extensions;
using Albelli.Impose.DataModel.Output;
using Albelli.Impose.Logic.Contract;
using Albelli.Pdf;

namespace Albelli.Impose.ToolApp
{
    public class PdfGenerator : IOutputGenerator
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
                    // "pdiusebox=media" means that all content of the source pdf will be used, not only visible part (crop box), see pdflib api reference
                    var sourcePage = pdf.open_pdi_page(sourcePdf, tile.SourcePage.Number, "pdiusebox=media");

                    var matchboxString = BuildPdfMatchboxString(tile.MediaBox, tile.CutBox, tile.SourcePage.CropBox);
                    var orientationString = BuildPdfOrientationString(tile.MediaRotationAngle);
                    var boxsizeString = BuildPdfBoxsizeString(tile.MediaBox);
                    var fitmethodString = "fitmethod=clip"; // will cut everything that overflows fitbox boundaries
                    var tilePlacementOptions = $"{matchboxString} {boxsizeString} {orientationString} {fitmethodString}";

                    pdf.fit_pdi_page(sourcePage, tile.MediaBox.Left, tile.MediaBox.Bottom, tilePlacementOptions);

                    // todo: tech info
                    var font = pdf.load_font("Helvetica", "unicode", "");
                    pdf.setfont(font, 20);
                    pdf.fit_textline(matchboxString, tile.MediaBox.Left + 40, tile.MediaBox.Bottom + 30, string.Empty);

                    pdf.close_pdi_page(sourcePage);
                }

                pdf.end_page_ext(string.Empty);
            }
        }

        /// <summary>
        ///     Returns the string that describes what area of the source pdf page should be placed on the output pdf page.
        ///     See pdflib `matchbox` reference for details.
        ///     Format of the string is `matchbox={ clipping={ left bottom right top } }`
        /// </summary>
        private static string BuildPdfMatchboxString(Box outputMediaBox, Box outputCutBox, Box sourceCropBox)
        {
            var translation = outputCutBox.GetTranslation(outputMediaBox);
            var sourceMatchBox = sourceCropBox.GetTranslated(translation);
            var matchboxString = $"matchbox={{ clipping={{ {sourceMatchBox.Left} {sourceMatchBox.Bottom} {sourceMatchBox.Right} {sourceMatchBox.Top} }} }}";
            return matchboxString;
        }

        private static string BuildPdfOrientationString(float rotationAngle)
        {
            string orientationFromAngle;

            switch (rotationAngle)
            {
                case 0:
                    orientationFromAngle = "north";
                    break;
                case 90:
                    orientationFromAngle = "east";
                    break;
                case 180:
                    orientationFromAngle = "south";
                    break;
                case 270:
                    orientationFromAngle = "west";
                    break;
                default:
                    throw new ArgumentException($"Cannot convert angle {rotationAngle} to orientation");
            }

            return $"orientate={orientationFromAngle}";
        }

        /// <summary>
        ///     Returns the string that defines the size of the area in output pdf file that will contain a tile.
        ///     See pdflib `fitbox` reference for details.
        /// </summary>
        private static string BuildPdfBoxsizeString(Box outputTileMediaBox)
        {
            return $"boxsize={{{outputTileMediaBox.Width} {outputTileMediaBox.Height}}}";
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