using Microsoft.VisualStudio.TestTools.UnitTesting;
using RomanConverter;

namespace RomanConverterTests
{
    
    [TestClass]
    public class NumeralNodeBuilderTests
    {

        [TestMethod]
        public void Construct_Nodes_With_One_Numeral()
        {
            var builder = new NumeralNodeBuilder();
            var node = builder.ConstructNodes("X");
            Assert.IsTrue(node.Numeral == "X");
            Assert.IsTrue(node.Next == null);
        }

        [TestMethod]
        public void Construct_Nodes_With_Two_Numerals()
        {
            var builder = new NumeralNodeBuilder();
            var node = builder.ConstructNodes("MX");
            Assert.IsTrue(node.Numeral == "M");
            Assert.IsTrue(node.Next.Numeral == "X");
            Assert.IsTrue(node.Next.Next == null);
        }


    }
}
