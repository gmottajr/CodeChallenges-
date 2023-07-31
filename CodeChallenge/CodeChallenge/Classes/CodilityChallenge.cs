using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Classes
{
    public static class CodilityChallenge
    {
        private static Dictionary<string, int> memo = new Dictionary<string, int>();
        // Start date: March 11, 2023, 5 p.m. UTC
        /// <summary>
        /// Given two strings P and Q, both consisting of N lowercase English letters, construct a new string S by choosing one letter from either P or Q at each position. The goal is to minimize the number of distinct letters in S. 
        /// Return the minimum number of distinct letters of the resulting string S that can be constructed from P and Q.
        /// 
        /// Example 1: 
        /// Input: P = "abc", Q = "bcd"
        /// Possible strings S: "abc", "abd", "acc", "acd", "bbc", "bbd", "bcc", "bcd"
        /// Output: 2 (Minimum number of distinct letters: "acc", "bbc", "bbd", "bcc")
        /// 
        /// Example 2: 
        /// Input: P = "axxz", Q = "yzwy"
        /// Possible string S: "yxxy" (only optimal solution)
        /// Output: 2 (Number of distinct letters in S: "y" and "x")
        /// 
        /// Example 3: 
        /// Input: P = "bacad", Q = "abada"
        /// Possible string S: "aaaaa" (by choosing the letter 'a' in each position)
        /// Output: 1 (Number of distinct letters in S: "a")
        /// 
        /// Example 4: 
        /// Input: P = "amz", Q = "amz"
        /// Possible string S: "amz" (identical input strings)
        /// Output: 3 (Number of distinct letters in S: "a", "m", "z")
        /// 
        /// Constraints:
        /// - N is an integer within the range [1..200,000]
        /// - Strings P and Q are both of length N
        /// - Strings P and Q are made only of lowercase letters (a−z)
        /// - Strings P and Q contain a total of at most 20 distinct letters.
        /// </summary>
        public static int PiCode(string P, string Q)
        {
            // Find distinct characters in P and Q
            HashSet<char> distinctChars = new HashSet<char>(P.ToCharArray());
            distinctChars.UnionWith(Q.ToCharArray());

            // Convert the distinct characters to a list
            List<char> distinctList = new List<char>(distinctChars);

            // Initialize the minimum distinct count to the maximum possible value
            int minDistinct = int.MaxValue;
            var subsetsGenerated = new List<string>();
            // Generate all subsets of distinct characters
            int numSubsets = 1 << distinctList.Count;
            for (int i = 1; i < numSubsets; i++)
            {
                string s = ConstructString(P, Q, distinctList, i);
                subsetsGenerated.Add(s);
                int distinctCount = CountDistinctLetters(s);
                minDistinct = Math.Min(minDistinct, distinctCount);
            }

            return minDistinct;
        }

        public static int PiCode2(string P, string Q)
        {
            return GenerateAllCombinations(P, Q, "", P.Length);
        }

        private static int GenerateAllCombinations(string P, string Q, string current, int length)
        {
            
            if (current.Length == length)
            {
                return CountDistinctLetters2(current);
            }

            string key = current + P[current.Length];
            if (!memo.ContainsKey(key))
            {
                memo[key] = GenerateAllCombinations(P, Q, current + P[current.Length], length);
            }

            key = current + Q[current.Length];
            if (!memo.ContainsKey(key))
            {
                memo[key] = GenerateAllCombinations(P, Q, current + Q[current.Length], length);
            }

            return Math.Min(memo[current + P[current.Length]], memo[current + Q[current.Length]]);
        }

        // Helper method to count the distinct letters in a string
        private static int CountDistinctLetters2(string s)
        {
            HashSet<char> distinctLetters = new HashSet<char>(s.ToCharArray());
            return distinctLetters.Count;
        }
        private static int ConstructString(int n, char[] bothPandQ, string P, string Q)
        {
            List<string> sList = new List<string>();
            for (int i = 0; i < P.Length; i++)
            {
                var s = P[i].ToString();
                for (int j = 0; j < Q.Length; j++)
                {
                    sList.Add(s + Q[j].ToString());
                }
            }

            var lstOfMatches = (from s in sList
                                where s[0] == s[1]
                                group s by s into newGroup
                                orderby newGroup.Count()
                                select new { S = newGroup.Key, TtQtd = newGroup.Count() }).ToList();

            var _rst = lstOfMatches.FirstOrDefault();
            if (_rst != null)
                return _rst.TtQtd;
            else
                return 0;
        }

        private static int CountDistinctLetters(string s)
        {
            HashSet<char> distinctLetters = new HashSet<char>(s.ToCharArray());
            return distinctLetters.Count;
        }

        private static string ConstructString(string p, string q, List<char> distinctList, int subset)
        {
            char[] result = new char[p.Length];
            int index = 0;

            for (int i = 0; i < p.Length; i++)
            {
                char selectedChar = distinctList[(subset >> index) & 1];
                result[i] = p[i] == selectedChar ? p[i] : q[i];
                if (p[i] != q[i])
                {
                    index++;
                }
            }

            return new string(result);
        }
    }
}
