using System.Collections.Generic;
using System.Linq;
using Imposition.Model;
using Layout = Imposition.Model.Layout;

namespace Imposition.LayoutGeneration
{
    public class CanvasGenerator
    {
        public static Layout BuildFromXjf(int papCode, xpresso xjf)
        {
            var layout = BuildEmptyLayout(xjf, papCode);
            layout.Elements.Add(BuildColorStripElement(layout));
            layout.Elements.Add(BuildVendorLogoElement(xjf));
            return layout;
        }

        private static Layout BuildEmptyLayout(xpresso xjf, int papCode)
        {
            var separator = new[] {' '};
            // todo: check if we can always assume Points as size units
            var sheetWidthPoints = float.Parse(xjf.job.layout.size.Split(separator)[0]);
            var sheetHeightPoints = float.Parse(xjf.job.layout.size.Split(separator)[1]);

            return new Layout
            {
                PapCode = papCode,
                SheetHeight = sheetHeightPoints,
                SheetWidth = sheetWidthPoints,
                Elements = new List<Element>()
            };
        }

        private static Element BuildVendorLogoElement(xpresso xjf)
        {
            var pointsInInch = 72.0f;
            var vendorElement = xjf.templates.pages.page.picture.Single(pic => pic.resource == "{vendorid}.jpg");
            var separator = new[] {' '};
            var locationData = vendorElement.data.Split(separator);

            var leftPoints = float.Parse(locationData[0]) * pointsInInch;
            var bottomPoints = float.Parse(locationData[1]) * pointsInInch;
            var widthPoints = float.Parse(locationData[2]) * pointsInInch;
            var heightPoints = float.Parse(locationData[3]) * pointsInInch;

            return new Element
            {
                Type = ElementType.VendorLogo,
                //Left = leftPoints,
                //Bottom = bottomPoints,
                //Height = heightPoints,
                //Width = widthPoints,
                Rotate = vendorElement.rotate
            };
        }

        private static Element BuildColorStripElement(Layout layout)
        {
            var sheetHeightPoints = layout.SheetHeight;
            // carefully handpicked values. adjusted to look good after Xpresso does its magic (size must be 180x10 mm).
            var stripWidthPoints = 79.0f;
            var stripHeightPoints = 531.0f;

            var stripCenterYPoints = sheetHeightPoints / 2.0f;
            var stripBottomPoint = stripCenterYPoints - stripHeightPoints / 2.0f;

            return new Element
            {
                //Type = ElementType.MeasureColorStrip,
                //Resource = new ElementResource
                //{
                //    Name = "Pressview MeasureColor Strip",
                //    FileName = "ColorStrip.pdf"
                //},
                //Left = 0,
                //Bottom = stripBottomPoint,
                //Height = stripHeightPoints,
                //Width = stripWidthPoints,
                Rotate = 0
            };
        }
    }
}