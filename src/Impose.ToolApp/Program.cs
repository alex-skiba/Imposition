using System.Collections.Generic;
using System.Diagnostics;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.Logic;
using Albelli.Impose.Logic.Engines;
using Albelli.Impose.Logic.Validation;
using Albelli.Impose.ToolApp.DAL;
using Albelli.Impose.XpressoAdapter;

namespace Albelli.Impose.ToolApp
{
    internal class Program
    {
        private const string ImpositionsDir = @"c:\Work\Projects\PL-Imposition\data\Impositions\";
        private const string LayoutsDir = @"c:\Work\Projects\PL-Imposition\data\Layouts\";
        private const string SourceFilesDir = @"c:\Work\Projects\PL-Imposition\data\Mockups\";
        private const string OutputDir = @"c:\Work\Projects\PL-Imposition\data\Output\";

        private static void Main(string[] args)
        {
            //GeneratePap402Data();
            RunFullCycle();
            //Console.ReadKey();
        }

        private static void GeneratePap402Data()
        {
            var layoutRepo = new LocalLayoutRepository(LayoutsDir);
            var impositionRepo = new LocalImpositionRepository(ImpositionsDir);
            layoutRepo.Save(Pap402LayoutGenerator.Generate());
            impositionRepo.Save(Pap402ImpositionGenerator.Generate());
        }

        private static void RunFullCycle()
        {
            var imposer = BuildImposer();
            var outputFile = imposer.Impose(new BatchMetadata
            {
                LayoutKey = "pap_402_layout",
                ImpositionKey = "pap_402_imposition",
                AlbumIds = new List<int> {20328, 20199, 20198}
            });

            var pdfFileName = new PdfGenerator(OutputDir).Generate(outputFile);
            var svgFileName = new SvgGenerator(OutputDir).Generate(outputFile);
            var txtFileName = new TextVisualizer(OutputDir).Generate(outputFile);
            Process.Start(svgFileName);
        }

        private static Imposer BuildImposer()
        {
            var layoutRepo = new LocalLayoutRepository(LayoutsDir);
            var impositionRepo = new LocalImpositionRepository(ImpositionsDir);
            var sourceFilesRepo = new SourceFilesRepository(SourceFilesDir);
            var validator = new Validator();
            var imposer = new Imposer(layoutRepo, impositionRepo, sourceFilesRepo, new OutputFileBuilderFactory(), validator);
            return imposer;
        }
    }
}