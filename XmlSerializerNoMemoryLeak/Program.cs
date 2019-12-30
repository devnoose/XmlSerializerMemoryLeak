using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlSerializerNoMemoryLeak
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = Guid.NewGuid();
            while (true)
            {
                var s = XmlSerializerCache.Create(typeof(object), key.ToString());
                s.Serialize(Stream.Null, new object { });
            }
        }
    }

    public static class XmlSerializerCache
    {
        private static readonly Dictionary<string, System.Xml.Serialization.XmlSerializer> Cache =
            new Dictionary<string, System.Xml.Serialization.XmlSerializer>();

        public static System.Xml.Serialization.XmlSerializer Create(Type type, string key)
        {

            if (!Cache.ContainsKey(key))
            {
                Cache.Add(key, new System.Xml.Serialization.XmlSerializer(type, new Type[] { }));
            }

            return Cache[key];
        }
    }
}
