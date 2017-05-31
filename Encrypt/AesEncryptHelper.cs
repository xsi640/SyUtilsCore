using System;
using System.Security.Cryptography;
using System.Text;

namespace SyUtilsCore
{
    public static class AesEncryptHelper
    {
        private static byte[] _KEY;
        private static byte[] _IV;

        static AesEncryptHelper()
        {
            _KEY = Convert.FromBase64String("67tbEvu77/HpugF+l1MuT+rOP9iqOBCgCVMNf4CG7bE=");
            _IV = Convert.FromBase64String("8lYrNakC24FYqqgHulRG2A==");
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

        public static string Decrypt(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            byte[] inputArray = Convert.FromBase64String(text);
            byte[] decryptArray = Decrypt(inputArray);
            return Encoding.UTF8.GetString(decryptArray);
        }

        public static byte[] Decrypt(byte[] data)
        {
            byte[] result = null;
            if (data == null || data.Length == 0)
                return result;
            using (Aes aes = Aes.Create())
            {
                aes.Key = KEY;
                aes.IV = IV;

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
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

            byte[] inputArray = Encoding.UTF8.GetBytes(text);
            byte[] encryptArray = Encrypt(inputArray);
            return Convert.ToBase64String(encryptArray);
        }

        public static byte[] Encrypt(byte[] data)
        {
            byte[] result = null;
            if (data == null || data.Length == 0)
                return result;
            using (Aes des = Aes.Create())
            {
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
    }
}
