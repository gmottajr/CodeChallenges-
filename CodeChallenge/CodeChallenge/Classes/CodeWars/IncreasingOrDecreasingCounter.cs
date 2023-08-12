using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Classes.CodeWars
{
    /// Total increasing or decreasing numbers up to a power of 10
    /// 
    /// Define increasing numbers as the numbers whose digits, read from left to right, are never less than the previous ones: 234559 is an example of an increasing number.
    /// 
    /// Conversely, decreasing numbers have all the digits read from left to right so that no digit is bigger than the previous one: 97732 is an example of a decreasing number.
    /// 
    /// You do not need to be the next Gauss to figure out that all numbers with 1 or 2 digits are either increasing or decreasing: 00, 01, 02, ..., 98, 99 
    /// all belong to one of these categories (if not both, like 22 or 55): 101 is indeed the first number that does NOT fall into either of the categories. 
    /// The same goes for all the numbers up to 109, while 110 is again a decreasing number.
    /// 
    /// Now your task is rather easy to declare (a bit less to perform): you have to build a function to return the total occurrences of all the increasing or decreasing numbers below 10 raised to the xth power (x will always be >= 0).
    /// 
    /// To give you a starting point, there are a grand total of increasing and decreasing numbers as shown in the table:
    /// 
    /// Total    Below
    /// 1        1
    /// 10       10
    /// 100      100
    /// 475      1000
    /// 1675     10000
    /// 4954     100000
    /// 12952    1000000
    /// 
    /// This means that your function will have to behave like this:
    /// 
    /// TotalIncDec(0) == 1
    /// TotalIncDec(1) == 10
    /// TotalIncDec(2) == 100
    /// TotalIncDec(3) == 475
    /// TotalIncDec(4) == 1675
    /// TotalIncDec(5) == 4954
    /// TotalIncDec(6) == 12952
    /// 
    /// Tips: Efficiency and trying to figure out how it works are essential: with a brute-force approach, some tests with larger numbers may take more than the total computing power currently on Earth to be finished in the short allotted time.
    /// 
    /// To make it even clearer, the increasing or decreasing numbers between the range 101-200 are: 
    /// [110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 122, 123, 124, 125, 126, 127, 128, 129, 133, 134, 135, 136, 
    /// 137, 138, 139, 144, 145, 146, 147, 148, 149, 155, 156, 157, 158, 159, 166, 167, 168, 169, 177, 178, 179, 188, 189, 199, 200], that is 47 of them. 
    /// In the following range, 201-300, there are 41 of them, and so on, getting rarer and rarer.
    /// 
    /// Trivia: Just for the sake of your curiosity, a number which is neither decreasing nor increasing is called a bouncy number, 
    /// like, say, 3848 or 37294; also, usually 0 is not considered being increasing, decreasing, or bouncy, but it will be for the purpose of this kata.
    public class IncreasingOrDecreasingCounter
    {
        
        public static bool IsDecreasingNumber(BigInteger value)
        {
            if (value == 0)
                return true;

            var numStr = value.ToString();

            if (numStr.Length == 1)
                return true;

            var comparing = string.Concat(numStr.OrderByDescending(c => c));

            return comparing == numStr;
        }

        /// <summary>
        /// increasing numbers as the numbers whose digits, read from left to right, are never less than the previous ones: 234559 is an example of an increasing number.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsIncreasingNumber(BigInteger value)
        {
            if (value == 0)
                return true;
            
            var numStr = value.ToString();

            if (numStr.Length == 1)
                return true;

            var comparing = string.Concat(numStr.OrderBy(c => c));

            return comparing == numStr;
        }

        public static BigInteger DeOutroJeito(int value)
        {
            BigInteger testCase = BigInteger.Pow(10, value);
            BigInteger count = BigInteger.Zero;
            
            for (BigInteger i = BigInteger.Zero; i < testCase; i++)
            {
                if (i <= 100)
                {
                    count++;
                    continue;
                }

                List<int> _IncOrDec = new List<int>();
                var numStr = i.ToString();
                for (int j = 1; j < numStr.Length; j++)
                {
                    int signal =  Convert.ToUInt16(numStr[j - 1].ToString()) <= Convert.ToUInt16(numStr[j].ToString()) ? 1 : 0;
                    _IncOrDec.Add(signal);
                }

                var inc = false;
                var dec = false;

                if (numStr.Length == 3)
                {
                    inc = _IncOrDec.Count(x => x == 1) == 2;
                    dec = _IncOrDec.Count(c => c == 0) == 2;
                }
                else
                {
                    inc = _IncOrDec.IndexOf(1) == 0 && (_IncOrDec.IndexOf(0) == 0 || _IncOrDec.IndexOf(0) == _IncOrDec.Count - 1);
                    dec = _IncOrDec.IndexOf(0) == 0 && (_IncOrDec.IndexOf(1) == 0 || _IncOrDec.IndexOf(1) == _IncOrDec.Count - 1);
                }

                var gotInc = IsIncreasingNumber(i);
                var gotDec = IsDecreasingNumber(i);
                var notBoucing = gotDec || gotDec;
                var gotBouc2 = inc || dec;
                if (gotBouc2 != notBoucing)
                    break;
                if (inc || dec)
                    count++;
            }

            return count;
        }

        /// <summary>
        /// returns the total occurrences of all the increasing or decreasing numbers below 10 raised to the xth power (x will always be >= 0)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static BigInteger OccurrencesOfAllTheIncreasingOrDecreasingNumbers(int value)
        {
            BigInteger trashHold = (int)Math.Pow(10,value);
            BigInteger count = 0;
            for (long i = 0; i < trashHold; i++)
            {
                if (IsIncreasingNumberOrDecreasingNumber(i))
                    count++;
            }

            return count;
        }

        public static bool IsIncreasingNumberOrDecreasingNumber(long value)
        {
            if (value == 0)
                return true;

            var numStr = value.ToString();

            if (numStr.Length <= 2)
                return true;

            switch (value % 10)
            {
                case long n when (n >= 0 && n <= 9):
                    if (IsBouncy(numStr, n))
                      return false;
                    break;
            }

            var numCharArray = numStr.ToArray();
            var numCharSortedAsc = numStr.OrderBy(c => c).ToArray();

            var gotIt = numCharArray.SequenceEqual(numCharSortedAsc);

            if (gotIt)
                return true;
            var numCharSortedDesc = numStr.OrderByDescending(c => c).ToArray();
            return numCharArray.SequenceEqual(numCharSortedDesc);

        }

        
        private static bool IsBouncy(string num, long n)
        { // 120, 212
            if ((n > 0) && num.IndexOf("0") > 0)
                return false;

            if (n == 0 && num.Count(x => Convert.ToInt64(x.ToString()) > Convert.ToInt64(num[0].ToString())) > 0)
                return false;

            var theMax = num.Max();
            var gotMaxindex = num.IndexOf(theMax);

            if (gotMaxindex > 0 && gotMaxindex < (num.Length - 1))
            {
                var splitMIn = num.Split(theMax).ToList();
                var theFirstPart = splitMIn[0];
                splitMIn.Remove(theFirstPart);
                splitMIn.RemoveAll(x => string.IsNullOrEmpty(x));
                var gotSomething = splitMIn.Count(x => x != theMax.ToString());
                if (splitMIn.Count > 0)
                    return false;
            }
            
            var theMin = num.Min();
            var gotMinIndex = num.IndexOf(theMin);
            if ((gotMinIndex > 0 && gotMinIndex < (num.Length - 1)))
            {
                var splitMIn = num.Split(theMin).ToList();
                var theFirstPart = splitMIn[0];
                splitMIn.Remove(theFirstPart);
                splitMIn.RemoveAll(x => string.IsNullOrEmpty(x));
                var gotSomething = splitMIn.Count(x => x != theMin.ToString());
                if (splitMIn.Count > 0)
                    return false;
            }
            var isIncr = IsIncreasingNumber(Convert.ToUInt64(num));
            var isDec = IsDecreasingNumber(Convert.ToUInt64(num));
            var countGraeter = num.Count(x => Convert.ToInt64(x.ToString()) >= n);
            var countMinors = num.Count(x => Convert.ToInt64(x.ToString()) <= n);
            
            var gotIt = !((countGraeter == num.Length) || (countMinors == num.Length));
            return gotIt;
        }

        public static BigInteger TotalIncDec(int x)
        {

            BigInteger testCase = BigInteger.Pow(10, x);
            BigInteger count = BigInteger.Zero;

            for (BigInteger i = BigInteger.Zero; i < testCase; i++)
            {
                if (i <= 100)
                {
                    count++;
                    continue;
                }

                bool increasing = true, decreasing = true;
                BigInteger temp = i, prev = i % 10;

                while (temp != 0)
                {
                    if (temp % 10 > prev)
                    {
                        increasing = false;
                        break;
                    }
                    prev = temp % 10;
                    temp /= 10;
                }

                temp = i;
                prev = i % 10;

                while (temp != 0)
                {
                    if (temp % 10 < prev)
                    {
                        decreasing = false;
                        break;
                    }
                    prev = temp % 10;
                    temp /= 10;
                }

                if (increasing || decreasing)
                {
                    count++;
                }
            }

            return count;
        }


    }
}
