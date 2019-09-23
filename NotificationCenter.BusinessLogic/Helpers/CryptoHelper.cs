using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Threading.Tasks;

namespace NotificationCenter.BusinessLogic.Helpers
{
    public static class CryptoHelper
    {
        private const int SaltByteSize = 24;
        private const int HashByteSize = 24;
        private const int HasingIterationsCount = 10101;

        private static byte[] GenerateSalt(int saltByteSize = SaltByteSize)
        {
            using (RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[saltByteSize];
                saltGenerator.GetBytes(salt);
                return salt;
            }
        }

        private static byte[] ComputeHash(string password, byte[] salt, int iterations = HasingIterationsCount, int hashByteSize = HashByteSize)
        {
            using (Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, salt))
            {
                hashGenerator.IterationCount = iterations;
                var hashedPass =  hashGenerator.GetBytes(hashByteSize);

                var result = new byte[salt.Length + hashedPass.Length];

                salt.CopyTo(result, 0);
                hashedPass.CopyTo(result, salt.Length);

                return result;
            }
        }

        public static string HashedPassword(string password, byte[] salt = null)
        {
            var hashedPass = ComputeHash(password, salt ?? GenerateSalt());
            return Convert.ToBase64String(hashedPass);
        }

        public static bool ComparePassword(string password, string hash)
        {
            var saltedPass = Convert.FromBase64String(hash);

            var salt = saltedPass.Take(SaltByteSize).ToArray();

            var compare = HashedPassword(password, salt);

            return compare == hash;
        }
    }
}
