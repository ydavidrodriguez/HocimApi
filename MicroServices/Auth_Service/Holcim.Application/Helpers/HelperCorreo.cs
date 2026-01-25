using System.Security.Cryptography;
using System.Text;

namespace Holcim.Application.Helpers
{
    public class HelperCorreo
    {
        public static string CreatePassword(int length) 
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (length-- > 0)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    res.Append(valid[(int)(num % (uint)valid.Length)]);
                }
            }

            return res.ToString();

        }

        public static string CreateOtpCode(int digits = 6)
        {
            if (digits <= 0)
                digits = 6;

            int max = (int)Math.Pow(10, digits);
            int value = RandomNumberGenerator.GetInt32(0, max);
            return value.ToString($"D{digits}");
        }

    }
}
