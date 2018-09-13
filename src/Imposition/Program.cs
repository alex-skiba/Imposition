using System;
using System.IO;
using System.Linq;
using Imposition.DAL;

namespace Imposition
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                CreateLayoutsWithColorStripFromXjf();
                AddPressviewToXjfsFromLayouts();
                SaveCustomizationsFromXjfs();

                Console.WriteLine("Done!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            Console.ReadKey();
        }

        // gets XJF files, downloaded by Xpresso, generates layouts
        // for each layout adds vendor logo element from XJF and creates new Pressview (measure color strip) element from hardcoded values
        private static void CreateLayoutsWithColorStripFromXjf()
        {
            var codes = new[] {403, 404, 405, 408, 409, 410, 411, 412, 413, 414, 415, 417, 418, 420, 421, 422, 423, 424, 425, 426, 427, 428};

            foreach (var code in codes)
            {
                var xjf = XjfRepository.GetUntouched(code);
                var layout = LayoutGenerator.BuildFromXjf(code, xjf);
                LayoutRepository.Save(layout);
            }
        }

        // takes existing XJF files, adds there Pressview (measure color strip) from existing layout and saves modified XJF file to a separate place
        // pretty useless method, must be replaced with something based on CustomizationsGenerator
        private static void AddPressviewToXjfsFromLayouts()
        {
            var layouts = LayoutRepository.GetAll();

            foreach (var layout in layouts)
            {
                var xjf = XjfRepository.GetUntouched(layout.PapCode);
                xjf = XjfModifier.AddMeasureColorStrip(xjf, layout);
                XjfRepository.Save(xjf, layout.PapCode);
            }
        }

        // creates a file with input for a SQL script that replaces customizations
        private static void SaveCustomizationsFromXjfs()
        {
            var codes = new[] {403, 404, 405, 408, 409, 410, 411, 412, 413, 414, 415, 417, 418, 420, 421, 422, 423, 424, 425, 426, 427, 428};
            var customizationsFilename = @"c:\Projects\Albumprinter\Files\Xpresso\Customizations\PressView.txt";
            var layouts = LayoutRepository.GetAll();

            if (File.Exists(customizationsFilename))
            {
                File.Delete(customizationsFilename);
            }

            var lines = codes.Select(code =>
                {
                    //var xjf = XjfRepository.Get(code);
                    //var customization = CustomizationsGenerator.GetCustomizations(xjf);
                    var customization = CustomizationsGenerator.GetCustomizations(layouts.Single(l => l.PapCode == code));
                    return $"('pap_{code}','{customization}')";
                })
                .ToArray();

            var customizationsToSave = string.Join($",{Environment.NewLine}", lines);

            File.WriteAllText(customizationsFilename, customizationsToSave);
        }
    }
}