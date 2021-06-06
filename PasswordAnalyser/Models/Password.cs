using PasswordAnalyser.Services;

namespace PasswordAnalyser.Models
{
    public class Password
    {
        private string _password;
        public string Strength { get; }
        public int Breach { get; }
        public Password(string password)
        {
            _password = password;
            Strength = findStrength();
            Breach = checkBreach();
        }
        private string findStrength()
        {
            StrengthChecker str = new StrengthChecker(_password);
            return str.FindStrength();
        }
        private int checkBreach()
        {
            BreachAnalyser ba = new BreachAnalyser(_password);
            return ba.FindBreach();
        }
    }
}
