using System.IO;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.Logic.Contract;
using Newtonsoft.Json;

namespace Albelli.Impose.ToolApp.DAL
{
    public class LocalLayoutRepository : ILayoutRepository
    {
        private readonly string _storageFolderPath;

        public LocalLayoutRepository(string storageFolderPath)
        {
            _storageFolderPath = storageFolderPath;
        }

        public Layout Get(string key)
        {
            var layoutFileName = BuildLayoutFileName(key);
            var serialized = File.ReadAllText(layoutFileName);
            var layout = JsonConvert.DeserializeObject<Layout>(serialized);

            return layout;
        }

        public void Save(Layout layout)
        {
            var serialized = JsonConvert.SerializeObject(layout, Formatting.Indented);
            var layoutFileName = BuildLayoutFileName(layout.Key);
            File.WriteAllText(layoutFileName, serialized);
        }

        private string BuildLayoutFileName(string key)
        {
            var fileName = $"{key}.json";
            return Path.Combine(_storageFolderPath, fileName);
        }
    }
}