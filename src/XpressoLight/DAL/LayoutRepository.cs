using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace XpressoLight.DAL
{
    public static class LayoutRepository
    {
        private static readonly string _storageFolderPath = @"..\..\..\..\Layouts\";
        // todo: take gloss, press, content/cover, PLF and spine into account when selecting layout

        public static List<Layout> GetAll()
        {
            var layouts = new List<Layout>();

            foreach (var file in Directory.EnumerateFiles(_storageFolderPath))
            {
                var serialized = File.ReadAllText(file);
                var layout = JsonConvert.DeserializeObject<Layout>(serialized);
                layouts.Add(layout);
            }

            return layouts;
        }

        public static void Save(Layout layout)
        {
            var storagePath = Path.Combine(_storageFolderPath, $"{layout.PapCode}.json");
            var serialized = JsonConvert.SerializeObject(layout, Formatting.Indented);
            File.WriteAllText(storagePath, serialized);
        }
    }
}