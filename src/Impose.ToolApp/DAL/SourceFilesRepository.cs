using System.IO;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.DataModel.Output;
using Albelli.Impose.Logic.Contract;
using Albelli.Pdf;

namespace Albelli.Impose.ToolApp.DAL
{
    public class SourceFilesRepository : ISourceFilesRepository
    {
        private readonly string _storageFolderPath;

        public SourceFilesRepository(string storageFolderPath)
        {
            _storageFolderPath = storageFolderPath;
        }

        public SourceFile Get(int albumId)
        {
            var fileName = $"9999.{albumId}.0.pdf";
            var fullFilePath = Path.Combine(_storageFolderPath, fileName);
            var pdf = new PdfLibWrapper("W900205-010045-139339-E74DE2-79Q6F2");
            var sourcePdf = pdf.open_pdi_document(fullFilePath, string.Empty);
            var pagesCount = (int) pdf.pcos_get_number(sourcePdf, "length:pages");

            var file = new SourceFile {FileName = fullFilePath};

            for (var pageIndex = 0; pageIndex < pagesCount; pageIndex++)
            {
                file.Pages.Add(GetSourcePage(pdf, sourcePdf, pageIndex));
            }

            return file;
        }

        private static SourcePage GetSourcePage(PdfLibWrapper pdf, int sourcePdf, int pageIndex)
        {
            var pageWidth = (float) pdf.pcos_get_number(sourcePdf, $"pages[{pageIndex}]/width");
            var pageHeight = (float) pdf.pcos_get_number(sourcePdf, $"pages[{pageIndex}]/height");
            var rotationAngle = GetPageRotationAngle(pdf, sourcePdf, pageIndex);

            return new SourcePage
            {
                SheetSize = new Size {Width = pageWidth, Height = pageHeight},
                RotationAngle = rotationAngle,
                //MediaBox = ReadBox(pdf, sourcePdf, pageIndex, "MediaBox"),
                CropBox = ReadBox(pdf, sourcePdf, pageIndex, "CropBox"),
                Number = pageIndex + 1
            };
        }

        private static float GetPageRotationAngle(PdfLibWrapper pdf, int fileHandle, int page)
        {
            var objtype = pdf.pcos_get_string(fileHandle, $"type:pages[{page}]/Rotate");

            if (objtype == "number")
            {
                return (float) pdf.pcos_get_number(fileHandle, $"pages[{page}]/Rotate");
            }

            return 0.0f;
        }

        private static Box ReadBox(PdfLibWrapper pdf, int fileHandle, int page, string boxName)
        {
            var boxLeft = (float) pdf.pcos_get_number(fileHandle, $"pages[{page}]/{boxName}[0]");
            var boxBottom = (float) pdf.pcos_get_number(fileHandle, $"pages[{page}]/{boxName}[1]");
            var boxRight = (float) pdf.pcos_get_number(fileHandle, $"pages[{page}]/{boxName}[2]");
            var boxTop = (float) pdf.pcos_get_number(fileHandle, $"pages[{page}]/{boxName}[3]");
            var box = new Box {Left = boxLeft, Bottom = boxBottom, Width = boxRight - boxLeft, Height = boxTop - boxBottom};
            return box;
        }
    }
}