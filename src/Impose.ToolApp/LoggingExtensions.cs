using Albelli.Impose.DataModel.Input;

namespace Albelli.Impose.ToolApp
{
    public static class LoggingExtensions
    {
        public static string AsString(this Layout layout)
        {
            return $"pap_{layout.PapCode}";
        }

        public static string AsString(this Box box)
        {
            return $"{box.Left} {box.Bottom} {box.Width} {box.Height}";
        }

        public static string AsString(this Size size)
        {
            return $"{size.Width} {size.Height}";
        }
    }
}