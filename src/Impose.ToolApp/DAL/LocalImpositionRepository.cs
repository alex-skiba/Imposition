using System.IO;
using Albelli.Impose.DataModel.Input;
using Albelli.Impose.Logic.Contract;
using Newtonsoft.Json;

namespace Albelli.Impose.ToolApp.DAL
{
    public class LocalImpositionRepository : IImpositionRepository
    {
        private readonly string _storageFolderPath;

        public LocalImpositionRepository(string storageFolderPath)
        {
            _storageFolderPath = storageFolderPath;
        }

        public Imposition Get(string key)
        {
            var impositionFileName = BuildImpositionFileName(key);
            var serialized = File.ReadAllText(impositionFileName);
            var imposition = JsonConvert.DeserializeObject<Imposition>(serialized);

            return imposition;
        }

        public void Save(Imposition imposition)
        {
            var serialized = JsonConvert.SerializeObject(imposition, Formatting.Indented);
            var impositionFileName = BuildImpositionFileName(imposition.Key);
            File.WriteAllText(impositionFileName, serialized);
        }

        private string BuildImpositionFileName(string key)
        {
            var fileName = $"{key}.json";
            return Path.Combine(_storageFolderPath, fileName);
        }
    }
}