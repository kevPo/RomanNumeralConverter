using System;
using System.Collections.Generic;

namespace RomanConverter
{
    public class RomanNumeralRepository : INumeralRepository
    {
        
        private readonly Dictionary<String, int> _romanNumerals;

        public RomanNumeralRepository()
        {
            _romanNumerals = new Dictionary<string, int>
                {
                    {"I", 1},
                    {"V", 5},
                    {"X", 10},
                    {"L", 50},
                    {"C", 100},
                    {"D", 500},
                    {"M", 1000}
                };
        }

        public int GetDecimalFor(string romanNumeral)
        {
            try
            {
                return _romanNumerals[romanNumeral.ToUpper()];
            }
            catch (KeyNotFoundException)
            {
                throw new InvalidRomanNumeralException(String.Format("Error, {0} is not recognized as a valid roman numeral.", romanNumeral));
            }
        }

        public Dictionary<String, int>.KeyCollection GetNumerals()
        {
            return _romanNumerals.Keys;
        }
    }
}
