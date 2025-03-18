using System.Security.Cryptography;
using System.Text;

namespace PublishingHouseManagement.Application.Common.PasswordService
{
    public class PasswordService
    {
        const string SecretKey = "abvgs#@%%asafs";
        public static string GenerateHash(string input)
        {
            using (SHA512 sha = SHA512.Create())
            {
                byte[] bytes = Encoding.ASCII.GetBytes(input + SecretKey);
                byte[] hashBytes = sha.ComputeHash(bytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}