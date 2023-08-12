using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Classes.CodeWars
{
    public static class CutHope
    {
        public static int GetSmallestHope(int[] value)
        {
            var smallest = value.Where( C => C != 0).Min(c => c);
            return smallest;
        }

        public static int[] Cut(int[] value)
        {
            var gotTheSmallest = GetSmallestHope(value);
            var _rst = new int[value.Length];
            for (int i = 0; i < value.Length; i++)
            {
                _rst[i] = value[i] - gotTheSmallest;
            }

            int[] _rst2 = value.Where(c => c > 0).Select(c => c - gotTheSmallest).ToArray();
            return _rst2;
        }

        public static int[] Process(int[] value)
        {
            var totalOfHopesForEachIteration = new List<int>();
            totalOfHopesForEachIteration.Add(value.Count(c => c > 0));
            var cutHope = Cut(value);
            do
            {
                totalOfHopesForEachIteration.Add(cutHope.Count(c => c > 0));
                cutHope = Cut(cutHope);

            } while (cutHope.Max(c => c) > 0);

            return totalOfHopesForEachIteration.ToArray();
        }
    }
}
