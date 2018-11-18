using System.IO;
using System.Xml.Serialization;
using Albumprinter.Plant.Xpresso.Xjf.XjfXml;

namespace Imposition.DAL
{
    public static class XpressoRepository
    {
        private static readonly string _untouchedXjfFileNameTempate = @"c:\Projects\Albumprinter\Files\Xpresso\Jobs\{0}.MoreUp.HP Scitex LX820.xjf";
        private static readonly string _workXjfFileNameTempate = @"c:\Projects\Albumprinter\Files\Xpresso\Jobs\modified\{0}.MoreUp.HP Scitex LX820.xjf";

        public static XpressoModel Get(int papCode)
        {
            return GetFromFile(string.Format(_workXjfFileNameTempate, papCode));
        }

        public static XpressoModel GetUntouched(int papCode)
        {
            return GetFromFile(string.Format(_untouchedXjfFileNameTempate, papCode));
        }

        public static void Save(XpressoModel xjf, int papCode)
        {
            var fileName = string.Format(_workXjfFileNameTempate, papCode);
            using (var writer = new StreamWriter(fileName))
            {
                var serializer = new XmlSerializer(typeof(XpressoModel));
                serializer.Serialize(writer, xjf);
            }
        }

        public static XpressoModel GetFromFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                var serializer = new XmlSerializer(typeof(XpressoModel));
                return (XpressoModel) serializer.Deserialize(reader);
            }
        }
    }
}