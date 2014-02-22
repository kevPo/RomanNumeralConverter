using System;
using System.Collections.Generic;

namespace RomanConverter
{
    public interface INumeralRepository
    {
        int GetDecimalFor(string numeral);
        Dictionary<String, int>.KeyCollection GetNumerals();
    }
}
