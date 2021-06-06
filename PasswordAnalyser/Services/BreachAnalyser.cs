using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace PasswordAnalyser.Services
{
    public class BreachAnalyser
    {
        private string _password;
        private const string HaveIBeenPwnedURL = "https://api.pwnedpasswords.com/range/";
        public BreachAnalyser(string password)
        {
            _password = password;
        }
        private string getSHA()
        {
            SHA1CryptoServiceProvider sh = new SHA1CryptoServiceProvider();
            sh.ComputeHash(ASCIIEncoding.ASCII.GetBytes(_password));
            byte[] re = sh.Hash;
            StringBuilder sb = new StringBuilder();
            foreach (byte b in re)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString().ToUpper();
        }
        public int FindBreach()
        {
            var sha = getSHA();
            var prefix = sha.Substring(0, 5);
            var suffix = sha.Substring(5, sha.Length - 5);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(HaveIBeenPwnedURL + prefix);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            // No need to check for 200 as this service returns 200 only
            var hashes = readStream.ReadToEnd().ToString();
            var hashList = hashes.Split('\n');
            for (int i = 0; i < hashList.Length; i++)
            {
                var hash = hashList[i].Split(':');
                if (hash[0] == suffix)
                {
                    return Int32.Parse(hash[1]);
                }
            }
            response.Close();
            readStream.Close();
            return 0;
        }
    }
}