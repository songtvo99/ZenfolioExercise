using Xunit;
using ZenfolioCandidateTest;

namespace XUnitTestZenfolio
{
    public class HandleNumbersInputStringUnitTest
    {

        [Fact]
        public void TestFindMeanValueInSequenceNumberAndHaveResultValue()
        {
            HandleInputSequenceNumbers handleInputNumber = new HandleInputSequenceNumbers();
            decimal[] inputNumbers = new decimal[] { 1, 2, 3, 4, 5, 6, 7 };
            var meanResult = handleInputNumber.FindMean(inputNumbers);
            decimal desiredValue = 4;
            Assert.True(decimal.Equals(meanResult, desiredValue));
        }

        [Fact]
        public void TestFindModeValueInSequenceNumberWithoutValue()
        {
            HandleInputSequenceNumbers handleInputNumber = new HandleInputSequenceNumbers();
            decimal[] inputNumbers = new decimal[] { 1, 2, 3, 4, 5, 6, 7 };
            var modeResult = handleInputNumber.FindMode(inputNumbers);
            Assert.True(modeResult == null);
        }

        [Fact]
        public void TestFindModeValueInSequenceNumberWithOneValue()
        {
            HandleInputSequenceNumbers handleInputNumber = new HandleInputSequenceNumbers();
            decimal[] inputNumbers = new decimal[] { 1, 2, 3, 3, 5, 6, 7 };
            var modeResult = handleInputNumber.FindMode(inputNumbers);
            Assert.True(modeResult.Length == 1 && decimal.Equals(modeResult[0], 3));
        }

        [Fact]
        public void TestFindModeValueInSequenceNumberWithTwoValues()
        {
            HandleInputSequenceNumbers handleInputNumber = new HandleInputSequenceNumbers();
            decimal[] inputNumbers = new decimal[] { 1, 2, 3, 3, 5, 5, 6, 7 };
            var modeResult = handleInputNumber.FindMode(inputNumbers);
            Assert.True(modeResult.Length == 2 
                && decimal.Equals(modeResult[0], 3) 
                && decimal.Equals(modeResult[1], 5));
        }

        [Fact]
        public void TestFindMaxMinValuesInSequenceNumber()
        {
            HandleInputSequenceNumbers handleInputNumber = new HandleInputSequenceNumbers();
            decimal[] inputNumbers = new decimal[] { 1, 2, 3, 4, 5, 6, 7 };
            var numbersResult = handleInputNumber.FindMinMaxValue(inputNumbers);

            Assert.True(decimal.Equals(numbersResult[0], 1) && decimal.Equals(numbersResult[1], 7));
        }

        [Fact]
        public void TestFindMaxMinValuesInSequenceNumberWithOneValue()
        {
            HandleInputSequenceNumbers handleInputNumber = new HandleInputSequenceNumbers();
            decimal[] inputNumbers = new decimal[] { 1, 2, 3, 4, 5, 6, 7 };
            var numbersResult = handleInputNumber.FindMinMaxValue(inputNumbers);
            Assert.True(decimal.Equals(numbersResult[0], 1) && decimal.Equals(numbersResult[1], 7));
        }

        [Fact]
        public void TestFindRangValueWithMaxMinValueDefination()
        {
            HandleInputSequenceNumbers handleInputNumber = new HandleInputSequenceNumbers();
            var maxValue = 7;
            var minValue = 1;
            var rangeValue = handleInputNumber.FindRangeValue(maxValue, minValue);
            Assert.True(decimal.Equals(rangeValue, 6));
        }

        [Fact]
        public void TestBuildSequenceNumbersFromInputString()
        {
            var inputString = "1 2 13 45 99 0 0 0 1";
            HandleInputSequenceNumbers handleInputNumber = new HandleInputSequenceNumbers();
            decimal[] sequenceNumbers = handleInputNumber.BuildSequenceNumbers(inputString, ' ');
            Assert.True( sequenceNumbers.Length == 9);
        }

        [Fact]
        public void TestBuildSequenceNumbersFromInputStringAndProcessAllValue()
        {
            var inputString = "1 2 13 45 99 0 0 0 1";
            HandleInputSequenceNumbers handleInputNumber = new HandleInputSequenceNumbers();
            var result = handleInputNumber.Process(inputString);
            Assert.True(decimal.Equals(result.Range, 99));
            Assert.True(decimal.Equals(result.Mode[0], 0));
            Assert.True(decimal.Equals(result.Median, 99));
        }

        [Fact]
        public void TestBuildSequenceNumbersFromInputStringDoesNotSequenceNumbers()
        {
            var inputString = "1 2 13 45 a99 hhh";
            HandleInputSequenceNumbers handleInputNumber = new HandleInputSequenceNumbers();
            var result = handleInputNumber.Process(inputString);
            Assert.True(result == null);
        }

        [Fact]
        public void TestBuildSequenceNumbersFromInputStringWithOneValue()
        {
            var inputString = "0";
            HandleInputSequenceNumbers handleInputNumber = new HandleInputSequenceNumbers();
            var result = handleInputNumber.Process(inputString);
            Assert.True(decimal.Equals(result.Range, 0));
            Assert.True(result.Mode == null); // mode is none
            Assert.True(decimal.Equals(result.Median, 0));
        }

        [Fact]
        public void TestBuildSequenceNumbersFromInputStringWithNegativeAndDecimalValues()
        {
            var inputString = "1 2 13 45 99 0 0 0 1 -1 1.987";
            HandleInputSequenceNumbers handleInputNumber = new HandleInputSequenceNumbers();
            var result = handleInputNumber.Process(inputString);
            Assert.True( result != null );
            
        }

    }
}
