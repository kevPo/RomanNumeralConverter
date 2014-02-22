using System;
using System.IO;

namespace RomanConverter
{
    class RomanNumeralMain
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Error: File path was not successfully received.");
                }
                else if (args.Length > 1)
                {
                    Console.WriteLine("Error: Multiple parameters found, please enter one text file path only.");
                }
                else
                {
                    var filePath = args[0];
                    if (!String.IsNullOrEmpty(filePath))
                    {
                        var contents = File.ReadAllText(@filePath);
                        var romanNumeralRepository = new RomanNumeralRepository();
                        var romanNumeralValidator = new RomanNumeralValidator(romanNumeralRepository);
                        var valid = romanNumeralValidator.ValidateInput(contents);
                        if (valid)
                        {
                            var converter = new RomanNumeralToDecimalConverter(romanNumeralRepository);
                            Console.WriteLine(converter.Convert(contents));
                        }
                    }
                }
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }
            
        }
    }
}
