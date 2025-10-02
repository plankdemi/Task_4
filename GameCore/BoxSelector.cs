
using System.Security.Cryptography;

namespace GameCore
{
    public static class BoxSelector
    {
        public static byte[] GenerateSecretKey()
        {
            byte[] secretKey = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(secretKey);
            }
            return secretKey;
        }
        public static string SecretKeyToString(byte[] secretKey)
        {
            return BitConverter.ToString(secretKey).Replace("-", "");
        }
        public static int GenerateMortyValue(int value)
        {
            return RandomNumberGenerator.GetInt32(0, value);
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
