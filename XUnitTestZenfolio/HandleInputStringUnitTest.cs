using Xunit;
using ZenfolioCandidateTest;

namespace XUnitTestZenfolio
{
    public class HandleInputStringUnitTest
    {
        [Fact]
        public void TestLiteralStringWithNormalCase()
        {
            var inputString = "thisis a samplestring";
            HandleInputLiteralString handleInputLiteralString = new HandleInputLiteralString();
            var result = handleInputLiteralString.Process(inputString);

            Assert.True(result['a'] == 2);
            Assert.True(result['i'] == 3);
            Assert.True(result['t'] == 2);
        }

        [Fact]
        public void TestLiteralStringWithOtherCase()
        {
            var inputString = "I am n0thing m0r3 than a string.I t00 hav3 a l3xic0graphic 0rd3r.";
            HandleInputLiteralString handleInputLiteralString = new HandleInputLiteralString();
            var result = handleInputLiteralString.Process(inputString);

            Assert.True(result['a'] == 6);
            Assert.True(result['t'] == 4);
            Assert.True(result['x'] == 1);
        }

        [Fact]
        public void TestLiteralStringWithCasensitive()
        {
            var inputString = "Hello Howa and hello Test";
            HandleInputLiteralString handleInputLiteralString = new HandleInputLiteralString();
            var result = handleInputLiteralString.Process(inputString);

            Assert.True(result['H'] == 2);
            Assert.True(result['h'] == 1);
            Assert.True(result['t'] == 1);
        }

        [Fact]
        public void TestLiteralStringWithEmpty()
        {
            var inputString = "";
            HandleInputLiteralString handleInputLiteralString = new HandleInputLiteralString();
            var result = handleInputLiteralString.Process(inputString);

            Assert.True(result.Count == 0);
        }
    }
}
