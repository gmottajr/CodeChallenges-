using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeChallenge.Classes
{
    public class PiCodeCodilityChallenge
    {
        private const string PatternConst = @"([a-z])\1+";
        private static Dictionary<string, int> memo = new Dictionary<string, int>();
        public static int Solution(string P, string Q)
        {
            memo.Clear();

            if (P.Length == 0 || Q.Length == 0)
            {
                return 0;
            }

            if (P == Q)
            {
                return (from i in P.ToCharArray()
                        select i).Distinct().Count();
            }

            if (P.Length <= 2 && Q.Length <= 2)
            {
                return 1;
            }

            //var pattern = ExtractPatternFromTarget(P);

            //var patternQ = ExtractPatternFromTarget(Q);

            //if (!string.IsNullOrEmpty(pattern) && !string.IsNullOrEmpty(patternQ))
            //{
            //    if (CountDiscintingChar(pattern + patternQ) == 1)
            //        return 1;
            //}

            //if (!string.IsNullOrEmpty(pattern) && !string.IsNullOrEmpty(patternQ))
            //    patternQ = ExtractPatternFromTarget(pattern + patternQ);

            Intercalate(P, Q);
            Intercalate(Q, P);
            LoopThroughCombinations(P, Q);
            LoopThroughCombinations(Q, P);

            Console.WriteLine(string.Join(",", memo));

            if (memo.Count == 0)
                return 0;

            var gm = (from item in memo
                      group item by item.Value into groupGM
                      orderby groupGM.Key
                      select new { DistinctCount = groupGM.Key, Test = groupGM.Count() }).ToList();

            return gm.First().DistinctCount;
        }

        private static void Intercalate(string p, string q)
        {
            var _rst = new char[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                bool isEven = i % 2 == 0;
                _rst[i] = isEven ? p[i] : q[i];
                var firstPart = string.Join("", _rst.Where(c => c != '\0'));
                var combination = firstPart + p.Substring(firstPart.Length, p.Length - firstPart.Length);
                VerifyPatternFromTarget(combination);
                combination = firstPart + q.Substring(firstPart.Length, p.Length - firstPart.Length);
                VerifyPatternFromTarget(combination);
            };

            VerifyPatternFromTarget(string.Join("", _rst));
        }

        private static void VerifyPatternFromTarget(string target)
        {
            //var pattern = IsRepeatingPattern(target);

            //if (!string.IsNullOrEmpty(pattern))
            if(IsRepeatingPattern(target))
            {
                if (!memo.ContainsKey(target))
                    memo[target] = CountDiscintingChar(target);
            }

            //return pattern;
        }

        private static int CountDiscintingChar(string target)
        {
            return (from c in target.ToCharArray()
                    select c).Distinct().Count();
        }

        private static void LoopThroughCombinations(string Target, string Source)
        {
            for (int i = 0; i < Target.Length; i++)
            {
                for (int j = 0; j < Source.Length; j++)
                {
                    var combination = BuildCombination(Target[i], Source, j);
                    //var pattern = IsRepeatingPattern(combination);

                    //if (!string.IsNullOrEmpty(pattern))
                    if (IsRepeatingPattern(combination))
                    {
                        if (!memo.ContainsKey(combination))
                            memo[combination] = CountDiscintingChar(combination);
                    }
                }
            }
        }

        private static string BuildCombination(char key, string q, int post)
        {
            var checkLength = q.Length;
            var combination = key + (q.Length > 1 ? q.Remove(post, 1) : q);
            return combination;
        }

        private static bool IsRepeatingPattern(string input)
        {
            var _rst = false;

            if (input.Length <= 1)
                return _rst;

            Regex regex = new Regex(PatternConst);
            var match = regex.Match(input);
            _rst = match.Success;
            //if (match.Success)
            {
                //_rst = match.Groups[0].Value;
                
            }
            if (!match.Success)//else
            {
                var rgx = new Regex(@"(.).*(\1{1,})");
                var mtch = rgx.Match(input);
                _rst = mtch.Success; 

                //if (!mtch.Success)
                //    return String.Empty;

                //    var grpAux = (from c in input.ToCharArray()
                //              group c by c into newGrp
                //              where newGrp.Count() > 1
                //              orderby newGrp.Count()
                //              select new { repeating = newGrp.Key, Count = newGrp.Count() }).ToList();
                //var sb = new StringBuilder();
                //foreach (var grp in grpAux)
                //{
                //    var generatingStr = new string(grp.repeating, grp.Count);
                //    sb.Append(generatingStr);
                //}

                //_rst = grpAux.Count > 0 ?  new string(grpAux.First().repeating, grpAux.First().Count) : string.Empty;
            }
            return _rst;
        }
    }
}
