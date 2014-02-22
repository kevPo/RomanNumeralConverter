using System;

namespace RomanConverter
{
    public class InvalidRomanNumeralException : Exception
    {
        public InvalidRomanNumeralException(string message) : base(message)
        {
        }
    }
}
