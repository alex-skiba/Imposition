using System.Linq;
using Albelli.Impose.DataModel.Input;

namespace Albelli.Impose.DataModel.Extensions
{
    public static class LayoutExtensions
    {
        public static int LastRowIndex(this Layout layout)
        {
            return layout.Tiles.Max(t => t.RowIndex);
        }

        public static int LastColumnIndex(this Layout layout)
        {
            return layout.Tiles.Max(t => t.ColumnIndex);
        }
    }
}