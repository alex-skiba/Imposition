﻿using System;
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
                    var sourcePage = pdf.open_pdi_page(sourcePdf, tile.SourcePageNumber, string.Empty);
                    pdf.fit_pdi_page(sourcePage, tile.MediaBox.Left, tile.MediaBox.Bottom, $"boxsize={{{tile.MediaBox.Width} {tile.MediaBox.Height}}} fitmethod=entire");
                    pdf.close_pdi_page(sourcePage);
                }

                pdf.end_page_ext(string.Empty);
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