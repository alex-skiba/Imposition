using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Albelli.Impose.DataModel.Extensions;
using Albelli.Impose.DataModel.Output;
using Svg;
using Svg.Transforms;

namespace Albelli.Impose.ToolApp
{
    public class SvgGenerator
    {
        private readonly string _outputDirectory;

        public SvgGenerator(string outputDirectory)
        {
            _outputDirectory = outputDirectory;
        }

        public string Generate(OutputFile outputFile)
        {
            var outputFileName = $"{DateTime.Now:yyyyMMdd-HHmmss}_test.svg";
            var outputFilePath = Path.Combine(_outputDirectory, outputFileName);

            var svgText = BuildSvg(outputFile);
            File.WriteAllText(outputFilePath, svgText);

            return outputFilePath;
        }

        private string BuildSvg(OutputFile outputFile)
        {
            // NOTE! SVG coordinate system is from top to bottom, OutputFile (and PDF) is bottom to top.
            float YCoordinateConverter(float y)
            {
                return outputFile.SheetSize.Height - y;
            }

            const float margin = 10.0f;
            var svg = new SvgDocument
            {
                Width = outputFile.SheetSize.Width + margin * 2,
                Height = margin + (outputFile.SheetSize.Height + margin) * outputFile.Pages.Count
            };

            foreach (var page in outputFile.Pages.Select((p, i) => new {Page = p, Index = i}))
            {
                var sheetLocationX = 0.0f;
                var sheetLocationY = (outputFile.SheetSize.Height + margin) * page.Index;
                var sheetGroup = new SvgGroup
                {
                    // apply transform to the group to position all items inside the group relatively to its upper left corner
                    Transforms = {new SvgTranslate(sheetLocationX, sheetLocationY)}
                };

                var sheetRect = new SvgRectangle
                {
                    Width = outputFile.SheetSize.Width,
                    Height = outputFile.SheetSize.Height,
                    Stroke = new SvgColourServer(Color.Black),
                    Fill = new SvgColourServer(Color.White),
                    StrokeWidth = 3.0f,
                    X = margin,
                    Y = margin
                };
                sheetGroup.Children.Add(sheetRect);

                var tileRects = page.Page.Tiles.Select(t => BuildTileGroup(t, YCoordinateConverter)).ToList();

                tileRects.ForEach(tr => sheetGroup.Children.Add(tr));

                svg.Children.Add(sheetGroup);
            }

            using (var stream = new MemoryStream())
            {
                svg.Write(stream);
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }

        private SvgGroup BuildTileGroup(OutputTile tile, Func<float, float> yCoordinateConverter)
        {
            var tileGroup = new SvgGroup();
            var mediaBoxRect = new SvgRectangle
            {
                Width = tile.MediaBox.Width,
                Height = tile.MediaBox.Height,
                X = tile.MediaBox.Left,
                Y = yCoordinateConverter(tile.MediaBox.Top),
                Stroke = new SvgColourServer(Color.Magenta),
                Fill = new SvgColourServer(Color.White),
                StrokeWidth = 1.0f
            };

            var cutBoxRect = new SvgRectangle
            {
                Width = tile.CutBox.Width,
                Height = tile.CutBox.Height,
                X = tile.CutBox.Left,
                Y = yCoordinateConverter(tile.CutBox.Top),
                Stroke = new SvgColourServer(Color.Black),
                Fill = new SvgColourServer(Color.White),
                StrokeWidth = 1.0f
            };

            var pageNUmberFontSize = tile.CutBox.Height / 4.0f;
            var pageNumberText = new SvgText(tile.SourcePage.Number.ToString())
            {
                X = {tile.CutBox.GetCenter().X - 70.0f},
                Y = {yCoordinateConverter(tile.CutBox.GetCenter().Y - pageNUmberFontSize / 2.0f)},
                FontSize = pageNUmberFontSize,
                FontFamily = "Courier New",
                Transforms =
                {
                    new SvgRotate(tile.MediaRotationAngle,
                                  tile.CutBox.GetCenter().X,
                                  yCoordinateConverter(tile.CutBox.GetCenter().Y))
                }
            };
            var sourceFileText = new SvgText(Path.GetFileNameWithoutExtension(tile.SourceFilePath))
            {
                X = {tile.CutBox.Left + 50.0f},
                Y = {yCoordinateConverter(tile.CutBox.Bottom + 20)},
                FontSize = 24,
                FontFamily = "Courier New"
            };

            tileGroup.Children.Add(mediaBoxRect);
            tileGroup.Children.Add(cutBoxRect);
            tileGroup.Children.Add(pageNumberText);
            tileGroup.Children.Add(sourceFileText);

            return tileGroup;
        }
    }
}