using System.IO;
using System.Text;
using System.Xml;
using YAXLib;

namespace Calculator.Configurations
{
    public static class Serializer
    {
        private static readonly XmlReaderSettings readerSettings = new XmlReaderSettings();

        private static readonly XmlWriterSettings writerSettings = new XmlWriterSettings
        {
            Encoding = Encoding.UTF8,
            Indent = true,
            NamespaceHandling = NamespaceHandling.OmitDuplicates
        };


        public static T Deserialize<T>(string xml) where T : class
        {
            var serializer = new YAXSerializer(typeof(T));

            using (XmlReader reader = XmlReader.Create(new StringReader(xml), readerSettings))
            {
                return serializer.Deserialize(reader) as T;
            }
        }

        public static string Serialize<T>(T obj) where T : class
        {
            var serializer = new YAXSerializer(typeof(T));

            using (var stringWriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(stringWriter, writerSettings))
                {
                    serializer.Serialize(obj, writer);
                }

                return stringWriter.ToString();
            }
        }
    }
}
