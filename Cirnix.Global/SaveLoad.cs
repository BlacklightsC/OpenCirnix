using Newtonsoft.Json;
using System.IO;
using System.IO.Compression;
using System.Text;
using static Cirnix.Global.Globals;

namespace Cirnix.Global
{
    public class SaveLoad
    {
               
        public static void RootCheck(string str)
        {
            string path = $"{ResourcePath}\\{str}";
            if (!File.Exists(path))
                File.Create(path).Close();
        }

        
        public static T Load<T>(string name)
        {
            string path = $"{ResourcePath}\\{name}";
            if (!File.Exists(path)) return default;
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                using (FileStream file = File.OpenRead(path))
                using (GZipStream gzipStream = new GZipStream(file, CompressionMode.Decompress))
                {
                    int num;
                    do
                    {
                        byte[] array = new byte[200];
                        num = gzipStream.Read(array, 0, array.Length);
                        memoryStream.Write(array, 0, array.Length);
                    }
                    while (num >= 200);
                    string str = Encoding.UTF8.GetString(memoryStream.ToArray());
                    gzipStream.Close();
                    file.Close();
                    memoryStream.Close();
                    return JsonConvert.DeserializeObject<T>(str);
                }
            }
            catch
            {
                return default;
            }
        }

        
        public static void Save(string Name, object obj)
        {
            File.Delete($"{ResourcePath}\\{Name}");
            string s = JsonConvert.SerializeObject(obj);
            using (GZipStream gzipStream = new GZipStream(File.CreateText($"{ResourcePath}\\{Name}").BaseStream, CompressionMode.Compress))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(s);
                gzipStream.Write(bytes, 0, bytes.Length);
                gzipStream.Close();
            }
        }

    }
}
