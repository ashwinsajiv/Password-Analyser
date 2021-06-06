using Xunit;

namespace PasswordAnalyser.Services
{
    public class StrengthCheckerTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        public void TestEmptyPassword(string password)
        {
            StrengthChecker sc = new StrengthChecker(password);
            Assert.Equal("Blank", sc.FindStrength());
        }
        [Theory]
        [InlineData("123")]
        [InlineData("qwerty")]
        [InlineData("@#Ed@")]
        public void TestUnacceptablePassword(string password)
        {
            StrengthChecker sc = new StrengthChecker(password);
            Assert.Equal("Unacceptable", sc.FindStrength());
        }
        [Theory]
        [InlineData("asdhjfbvcfsdf")]
        [InlineData("asd   asd")]
        [InlineData("@#dd@wew")]
        public void TestWeakPassword(string password)
        {
            StrengthChecker sc = new StrengthChecker(password);
            Assert.Equal("Weak", sc.FindStrength());
        }
        [Theory]
        [InlineData("asdhj123fsdf")]
        [InlineData("asD!asd")]
        [InlineData("@#dd@WeW")]
        public void TestMediumPassword(string password)
        {
            StrengthChecker sc = new StrengthChecker(password);
            Assert.Equal("Medium", sc.FindStrength());
        }
        [Theory]
        [InlineData("aASdhj123fsdf")]
        [InlineData("asD!1asd")]
        [InlineData("@#dd@WeWewew")]
        public void TestStrongPassword(string password)
        {
            StrengthChecker sc = new StrengthChecker(password);
            Assert.Equal("Strong", sc.FindStrength());
        }
        [Theory]
        [InlineData("aASdhj123f!#sdf")]
        [InlineData("asD!1asdasdasd")]
        [InlineData("@#dd@WeWe23wew")]
        public void TestExcellentPassword(string password)
        {
            StrengthChecker sc = new StrengthChecker(password);
            Assert.Equal("Excellent", sc.FindStrength());
        }
    }
}
