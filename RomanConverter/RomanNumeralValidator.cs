using System.Linq;

namespace RomanConverter
{
    public class RomanNumeralValidator
    {
        private readonly INumeralRepository _numeralRepository;

        public RomanNumeralValidator(INumeralRepository numeralRepository)
        {
            _numeralRepository = numeralRepository;
        }

        public bool ValidateInput(string romanNumerals)
        {
            return NonEmptyFileValidation(romanNumerals) && ValidRomanNumerals(romanNumerals)
                   && ValidateNoNumeralRepeatGreaterThanThree(romanNumerals);
        }

        private bool NonEmptyFileValidation(string romanNumerals)
        {
            if (string.IsNullOrEmpty(romanNumerals))
            {
                throw new InvalidRomanNumeralException("Sorry, the text file you entered is blank.");
            }
            return true;
        }

        private bool ValidRomanNumerals(string romanNumerals)
        {
            var keys = _numeralRepository.GetNumerals();
            var values = romanNumerals.ToCharArray();
            foreach (var numeral in values)
            {
                if (!keys.Contains(numeral.ToString()))
                    throw new InvalidRomanNumeralException(string.Format("Error, '{0}' is not a valid Roman Numeral.", numeral));
            }
            return true;
        }

        private bool ValidateNoNumeralRepeatGreaterThanThree(string romanNumerals)
        {
            var values = romanNumerals.ToCharArray();
            char? last = null;
            var repeatCount = 0;
            foreach (var romanNumeral in values)
            {
                if (last != null)
                {
                    if (last == romanNumeral)
                    {
                        repeatCount++;
                        if (repeatCount > 3)
                        {
                            throw new InvalidRomanNumeralException(string.Format("Error, '{0}' can not be repeated more than three times.", romanNumeral));
                        }
                    }
                    else
                    {
                        repeatCount = 1;
                    }
                }
                else
                {
                    repeatCount = 1;    
                }
                last = romanNumeral;
            }
            return true;
        }
    }
}
