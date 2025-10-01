
using System.Security.Cryptography;

namespace GameCore
{
    public static class BoxSelector
    {
        public static byte[] GenerateSecretKey()
        {
            return Savage.RandomBytesGenerator.Generate(256);
        }
        public static string SecretKeyToString(byte[] secretKey)
        {
            return BitConverter.ToString(secretKey).Replace("-", "");
        }
        public static int GenerateMortyValue(int value)
        {
            var random = new Random();

            return random.Next(0, value);
        }
        public static string GenerateHMAC(byte[] secretKey, int mortyValue)
        {
            byte[] buffer = BitConverter.GetBytes(mortyValue);

            using (var hmac = new HMACSHA3_256(secretKey))
            {
                byte[] hash = hmac.ComputeHash(buffer);
                return BitConverter.ToString(hash).Replace("-", "");
            }

        }
    }
}
