using System;
using System.Collections.Generic;

namespace ZenfolioCandidateTest
{   
    public class HandleInputLiteralString
    {
        // We ready and init alphabet array and make sure we only handle these characters. 
        private static char[] Alphabet = "ABCDEFGHIJKLMNOPQRSTUVQXYZabcdefghijklmnopqrstuvqxyz".ToCharArray();
        
        /// <summary>
        /// This function parse literal string and handle character in Alphabet variable.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>The dictionary contains only characters occurs in the inputString </returns>
        public Dictionary<char, int> Process(string inputString)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();

            int[] charOccurs = new int[Alphabet.Length];
            foreach ( char inputChar in inputString )
            {
                int indexChar = Array.IndexOf(Alphabet, inputChar);
                // No found alphabet in string. We ignore it.
                if (indexChar > -1)
                {
                    charOccurs[indexChar] = charOccurs[indexChar] + 1;
                }
                // TODO: we need log or show characters is not alphabet
            }
            
            for (int indexCharOccurs = 0; indexCharOccurs < charOccurs.Length; indexCharOccurs++)
            {
                if (charOccurs[indexCharOccurs] > 0)
                {
                    result[Alphabet[indexCharOccurs]] = charOccurs[indexCharOccurs];
                }
            }

            return result;
        }

    }
}
