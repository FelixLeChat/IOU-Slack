using System.Security.Cryptography;
using System.Text;

namespace IOU_Slack_Backend.Helper
{
    public class Sha1Hash
    {
        public static string GetSha1HashData(string data)
        {
            data = data.ToLower();
            var sha1 = SHA1.Create();
            var hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));
            var returnValue = new StringBuilder();
            
            for (var i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }
            
            return returnValue.ToString();
        }

        public static string DoubleSha1Hash(System.Numerics.BigInteger first, System.Numerics.BigInteger second)
        {
            return first > second ? GetSha1HashData(first.ToString() + second) : GetSha1HashData(second.ToString() + first);
        }
    }
}