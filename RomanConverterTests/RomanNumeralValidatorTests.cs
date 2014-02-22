using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanConverter;

namespace RomanConverterTests
{
    [TestClass]
    public class RomanNumeralValidatorTests
    {
        private readonly RomanNumeralValidator _validator = new RomanNumeralValidator(new RomanNumeralRepository());

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumeralException),
            "Sorry, the text file you entered is blank.")]
        public void Test_Blank_Text_File_Is_Not_Valid()
        {
            var response = _validator.ValidateInput(String.Empty);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumeralException),
            "Error, 'K' is not a valid Roman Numeral.")]
        public void Test_Non_Roman_Numeral_Is_Not_Valid()
        {
            var response = _validator.ValidateInput("XKX");
        }

        [TestMethod]
        public void Test_Roman_Numerals_Is_Valid()
        {
            var response = _validator.ValidateInput("XXX");
            Assert.IsTrue(response);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumeralException),
            "Error, 'X' can not be repeated more than three times.")]
        public void Test_Letter_Repeated_Is_Not_Valid()
        {
            var response = _validator.ValidateInput("MMXXXX");
        }
    }
}
