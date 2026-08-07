using System;
using System.Security.Cryptography;

namespace Assignment4.Helpers
{
    /// <summary>
    /// Password Hasher helper class for hashing and verifying passwords securely.
    /// </summary>
    internal static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 10000;

        /// <summary>
        /// Hashes a plain text password with a random salt.
        /// </summary>
        /// <param name="password">The plain text password.</param>
        /// <returns>Hashed password string containing salt and hash.</returns>
        public static string HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);
                string saltString = Convert.ToBase64String(salt);
                string hashString = Convert.ToBase64String(hash);
                return $"{saltString}.{hashString}";
            }
        }

        /// <summary>
        /// Verifies a plain text password against a stored hashed password.
        /// </summary>
        /// <param name="password">The plain text password to verify.</param>
        /// <param name="hashedPassword">The stored hashed password string.</param>
        /// <returns>True if password matches, otherwise false.</returns>
        public static bool VerifyPassword(string password, string hashedPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword))
            {
                return false;
            }

            string[] parts = hashedPassword.Split('.');
            if (parts.Length != 2)
            {
                return false;
            }

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] storedHash = Convert.FromBase64String(parts[1]);

            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);
                if (hash.Length != storedHash.Length)
                {
                    return false;
                }

                for (int i = 0; i < hash.Length; i++)
                {
                    if (hash[i] != storedHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }
}
