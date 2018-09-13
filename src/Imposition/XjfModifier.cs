using System.Linq;
using Imposition.Model;

namespace Imposition
{
    public static class XjfModifier
    {
        private static readonly double pointsInInch = 72.0;

        public static xpresso AddMeasureColorStrip(xpresso xjf, Layout layoutWithColorStrip)
        {
            var colorStripCustomization = BuildColorStripCustomization(layoutWithColorStrip);

            var currentPictures = xjf.templates.pages.page.picture.ToList();
            currentPictures.Add(colorStripCustomization);
            xjf.templates.pages.page.picture = currentPictures.ToArray();

            return xjf;
        }

        private static xpressoTemplatesPagesPagePicture BuildColorStripCustomization(Layout layout)
        {
            var strip = layout.Elements.Single(e => e.Type == ElementType.MeasureColorStrip);
            return new xpressoTemplatesPagesPagePicture
            {
                // todo: apply DRY, the same code is written in CustomizationsGenerator
                data = $"{strip.Left / pointsInInch:F1} {strip.Bottom / pointsInInch:F1} {strip.Width / pointsInInch:F1} {strip.Height / pointsInInch:F1}",
                rotate = (byte) strip.Rotate,
                resource = strip.Resource.FileName,
                fitmethod = "entire"
            };
        }
    }
}