using System;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cirnix.Global
{
    public class SaveLoad
    {
        public static void RootCheck(string str)
        {
            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }
            if (!File.Exists("Data/" + str))
            {
                File.Create("Data/" + str).Close();
            }
        }

        public static T Load<T>(string Name)
        {
            RootCheck(Name);
            T result;
            try
            {
                MemoryStream memoryStream = new MemoryStream();
                GZipStream gzipStream = new GZipStream(File.OpenRead("Data/" + Name), CompressionMode.Decompress);
                int num;
                do
                {
                    byte[] array = new byte[200];
                    num = gzipStream.Read(array, 0, array.Length);
                    memoryStream.Write(array, 0, array.Length);
                }
                while (num >= 200);
                string @string = Encoding.UTF8.GetString(memoryStream.ToArray());
                gzipStream.Close();
                result = JsonConvert.DeserializeObject<T>(@string);
            }
            catch
            {
                result = default(T);
            }
            return result;
        }

        public static void Save(string Name, object obj)
        {
            RootCheck(Name);
            File.Delete("Data/" + Name);
            string s = JsonConvert.SerializeObject(obj);
            GZipStream gzipStream = new GZipStream(File.CreateText("Data/" + Name).BaseStream, CompressionMode.Compress);
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            gzipStream.Write(bytes, 0, bytes.Length);
            gzipStream.Close();
        }

        private const string Root = "Data";

    
    }
}
