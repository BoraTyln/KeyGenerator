using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KeyGenerator
{
    public class AES
    {
        private static byte[] key;
        private static byte[] iv;
        public static void GenerateKeyAndIv()
        {
            using (Aes aes = Aes.Create())
            {
                key = aes.Key;
                iv = aes.IV;
            }

        }

        public static string Encrypt(string plainText)
        {
            byte[] encryptedBytes;

            using (Aes aes = Aes.Create())
            {
                key = aes.Key;
                iv = aes.IV;

                ICryptoTransform encryptor = aes.CreateEncryptor(key, iv);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        encryptedBytes = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encryptedBytes);
        }

        // Under construction //
        public static string Decrypt(string encryptedText)
        {
            byte[] encryptedBytes;

            using (Aes aes = Aes.Create())
            {
                key = aes.Key; // Change key and iv values with new byte[] { bytes in here }
                iv = aes.IV;

                ICryptoTransform decryptor = aes.CreateDecryptor(key, iv);
                byte[] encryptedTextBytes = Encoding.UTF8.GetBytes(encryptedText);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        cryptoStream.Write(encryptedTextBytes, 0, encryptedTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        encryptedBytes = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encryptedBytes);
        }
    }
}
