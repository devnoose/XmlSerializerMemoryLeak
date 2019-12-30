using System;
using System.IO;
using System.Xml.Serialization;

namespace XmlSerializerMemoryLeak
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var s = new XmlSerializer(typeof(object), new Type[] { });
                s.Serialize(Stream.Null, new object { });
            }
        }
    }
}
