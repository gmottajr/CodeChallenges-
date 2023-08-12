using CodeChallenge.Classes.CodeWars;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallengeTests.CodeWars
{
    public class MaximumSubarraySumShould
    {
        [Theory]
        [InlineData(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }, 6)]
        [InlineData(new int[] { -23, -30, 2, -14, -13, -2, 6, 38, 14, -23, 12, 3, 31, 39, 27, -34, -32, -37, 3, 29, 17, 1, 14, 22, 21, 26, -1, 22, 29, 16, -8, -32, 7, 5, 32, -38, 16, -8, -12, 27, -28, 9, 4, 3, -16, -1, 10, 32, 0, 6 }, 177)]
        [InlineData(new int[] { 38, -14, -17, -15, 23, -36, -32, -9, 21, 16, -36, -14, 38, -25, 30, 2, 14, -34, -31, 39, 5, -33, -27, -10, -5, 30, -20, -28, 27, -27, 39, 14, 23, -11, 30, -26, 20, -37, 1, -22, -1, 8, 2, 1, -28, 34, 27, 39, -10, -7 }, 56)]
        public void ReturnTheMaximumSubarraySum(int[] value, int expected)
        {
            var rst = MaximumSubarraySum.MaxSequence(value);
            rst.Should().Be(expected);
        }
    }
}
