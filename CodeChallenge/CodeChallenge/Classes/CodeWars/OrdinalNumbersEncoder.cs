using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Classes.CodeWars
{
    public static class OrdinalNumbersEncoder
    {
        private static IDictionary<int, string> _MapOrdinals = new Dictionary<int, string>() 
        {

            {0, "th"},
            {1, "st"},
            {2, "nd"},
            {3, "rd"},
            {4, "th"},
            {5, "th"},
            {6, "th"},
            {7, "th"},
            {8, "th"},
            {9, "th"},
            {10, "th"},
            {11, "th"},
            {12, "th"},
            {13, "th"},
        };

        private static IDictionary<int, string> _MapOrdinalsBrief = new Dictionary<int, string>()
        {

            {0, "th"},
            {1, "st"},
            {2, "d"},
            {3, "d"},
            {4, "th"},
            {5, "th"},
            {6, "th"},
            {7, "th"},
            {8, "th"},
            {9, "th"},
            {10, "th"},
            {11, "th"},
            {12, "th"},
            {13, "th"},
        };

        public static string ConvertToOrdinal(int number, bool brief = false)
        {
            var numStr = number.ToString();
            Console.WriteLine("The number is {0}", number);
            var target = numStr.Length >= 2 ? AreExceptions(numStr) ? numStr.Substring(numStr.Length - 2, 2) : numStr.Substring(numStr.Length - 1, 1) : numStr.Substring(numStr.Length - 1, 1);
            var targetNum = Convert.ToInt32(target);
            var _rst = brief ? _MapOrdinalsBrief[targetNum] : _MapOrdinals[targetNum];

            return numStr + _rst;
        }

        private static bool AreExceptions(string numStr)
        {
            var exceptionalNum = numStr.Substring(numStr.Length - 2, 2);
            return exceptionalNum == "11" || exceptionalNum == "12" || exceptionalNum == "13";
        }

        public static string Ordinal(int number, bool brief = false)
        {
            if ((number / 10) % 10 == 1)
            {
                return "th";
            }

            switch (number % 10)
            {
                case 1: return "st";
                case 2: return brief ? "d" : "nd";
                case 3: return brief ? "d" : "rd";
                default: return "th";
            }
        }
    }
}
