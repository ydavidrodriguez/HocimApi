using BCrypt.Net;

namespace Holcim.Application.Helpers
{
    public static class HelperPassword
    {
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
