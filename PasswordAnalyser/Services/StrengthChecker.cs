using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordAnalyser.Services
{
    public class StrengthChecker
    {
        private string _password;
        public StrengthChecker(string password)
        {
            _password = password;
        }
        private enum passwordScore
        {
            Blank = 0,
            Unacceptable = 1,
            Weak = 2,
            Medium = 3,
            Strong = 4,
            Excellent = 5
        }
        public string FindStrength()
        {
            int score = 0;
            if (_password.Length < 1)
                return passwordScore.Blank.ToString();
            if (_password.Length <= 6)
                return passwordScore.Unacceptable.ToString();
            if (_password.Length > 6)
                score++;
            if (_password.Length >= 10)
                score++;
            // +1 if password contains numbers
            if (_password.Any(char.IsDigit))
                score++;
            // +1 if password contains both lower and upper case characters
            if (_password.Any(char.IsUpper) && _password.Any(char.IsLower))
                score++;
            // +1 if password contains symbols
            Regex rgx = new Regex("[^A-Za-z0-9]");
            if (rgx.IsMatch(_password))
                score++;
            return ((passwordScore)score).ToString();
        }
    }
}