using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Classes
{
    public class ValidateArguments
    {
        private const string HelpArgConst = "--help";
        private const string CountArgConst = "--count";
        private const string NameArgConst = "--name";

        // Stores the valid arguments and their validators
        private Dictionary<string, Func<string, bool>> _validators = new Dictionary<string, Func<string, bool>>(StringComparer.OrdinalIgnoreCase)
        {
            { CountArgConst, IsCountValid },
            { NameArgConst, IsNameValid },
            { HelpArgConst, _ => true } // Help is going to be always considered valid
        };

        public int Validate(string[] args)
        {
            // inital checks 
            if (args == null || args.Length == 0)
            {
                return -1;
            }

            var rst = 0;
            bool didRequestHelp = false;

            for (int i = 0; i < args.Length; i++)
            {
                var arg = args[i];

                if (!_validators.TryGetValue(arg, out var validator))
                {
                    // Unrecognized argument
                    return -1;
                }

                if (arg.Equals(HelpArgConst, StringComparison.OrdinalIgnoreCase))
                {
                    // Help has precedence
                    didRequestHelp = true;
                }
                else if (i + 1 < args.Length && !args[i + 1].StartsWith("--"))
                {
                    var value = args[i + 1];
                    if (!validator(value))
                    {
                        // Invalid value for the current argument
                        return -1;
                    }
                    i++; // Skip the next element (value) since we have already processed it
                }
                else
                {
                    // The argument is missing its value
                    return -1;
                }
            }

            if (didRequestHelp)
            {
                // If help is requested, print the help information and return 1
                PrintHelpInfo();
                rst = 1;
            }

            return rst;
        }

        private static bool IsCountValid(string value)
        {
            if (int.TryParse(value, out int count))
            {
                return count >= 10 && count <= 100;
            }

            return false;
        }

        private static bool IsNameValid(string value)
        {
            return !string.IsNullOrEmpty(value) && value.Length >= 3 && value.Length <= 10;
        }

        private static void PrintHelpInfo()
        {
            Console.WriteLine("Help information:");
            Console.WriteLine("--count: Integer between 10 and 100 (inclusive).");
            Console.WriteLine("--name: String of length between 3 and 10 characters.");
            Console.WriteLine("--help: Print this help information.");
        }
    }
}
