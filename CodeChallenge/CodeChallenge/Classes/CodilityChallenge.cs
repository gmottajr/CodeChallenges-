using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeChallenge.Classes
{
    public static class CodilityChallenge
    {
        private const string PatternConst = @"([a-z])\1+";
        private static Dictionary<string, int> memo = new Dictionary<string, int>();
        private static List<string> _combinations = new List<string>();
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

        public static List<string> GetCombinations(string P, string Q)
        {
            List<string> combinations = new List<string>();

            for (int i = 0; i < P.Length; i++)
            {
                for (int j = 0; j < Q.Length; j++)
                {
                    string combination = P[i].ToString() + Q[j].ToString();
                    combinations.Add(combination);
                }
            }

            return combinations;
        }
        public static int PiCode2(string P, string Q)
        {
            return GenerateAllCombinations(P, Q, "", P.Length);
        }

        public static int PiCodeGM(string P, string Q)
        {
            memo.Clear();
            _combinations.Clear();
            if (P == Q)
            {
                return (from i in P.ToCharArray()
                        select i).Distinct().Count();
            }

            var pattern = GetRepeatingPattern(P);
            if (!string.IsNullOrEmpty(pattern) &&
                !_combinations.Any(s => s == P))
            {
                _combinations.Add(P);
            }

            if (!string.IsNullOrEmpty(pattern))
            {
                if (!memo.ContainsKey(P))
                    memo[P] = (from c in P.ToCharArray()
                               select c).Distinct().Count();
            }

            LoopThroughCombinations(P, Q);
            LoopThroughCombinations(Q, P);

            Console.WriteLine(string.Join(",", _combinations));
            Console.WriteLine(string.Join(",", memo));

            var gm = (from item in memo
                      group item by item.Value into groupGM
                      orderby groupGM.Key
                      select new { DistinctCount = groupGM.Key, Test = groupGM.Count() }).ToList();

            return gm.First().DistinctCount;
        }


        public static int PiCodeGM2(string P, string Q)
        {
            memo.Clear();
            if (P == Q)
            {
                return (from i in P.ToCharArray()
                        select i).Distinct().Count();
            }

            var pattern = ExtractPatternFromTarget(P);

            var patternQ = ExtractPatternFromTarget(Q);

            if (!string.IsNullOrEmpty(pattern) && !string.IsNullOrEmpty(patternQ))
              patternQ = ExtractPatternFromTarget( pattern + patternQ);

            LoopThroughCombinations2(P, Q);
            LoopThroughCombinations2(Q, P);

            Console.WriteLine(string.Join(",", _combinations));
            Console.WriteLine(string.Join(",", memo));

            var gm = (from item in memo
                      group item by item.Value into groupGM
                      orderby groupGM.Key
                      select new { DistinctCount = groupGM.Key, Test = groupGM.Count() }).ToList();

            return gm.First().DistinctCount;
        }

        private static string ExtractPatternFromTarget(string target)
        {
            var pattern = GetRepeatingPattern(target);

            if (!string.IsNullOrEmpty(pattern))
            {
                if (!memo.ContainsKey(target))
                    memo[target] = (from c in target.ToCharArray()
                               select c).Distinct().Count();
            }

            return pattern;
        }

        private static void LoopThroughCombinations2(string Target, string Source)
        {
            for (int i = 0; i < Target.Length; i++)
            {
                for (int j = 0; j < Source.Length; j++)
                {
                    var combination = BuildCombination(Target[i], Source, j);
                    var pattern = GetRepeatingPattern(combination);
                    
                    if (!string.IsNullOrEmpty(pattern))
                    {
                        if (!memo.ContainsKey(combination))
                            memo[combination] = (from c in combination.ToCharArray()
                                                 select c).Distinct().Count();
                    }
                }
            }
        }

        private static void LoopThroughCombinations(string Target, string Source)
        {
            for (int i = 0; i < Target.Length; i++)
            {
                for (int j = 0; j < Source.Length; j++)
                {
                    var combination = BuildCombination(Target[i], Source, j);
                    var pattern = GetRepeatingPattern(combination);
                    if (combination.Length == Target.Length &&
                        !string.IsNullOrEmpty(pattern) &&
                        !_combinations.Any(s => s == combination))
                    {
                        _combinations.Add(combination);
                    }

                    if (!string.IsNullOrEmpty(pattern))
                    {
                        if (!memo.ContainsKey(combination))
                            memo[combination] = (from c in combination.ToCharArray()
                                                 select c).Distinct().Count();
                    }
                }
            }
        }

        private static string BuildCombination(char key, string q, int post)
        {
            var checkLength = q.Length;
            var combination = key + q.Remove(post, 1);
            return combination.Length == checkLength ? combination : String.Empty; 
        }

        private static string GetRepeatingPattern(string input)
        {
            var _rst = string.Empty;
            var test = @"(.).*(\1{1,})";
            Regex regex = new Regex(PatternConst);//\b([a-z])\1\b -- \b([a-z])\1+\b
            var match = regex.Match(input);
            if (match.Success)
            {
                _rst = match.Groups[0].Value;
            }
            else 
            {
                var grpAux = (from c in input.ToCharArray()
                              group c by c into newGrp
                              where newGrp.Count() > 1
                              select new { repeating = newGrp.Key, Count = newGrp.Count()}).ToList();
                var sb = new StringBuilder();
                foreach (var grp in grpAux) 
                {
                    var generatingStr = new string(grp.repeating, grp.Count);
                    sb.Append(generatingStr);
                }

                _rst = sb.ToString();
            }
            return _rst;
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
