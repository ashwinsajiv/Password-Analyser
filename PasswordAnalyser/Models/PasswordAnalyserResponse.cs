namespace PasswordAnalyser.Models
{
    public class PasswordAnalyserResponse
    {
        public string Strength { get; set; }
        public int Breach { get; }
        public PasswordAnalyserResponse(string strength, int breach)
        {
            Strength = strength;
            Breach = breach;
        }
    }
}
