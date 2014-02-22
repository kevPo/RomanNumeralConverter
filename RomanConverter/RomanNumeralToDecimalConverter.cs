using System;

namespace RomanConverter
{
    public class RomanNumeralToDecimalConverter
    {
        private readonly INumeralRepository _numeralRepository;
        

        public RomanNumeralToDecimalConverter(INumeralRepository numeralRepository)
        {
            _numeralRepository = numeralRepository;
        }

        public string Convert(string romanNumeral)
        {
            try
            {
                var nodeBuilder = new NumeralNodeBuilder();
                var root = nodeBuilder.ConstructNodes(romanNumeral);
                var result = CalculateDecimal(root);
                return result.ToString();
            }
            catch (InvalidRomanNumeralException exception)
            {
                return exception.Message;
            }
        }

        private int CalculateDecimal(NumeralNode numeralNode)
        {
            if (numeralNode.Next == null)
            {
                return _numeralRepository.GetDecimalFor(numeralNode.Numeral);
            }
            if (PowerOfTen(numeralNode) && NextNumeralIsGreater(numeralNode) && !NextNumeralIsTenTimesGreater(numeralNode))
            {
                return CalculateDecimal(numeralNode.Next) - _numeralRepository.GetDecimalFor(numeralNode.Numeral);
            }
            return _numeralRepository.GetDecimalFor(numeralNode.Numeral) + CalculateDecimal(numeralNode.Next);
        }

        public bool PowerOfTen(NumeralNode numeralNode)
        {
            // algorithm from:  www.exploringbinary.com/ten-ways-tocheck-if-an-integer-is-a-power-of-two-in-c
            var value = _numeralRepository.GetDecimalFor(numeralNode.Numeral);
            while (((value % 10) == 0) && value > 1)
            {
                value /= 10;
            }
            return (value == 1);
        }
        
        private bool NextNumeralIsGreater(NumeralNode numeralNode)
        {
            return _numeralRepository.GetDecimalFor(numeralNode.Next.Numeral) > _numeralRepository.GetDecimalFor(numeralNode.Numeral);
        }

        private bool NextNumeralIsTenTimesGreater(NumeralNode numeralNode)
        {
            var currentDecimal = _numeralRepository.GetDecimalFor(numeralNode.Numeral);
            var nextDecimal = _numeralRepository.GetDecimalFor(numeralNode.Next.Numeral);
            if (nextDecimal > currentDecimal*10)
                throw new InvalidRomanNumeralException(String.Format("Error: Invalid Roman Numeral Format, '{0}' can not be subtracted from numeral that is 10 times greater.({1})", numeralNode.Numeral, numeralNode.Next.Numeral));
            return false;
        }
        
    }
}
