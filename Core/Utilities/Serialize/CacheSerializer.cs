using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Serialize
{
    public static class CacheSerializer
    {
        public static byte[] Serialize(object o)
        {
            if (o == null)
            {
                return null;
            }
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, o);
                byte[] objectDataAsStream = memoryStream.ToArray();
                return objectDataAsStream;
            }
        }

        public static T Deserialize<T>(byte[] stream)
        {
            if (stream == null)
            {
                return default(T);
            }
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (MemoryStream memoryStream = new MemoryStream(stream))
            {
                T result = (T)binaryFormatter.Deserialize(memoryStream);
                return result;
            }
        }
    }
}
