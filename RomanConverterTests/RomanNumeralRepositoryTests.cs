using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanConverter;

namespace RomanConverterTests
{
    [TestClass]
    public class RomanNumeralRepositoryTests
    {
        private readonly INumeralRepository _romanNumeralRepo = new RomanNumeralRepository();

        [TestMethod]
        [ExpectedException(typeof(InvalidRomanNumeralException),
            "Error, 3 is not recognized as a valid roman numeral.")]
        public void Test_Invalid_Numeral_Throws_Exception()
        {
            var value = _romanNumeralRepo.GetDecimalFor("3");
        }

        [TestMethod]
        public void Test_Lowercase_Letter_Converts()
        {
            var valueI = _romanNumeralRepo.GetDecimalFor("i");
            Assert.IsTrue(valueI == 1);
        }

        [TestMethod]
        public void Test_All_Roman_Numeral_Values()
        {
            var valueI = _romanNumeralRepo.GetDecimalFor("I");
            Assert.IsTrue(valueI == 1);
            var valueV = _romanNumeralRepo.GetDecimalFor("V");
            Assert.IsTrue(valueV == 5);
            var valueX = _romanNumeralRepo.GetDecimalFor("X");
            Assert.IsTrue(valueX == 10);
            var valueL = _romanNumeralRepo.GetDecimalFor("L");
            Assert.IsTrue(valueL == 50);
            var valueC = _romanNumeralRepo.GetDecimalFor("C");
            Assert.IsTrue(valueC == 100);
            var valueD = _romanNumeralRepo.GetDecimalFor("D");
            Assert.IsTrue(valueD == 500);
            var valueM = _romanNumeralRepo.GetDecimalFor("M");
            Assert.IsTrue(valueM == 1000);
        }
    }
}
