using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanConverter;

namespace RomanConverterTests
{
    [TestClass]
    public class RomanNumeralToDecimalConverterTests
    {
        private readonly RomanNumeralToDecimalConverter _converter = 
            new RomanNumeralToDecimalConverter(new RomanNumeralRepository());


        [TestMethod]
        public void Test_Conversion_With_One_Numeral()
        {
            var result = _converter.Convert("I");
            Assert.IsTrue(result == "1");
        }

        [TestMethod]
        public void Test_Simple_Multiple_Numerals()
        {
            var result = _converter.Convert("II");
            Assert.IsTrue(result == "2");
        }

        [TestMethod]
        public void Test_VIII_Converts_To_8()
        {
            var result = _converter.Convert("VIII");
            Assert.IsTrue(result == "8");
        }

        [TestMethod]
        public void Test_IX_Converts_To_9()
        {
            var result = _converter.Convert("IX");
            Assert.IsTrue(result == "9");
        }

        [TestMethod]
        public void Test_XIX_Converts_To_19()
        {
            var result = _converter.Convert("XIX");
            Assert.IsTrue(result == "19");
        }

        [TestMethod]
        public void Test_MMXIII_Converts_To_2013()
        {
            var result = _converter.Convert("MMXIII");
            Assert.IsTrue(result == "2013");
        }

        [TestMethod]
        public void Test_XCIX_Converts_To_99()
        {
            var result = _converter.Convert("XCIX");
            Assert.IsTrue(result == "99");
        }

        [TestMethod]
        public void Test_Invalid_Numeral_Returns_Error()
        {
            var result = _converter.Convert("XXB");
            Assert.IsTrue(result == "Error, B is not recognized as a valid roman numeral.");
        }

        [TestMethod]
        public void Test_Invalid_Subtraction_Returns_Error()
        {
            var result = _converter.Convert("IC");
            Assert.IsTrue(result == "Error: Invalid Roman Numeral Format, 'I' can not be subtracted from numeral that is 10 times greater.(C)");
        }

    }
}
