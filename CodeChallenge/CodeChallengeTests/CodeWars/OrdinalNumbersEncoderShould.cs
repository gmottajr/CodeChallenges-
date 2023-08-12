using CodeChallenge.Classes.CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallengeTests.CodeWars
{
    public class OrdinalNumbersEncoderShould
    {
        [Theory]
        [InlineData(1, "1st")]
        [InlineData(2, "2nd")]
        [InlineData(3, "3rd")]
        [InlineData(4, "4th")]
        [InlineData(6, "6th")]
        [InlineData(9, "9th")]
        [InlineData(10, "10th")]
        [InlineData(11, "11th")]
        [InlineData(12, "12th")]
        [InlineData(149, "149th")]
        [InlineData(903, "903rd")]
        public void GenerageOrdinal(int value, string expected)
        {
            var _rst = OrdinalNumbersEncoder.ConvertToOrdinal(value);
            Assert.Equal(expected, _rst);
        }

        [Theory]
        [InlineData(1, "1st")]
        [InlineData(2, "2d")]
        [InlineData(3, "3d")]
        [InlineData(4, "4th")]
        [InlineData(6, "6th")]
        [InlineData(9, "9th")]
        [InlineData(10, "10th")]
        [InlineData(11, "11th")]
        [InlineData(12, "12th")]
        [InlineData(13, "13th")]
        [InlineData(149, "149th")]
        [InlineData(903, "903d")]
        public void GenerageOrdinalBrief(int value, string expected)
        {
            var _rst = OrdinalNumbersEncoder.ConvertToOrdinal(value, true);
            Assert.Equal(expected, _rst);
        }
    }
}
