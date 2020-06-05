using System;
using System.IO;
using System.Text;

namespace Cirnix.Global
{
    public static class LogManager
    {
        public static void Write(string pContent)
        {
            Write(DateTime.Now.ToString(), pContent);
        }

        public static void Write(string pDate, string pContent)
        {
            object obj = new object();
            lock (obj)
            {
                using (StreamWriter writer = new StreamWriter("CirnixError.log", true, Encoding.UTF8))
                {
                    try
                    {
                        writer.WriteLine(pDate);
                        writer.WriteLine(pContent);
                    }
                    catch { }
                    //finally
                    //{
                    //    writer.Close();
                    //}
                }
            }
        }
    }
}

