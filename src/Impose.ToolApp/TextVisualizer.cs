using System.IO;
using System.Text;
using Albelli.Impose.DataModel.Output;
using Albelli.Impose.Logic.Contract;

namespace Albelli.Impose.ToolApp
{
    public class TextVisualizer : IOutputGenerator
    {
        private readonly string _outputDirectory;

        public TextVisualizer(string outputDirectory)
        {
            _outputDirectory = outputDirectory;
        }

        public string Generate(OutputFile outputFile)
        {
            var outputFileName = "visual.txt";
            var outputFilePath = Path.Combine(_outputDirectory, outputFileName);

            var output = new StringBuilder();

            foreach (var page in outputFile.Pages)
            {
                for (var rowIndex = 0; rowIndex < page.RowsCount; rowIndex++)
                {
                    for (var colIndex = 0; colIndex < page.ColumnsCount; colIndex++)
                    {
                        var tile = page.Tiles[rowIndex, colIndex];
                        output.Append($"|{tile.SourcePage.Number:D4}");
                    }

                    output.AppendLine("|");
                }

                output.AppendLine("---");
            }

            File.WriteAllText(outputFilePath, output.ToString());

            return outputFilePath;
        }
    }
}