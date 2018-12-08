using Albelli.Impose.DataModel.Common;

namespace Albelli.Impose.DataModel.Extensions
{
    public static class BoxExtensions
    {
        public static BoxTranslation GetTranslation(this Box baseBox, Box translatedBox)
        {
            return new BoxTranslation
            {
                LeftOffset = translatedBox.Left - baseBox.Left,
                BottomOffset = translatedBox.Bottom - baseBox.Bottom,
                RightOffset = translatedBox.Right - baseBox.Right,
                TopOffset = translatedBox.Top - baseBox.Top
            };
        }

        public static Box GetTranslated(this Box baseBox, BoxTranslation translation)
        {
            return new Box
            {
                Left = baseBox.Left + translation.LeftOffset,
                Bottom = baseBox.Bottom + translation.BottomOffset,
                Width = baseBox.Width - translation.LeftOffset + translation.RightOffset,
                Height = baseBox.Height - translation.BottomOffset + translation.TopOffset
            };
        }
    }
}