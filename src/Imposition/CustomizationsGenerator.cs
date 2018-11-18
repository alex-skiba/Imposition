using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Imposition.Model;

namespace Imposition
{
    public static class CustomizationsGenerator
    {
        // this method uses XJF data directly, use it only for reference
        public static string GetCustomizations(xpresso xjf)
        {
            var page = xjf.templates.pages.page;

            var xmlBuffer = new StringBuilder();
            using (var writer = new StringWriter(xmlBuffer))
            {
                var serializer = new XmlSerializer(typeof(xpressoTemplatesPagesPage));
                serializer.Serialize(writer, page);
            }

            var customizationsString = xmlBuffer.ToString();

            // some cleanup
            customizationsString =
                customizationsString.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", string.Empty);
            customizationsString = customizationsString.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", string.Empty);
            customizationsString = customizationsString.Replace("xpressoTemplatesPagesPage", "page");

            return customizationsString.Trim();
        }

        public static string GetCustomizations(Layout layout)
        {
            var pointsInInch = 72.0f;
            var xmlBuffer = new StringBuilder();

            using (var writer = new StringWriter(xmlBuffer))
            {
                var page = new xpressoTemplatesPagesPage
                {
                    index = 1,
                    picture = layout.Elements.Select(el => new xpressoTemplatesPagesPagePicture
                        {
                            //resource = el.Resource.FileName,
                            rotate = (byte) el.Rotate,
                            fitmethod = el.Type == ElementType.MeasureColorStrip ? "entire" : null,
                            // todo: apply DRY, the same code is written in XjfModifier
                            //data = $"{el.Left / pointsInInch:F1} {el.Bottom / pointsInInch:F1} {el.Width / pointsInInch:F1} {el.Height / pointsInInch:F1}"
                        })
                        .ToArray()
                };
                var serializer = new XmlSerializer(typeof(xpressoTemplatesPagesPage));
                serializer.Serialize(writer, page);
            }

            var customizationsString = xmlBuffer.ToString();

            // some cleanup
            customizationsString =
                customizationsString.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" ", string.Empty);
            customizationsString = customizationsString.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", string.Empty);
            customizationsString = customizationsString.Replace("xpressoTemplatesPagesPage", "page");

            return customizationsString.Trim();
        }
    }
}