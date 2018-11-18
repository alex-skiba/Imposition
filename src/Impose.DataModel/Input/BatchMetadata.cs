using System.Collections.Generic;

namespace Albelli.Impose.DataModel.Input
{
    public class BatchMetadata
    {
        public List<int> AlbumIds { get; set; }
        public string LayoutKey { get; set; }
        public string ImpositionKey { get; set; }
    }
}