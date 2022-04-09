using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITask3
{
    internal class HMACGenerate
    {
        public HMACGenerate() { }
        public byte[] GenerateKey()
        {
            byte[] key = new byte[32];
            var gen = RandomNumberGenerator.Create();
            gen.GetBytes(key);
            return key;
        }
        public string HMACHASH(string str,byte[] key)
        {
            using (var hmac = new HMACSHA256(key))
            {
                byte[] bstr = Encoding.UTF8.GetBytes(str);
                var bhash = hmac.ComputeHash(bstr);
                return BitConverter.ToString(bhash).Replace("-", string.Empty).ToLower();
            }
        }
    }
}
