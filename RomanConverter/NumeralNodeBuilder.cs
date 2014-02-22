using System;
using System.Collections.Generic;

namespace RomanConverter
{
    public class NumeralNodeBuilder
    {
        public NumeralNode ConstructNodes(string romanNumeral)
        {
            var chars = romanNumeral.ToCharArray();
            Array.Reverse(chars);
            var numeralStack = new Stack<char>(chars);
            var root = ConstructNode(numeralStack);
            return root;
        }

        private NumeralNode ConstructNode(Stack<char> numeralStack)
        {
            if (numeralStack.Count > 1)
            {
                var romanNumeral = numeralStack.Pop().ToString();
                return new NumeralNode { Numeral = romanNumeral, Next = ConstructNode(numeralStack) };
            }

            return new NumeralNode { Numeral = numeralStack.Pop().ToString() };
        }
    }
}
