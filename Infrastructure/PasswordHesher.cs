using System.Security.Cryptography;
using System.Text;

namespace DardelinMarket.Infrastructure
{
    public class PasswordHesher
    {
        public static string GenerateHesh(string data)
        {
            SHA256 sha256 = SHA256.Create();

            byte[] heshedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(data));

            StringBuilder sb = new StringBuilder();

            foreach (byte b in heshedBytes)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

    }

}