using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptoWallet.Helpers.RegFlow
{
    public class LogRegHelper
    {
        private const string salt = "e7f3a2c8d54b9e1f3c6a2b187c4d5f02";


        public static string GenerateSecureToken(int userId)
        {
            string _secretKey = "your_secret_key";
            string tokenData = $"{userId}:{DateTime.UtcNow.Ticks}";
            byte[] keyBytes = Encoding.UTF8.GetBytes(_secretKey);
            byte[] dataBytes = Encoding.UTF8.GetBytes(tokenData);

            using (var hmac = new HMACSHA256(keyBytes))
            {
                byte[] hashBytes = hmac.ComputeHash(dataBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public static string HashPassword(string password)
        {
            string saltedPassword = $"{password}{salt}";

            using (var sha256 = SHA256.Create())
            {

                byte[] passwordBytes = Encoding.UTF8.GetBytes(saltedPassword);


                byte[] hashBytes = sha256.ComputeHash(passwordBytes);


                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

    }
}