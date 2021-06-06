using PasswordAnalyser.Services;
using Xunit;

public class BreachAnalyserTest
{
    [Fact]
    public void TestMostBreachedPassword()
    {
        BreachAnalyser ba = new BreachAnalyser("123456");
        // Checking if current breach is greater than or equal to the number of breaches recorded on 6/06/2021
        Assert.True(ba.FindBreach() >= 24230577);
    }

    [Fact]
    public void TestPasswordNotBreached()
    {
        BreachAnalyser ba = new BreachAnalyser("QhasuDH121EW#$ewad23DAS");
        // The assumption here is that passwords of this complexity would not have been breached easily
        Assert.Equal(0, ba.FindBreach());
    }
    [Fact]
    public void TestEmptyPassword()
    {
        BreachAnalyser ba = new BreachAnalyser("");
        // Empty passwords return a breach value of 0
        Assert.Equal(0, ba.FindBreach());
    }
}