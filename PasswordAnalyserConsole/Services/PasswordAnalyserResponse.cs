namespace PasswordAnalyserConsole.Models
{
    public class PasswordAnalyserResponse
    {
        public string Strength { get; set; }
        public int Breaches { get; }
        public PasswordAnalyserResponse(string strength, int breaches)
        {
            Strength = strength;
            Breaches = breaches;
        }
    }
}