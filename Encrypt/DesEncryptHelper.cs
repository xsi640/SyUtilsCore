using System;
using System.Security.Cryptography;
using System.Text;

namespace SyUtilsCore
{
    public static class DesEncryptHelper
    {
        private static byte[] _KEY;
        private static byte[] _IV;

        static DesEncryptHelper()
        {
            KEY = Convert.FromBase64String("EWvbJ4V9q6yB6yRMUWA0R+QTg5GuLn7g");
            IV = Convert.FromBase64String("YJgyPDx2F2I=");
        }

        public static byte[] KEY
        {
            get => _KEY;
            set => _KEY = value;
        }
        public static byte[] IV
        {
            get => _IV;
            set => _IV = value;
        }

        public static byte[] Decrypt(byte[] data)
        {
            byte[] result = null;
            if (data == null || data.Length == 0)
                return result;

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
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();
                    }
                    result = ms.ToArray();
                }
            }
            return result;
        }

        public static string Decrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            byte[] inputByteArray = Convert.FromBase64String(text);
            byte[] decryptArray = Decrypt(inputByteArray);
            return Encoding.UTF8.GetString(decryptArray);
        }

        public static byte[] Encrypt(byte[] data)
        {
            byte[] result = null;
            if (data == null || data.Length == 0)
                return result;

            using (TripleDES des = TripleDES.Create())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;
                des.Key = KEY;
                des.IV = IV;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(data, 0, data.Length);
                        cs.FlushFinalBlock();
                    }
                    result = ms.ToArray();
                }
            }
            return result;
        }

        public static string Encrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            byte[] inputByteArray = Encoding.UTF8.GetBytes(text);
            byte[] encryptArray = Encrypt(inputByteArray);
            return Convert.ToBase64String(encryptArray);
        }
    }
}