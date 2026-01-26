using BCrypt.Net;

namespace Holcim.Application.Helpers
{
    public static class HelperPassword
    {
        public static bool IsHashed(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            return value.StartsWith("$2a$") || value.StartsWith("$2b$") || value.StartsWith("$2y$");
        }

        public static string Hash(string plain)
        {
            return BCrypt.Net.BCrypt.HashPassword(plain);
        }

        public static bool Verify(string plain, string hashed)
        {
            if (string.IsNullOrWhiteSpace(hashed))
                return false;

            return BCrypt.Net.BCrypt.Verify(plain, hashed);
        }
    }
}
