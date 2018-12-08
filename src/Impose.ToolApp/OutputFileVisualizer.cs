using System.Text;
using Albelli.Impose.DataModel.Output;

namespace Albelli.Impose.ToolApp
{
    public class OutputFileVisualizer
    {
        public static string Visualize(OutputFile outputFile)
        {
            var output = new StringBuilder();

            foreach (var page in outputFile.Pages)
            {
                for (var rowIndex = 0; rowIndex < page.RowsCount; rowIndex++)
                {
                    for (var colIndex = 0; colIndex < page.ColumnsCount; colIndex++)
                    {
                        var tile = page.Tiles[rowIndex, colIndex];
                        output.Append($"|{tile.SourcePage:D4}");
                    }
                    output.AppendLine("|");
                }

                output.AppendLine("---");
            }

            return output.ToString();
        }
    }
}