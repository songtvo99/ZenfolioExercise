using System;
using System.Collections.Generic;

namespace ZenfolioCandidateTest
{
    class Program
    {
        private static string QuitCommand = "quit";
        static void Main(string[] args)
        {
            try
            {
                HandleInputSequenceNumbers handleInputNumber = new HandleInputSequenceNumbers();
                HandleInputLiteralString handleInputLiteralString = new HandleInputLiteralString();
                bool isContinue = true;
                while (isContinue)
                {
                    Console.Write("Input:");
                    string inputString = Console.ReadLine();

                    if (string.Equals(inputString, QuitCommand, StringComparison.OrdinalIgnoreCase))
                    {
                        isContinue = false;
                    }
                    else 
                    {
                        var findValuesResult = handleInputNumber.Process(inputString);
                        if (findValuesResult == null)
                        {
                            var processedSeparatedCharacters = handleInputLiteralString.Process(inputString);
                            DisplayCountedCharactersInString(processedSeparatedCharacters);
                        }
                        else
                        {
                            DisplayNumbersValue(findValuesResult);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.ReadLine();
            }

        }

        private static void DisplayCountedCharactersInString(Dictionary<char, int> countedCharsResult)
        {
            if (countedCharsResult.Count > 0)
            {
                foreach (char charInInputString in countedCharsResult.Keys)
                {
                    Console.Write("{0}:{1}", charInInputString, countedCharsResult[charInInputString]);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine(" No alphabet characters found. ");
            }
        }

        private static void DisplayNumbersValue(NumberResult numberResult)
        {
            Console.WriteLine(@"Mean: {0}", numberResult.Mean);
            if (numberResult.Mode != null && numberResult.Mode.Length > 0)
            {
                Console.WriteLine(@"Mode: {0}", string.Join(",", numberResult.Mode));
            }
            else
            {
                Console.WriteLine(@"Mode: none");
            }

            Console.WriteLine("Median: {0}", numberResult.Median);
            Console.WriteLine("Range: {0}", numberResult.Median);
        }

    }
}
