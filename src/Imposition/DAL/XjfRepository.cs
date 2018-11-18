using System.IO;
using System.Xml.Serialization;
using Imposition.Model;

namespace Imposition.DAL
{
    public static class XjfRepository
    {
        private static readonly string _untouchedXjfFileNameTempate = @"c:\Projects\Albumprinter\Files\Xpresso\Jobs\{0}.MoreUp.HP Scitex LX820.xjf";
        private static readonly string _workXjfFileNameTempate = @"c:\Projects\Albumprinter\Files\Xpresso\Jobs\modified\{0}.MoreUp.HP Scitex LX820.xjf";

        public static xpresso Get(int papCode)
        {
            return GetFromFile(string.Format(_workXjfFileNameTempate, papCode));
        }

        public static xpresso GetUntouched(int papCode)
        {
            return GetFromFile(string.Format(_untouchedXjfFileNameTempate, papCode));
        }

        public static void Save(xpresso xjf, int papCode)
        {
            var fileName = string.Format(_workXjfFileNameTempate, papCode);
            using (var writer = new StreamWriter(fileName))
            {
                var serializer = new XmlSerializer(typeof(xpresso));
                serializer.Serialize(writer, xjf);
            }
        }

        public static xpresso GetFromFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                var serializer = new XmlSerializer(typeof(xpresso));
                return (xpresso) serializer.Deserialize(reader);
            }
        }
    }
}