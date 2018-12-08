using System.Collections.Generic;
using Albelli.Impose.DataModel.Common;
using Albelli.Impose.DataModel.Input;

namespace Albelli.Impose.DataModel.Output
{
    public class OutputFile
    {
        public Size SheetSize { get; set; }

        public IReadOnlyList<OutputPage> Pages { get; set; }

        public bool IsDuplex { get; set; }

        public int SheetsCount => IsDuplex ? Pages.Count / 2 : Pages.Count;
    }
}