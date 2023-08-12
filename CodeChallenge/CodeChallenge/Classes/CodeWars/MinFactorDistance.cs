using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge.Classes.CodeWars
{
    public static class MinFactorDistance
    {
        public static int MinDistance(int n)
        {
            var factors = Enumerable.Range(1, n).Where(x => n % x == 0).ToArray();
            return factors.Zip(factors.Skip(1), (x, y) => y - x).Min();
        }
    }
}
