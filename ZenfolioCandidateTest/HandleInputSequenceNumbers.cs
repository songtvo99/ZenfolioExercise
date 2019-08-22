using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ZenfolioCandidateTest
{
    public class HandleInputSequenceNumbers
    {
        public static char NumberSeparator = ' ';

        /// <summary>
        /// This function check input and build array. If user input is literal string it return null
        /// </summary>
        /// <param name="inputString">The string contains sequence numbers</param>
        /// <param name="separator">The character is used separated between input string</param>
        /// <returns></returns>
        public decimal[] BuildSequenceNumbers(string inputString, char separator)
        {
            string[] inputStrItems = inputString.Split(separator);
            decimal[] inputNumbers = new decimal[inputStrItems.Length];
            for(int indexStrNoSpace = 0; indexStrNoSpace < inputStrItems.Length; indexStrNoSpace++)
            {
                decimal inputNumberValue;
                bool isParseSuccess = decimal.TryParse(inputStrItems[indexStrNoSpace], out inputNumberValue);
                if (isParseSuccess)
                {
                    inputNumbers[indexStrNoSpace] = inputNumberValue;
                }
                else
                {
                    return null;
                }
            }

            return inputNumbers;
        }

        /// <summary>
        /// This method handle input string with all item is number from console 
        /// </summary>
        /// <param name="inputString">The string after user pressed enter key</param>
        /// <returns></returns>
        public NumberResult Process(string inputString)
        {
            decimal[] inputNumbers = BuildSequenceNumbers(inputString, NumberSeparator);
            if (inputNumbers != null && inputNumbers.Length > 0)
            {
                // { minValue, maxValue }
                decimal[] minMaxValues = FindMinMaxValue(inputNumbers); 

                return new NumberResult
                {
                    Mean = FindMean(inputNumbers),
                    Median = FindMedian(inputNumbers),
                    Mode = FindMode(inputNumbers),
                    Range = FindRangeValue(minMaxValues[1], minMaxValues[0])
                };
            }

            return null;
        }

        /// <summary>
        /// The function find max and min value in array and put in array follow ordered values { min, max } 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public decimal[] FindMinMaxValue(decimal[] numbers)
        {
            decimal maxValue = numbers[0];
            decimal minValue = numbers[0];

            for (int indexNumbersArray = 0; indexNumbersArray<numbers.Length; indexNumbersArray++)
            {
                decimal inputNumberValue = numbers[indexNumbersArray];

                if (decimal.Compare(maxValue, inputNumberValue) < 0)
                {
                    maxValue = inputNumberValue;
                }
                else if (decimal.Compare(minValue, inputNumberValue) > 0)
                {
                    minValue = inputNumberValue;
                }
            }

            return new decimal[] { minValue, maxValue };
        }

        /// <summary>
        /// This function to find Range value by subtract maxValue - minValue
        /// </summary>
        /// <param name="MaxValue"></param>
        /// <param name="MinValue"></param>
        /// <returns></returns>
        public decimal FindRangeValue(decimal maxValue, decimal minValue)
        {   
            return decimal.Subtract(maxValue, minValue);
        }

        /// <summary>
        /// The mean value is average of array 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public decimal FindMean(decimal[] numbers)
        {
            if (numbers != null && numbers.Length > 0)
            {
                decimal sum = 0;
                foreach( decimal number in numbers )
                {
                    sum = decimal.Add(sum, number);

                }

                return decimal.Divide(sum, numbers.Length);
            }

            return 0;
        }

        /// <summary>
        /// This function find median in array. 
        /// The median is middle number when we have number of array is event we have average
        /// of middle + next element. E.g:
        /// 4 5 6 1. Middle is (4 + 1) / 2 = 2.5
        /// It means we need to get element 2nd and 3rd: 5 + 6 /2 = 10.5
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public decimal FindMedian(decimal[] numbers)
        {
            int indexMedian = (numbers.Length + 1) / 2;

            if (numbers.Length % 2 != 0)
            {
                return numbers[indexMedian - 1];
            }

            return decimal.Add(numbers[indexMedian - 1], numbers[indexMedian]) / 2;
        }

        /// <summary>
        /// The mode is number have max repeated in sequence numbers.
        /// If two numbers have same repeated. We will show all of them.
        /// </summary>
        /// <param name="inputNumbers"></param>
        /// <returns></returns>
        public decimal[] FindMode(decimal[] inputNumbers)
        {
            Dictionary<decimal, int> numberOccurs = new Dictionary<decimal, int>();

            int maxOccur = 0;

            foreach (decimal inputNumber in inputNumbers)
            {
                int numberOccurValue;
                if (numberOccurs.TryGetValue(inputNumber, out numberOccurValue))
                {
                    numberOccurs[inputNumber] = numberOccurValue + 1;
                }
                else
                {
                    numberOccurs[inputNumber] = 1;
                }
                
                if (numberOccurValue + 1 > maxOccur)
                {
                    maxOccur = numberOccurValue + 1;
                }

            }

            // If value with no occur or just no repeated values
            if (maxOccur < 2)
            {
                return null;
            }

            // Get all decimal value have number occurs equals with maxOccur
            return numberOccurs.Where(x => x.Value == maxOccur)
                .Select(x => x.Key)
                .ToArray();
        }
    }
}
