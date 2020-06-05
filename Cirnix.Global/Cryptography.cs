using System.Text;
using System.Security.Cryptography;

namespace Cirnix.Global
{
    public static class Cryptography
    {
        private static string HashToString(byte[] Hash)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in Hash)
                stringBuilder.AppendFormat("{0:x2}", b);
            return stringBuilder.ToString();
        }


        public static string HashToMD5(string Data)
        {
            using (var MD5 = new MD5CryptoServiceProvider())
                return HashToString(MD5.ComputeHash(Encoding.UTF8.GetBytes(Data)));
        }

        // SHA256 256bit 암호화
        public static string HashToSHA256(string Data)
        {
            using (var SHA256 = new SHA256Managed())
                return HashToString(SHA256.ComputeHash(Encoding.UTF8.GetBytes(Data)));
        }

        // SHA 384
        public static string HashToSHA384(string Data)
        {
            using (var SHA384 = new SHA384Managed())
                return HashToString(SHA384.ComputeHash(Encoding.UTF8.GetBytes(Data)));
        }

        //SHA512 512bit 암호화
        public static string HashToSHA512(string Data)
        {
            using (var SHA512 = new SHA512Managed())
                return HashToString(SHA512.ComputeHash(Encoding.UTF8.GetBytes(Data)));
        }
    }
}
