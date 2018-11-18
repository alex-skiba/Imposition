using System.Collections.Generic;

namespace Albelli.Impose.DataModel.Output
{
    public class SourceFile
    {
        public string FileName { get; set; }
        public List<SourcePage> Pages { get; set; } = new List<SourcePage>();
    }
}