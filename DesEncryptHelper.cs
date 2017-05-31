using System;
using System.Security.Cryptography;
using System.Text;

namespace SyUtilsCore
{
    public static class DesEncryptHelper
    {
        static readonly byte[] KEY;
        static readonly byte[] IV;

        static DesEncryptHelper()
        {
            KEY = Convert.FromBase64String("EWvbJ4V9q6yB6yRMUWA0R+QTg5GuLn7g");
            IV = Convert.FromBase64String("YJgyPDx2F2I=");
        }

        public static string Decrypt(string text)
        {
            string result = string.Empty;
            byte[] inputByteArray = Convert.FromBase64String(text);
            using (TripleDES des = TripleDES.Create())
            {
                des.Key = KEY;
                des.IV = IV;
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                    }
                    result = Encoding.UTF8.GetString(ms.ToArray());
                }
            }
            return result;
        }

        public static string Encrypt(string text)
        {
            string result = string.Empty;
            using (TripleDES des = TripleDES.Create())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(text);
                des.Key = KEY;
                des.IV = IV;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                    }
                    result = Convert.ToBase64String(ms.ToArray());
                }
            }
            return result;
        }

        public static string HexToString(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public static byte[] StringToHex(string src)
        {
            return Convert.FromBase64String(src);
        }
    }
}