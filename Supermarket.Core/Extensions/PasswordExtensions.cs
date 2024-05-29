using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace Supermarket.Core.Extensions
{
    public static class PasswordExtensions
    {
        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(salt);
            return salt;
        }

        public static string HashPassword(string password, byte[] salt) => Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

        public static bool CheckPassword(string password, string hash, string salt) => hash == HashPassword(password, Convert.FromBase64String(salt));
    }
}