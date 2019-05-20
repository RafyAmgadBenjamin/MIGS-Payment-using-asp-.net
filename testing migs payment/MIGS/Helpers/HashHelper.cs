using System.Security.Cryptography;
using System.Text;

namespace MIGS.Helpers
{
    public static class HashHelper
    {
        public static string CreateHMACSHA256Signature(string secureKey, string message)
        {
            // Hex decode the secure secret for use in using the 'HMACSHA256' hasher.
            // Hex decoding eliminates this source of error as it is independent of the character encoding.
            // Hex decoding is precise in converting to a byte array and is the preferred form for representing binary values as hex strings.
            byte[] key = new byte[secureKey.Length / 2];
            for (int i = 0; i < secureKey.Length / 2; i++)
            {
                key[i] = (byte)int.Parse(secureKey.Substring(i * 2, 2), System.Globalization.NumberStyles.HexNumber);
            }

            // Create secureHash on string
            string hexHash = "";
            using (HMACSHA256 hasher = new HMACSHA256(key))
            {
                byte[] hashValue = hasher.ComputeHash(Encoding.UTF8.GetBytes(message));
                foreach (byte b in hashValue)
                {
                    hexHash += b.ToString("X2");
                }
            }

            //var hmac = new HMACSHA256(key)
            //   .ComputeHash(Encoding.UTF8.GetBytes(message))
            //   .Select(b => b.ToString("X2"))
            //   .Aggregate((a, b) => a + b);

            return hexHash;
        }
    }
}
