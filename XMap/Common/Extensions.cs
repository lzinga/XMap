using System.IO;
using System.Xml.Serialization;

namespace XMap.Common
{
    public static class Extensions
    {
        /// <summary>
        /// Serialize the object into a string.
        /// </summary>
        public static string Serialize<T>(this T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, obj);
                return textWriter.ToString();
            }
        }

        /// <summary>
        /// Deserializes string into object.
        /// </summary>
        public static T Deserialize<T>(this string data)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StringReader(data))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
    }
}
