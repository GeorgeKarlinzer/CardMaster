using System.Security.Cryptography;
using System.Text;

namespace CardMaster.Server
{
    public class Encryption
    {
        public static byte[] CalculatePasswordHash(string password, string username)
        {
            SHA256 sha = SHA256.Create();

            var salt = sha.ComputeHash(Encoding.ASCII.GetBytes(username));

            var hash = sha.ComputeHash(Encoding.ASCII.GetBytes(password));

            hash = hash.Select((x, i) => (byte)(x ^ salt[i])).ToArray();

            return hash;
        }
    }
}
