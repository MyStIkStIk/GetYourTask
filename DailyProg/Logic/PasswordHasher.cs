using System.Text;
using DailyProg.Models;
using System.Security.Cryptography;
namespace DailyProg.Logic
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            var byted = Encoding.UTF8.GetBytes(password);
            var sha1 = SHA1.Create();
            var hashedBytes = sha1.ComputeHash(byted);
            return Encoding.UTF8.GetString(hashedBytes);
        }
    }
}
