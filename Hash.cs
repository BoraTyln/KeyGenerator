using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KeyGenerator
{
    public class Hash
    {
        public enum HashAlgorithms
        {
            MD5,
            SHA1,
            SHA256,
            SHA384,
            SHA512,
        }

        public string GetHash(string input, Encoding encoding, HashAlgorithms alg, bool toBase64String)
        {
            byte[] bytes = encoding.GetBytes(input);
            if(toBase64String)
            {
                return Convert.ToBase64String(GetHashByte(bytes, alg));
            }
            byte[] hash = GetHashByte(bytes, alg);
            StringBuilder stringBuilder = new StringBuilder();
            for(int i = 0; i < hash.Length; i++)
            {
                stringBuilder.Append(hash[i].ToString("X2"));
            }
            return stringBuilder.ToString();
        }

        public static byte[] GetHashByte(byte[] inputByte, HashAlgorithms alg)
        {
            return HashAlgorithm.Create(alg.ToString()).ComputeHash(inputByte);
        }
    }
}
