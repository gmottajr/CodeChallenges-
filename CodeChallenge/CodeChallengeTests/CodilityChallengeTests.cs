using CodeChallenge.Classes;
using FluentAssertions;

namespace CodeChallengeTests
{
    public class CodilityChallengeTests
    {
        /// <summary>
        /// Given P = "axxz", Q = "yzwy", your function should return 2. 
        /// String S must consist of at least two distinct letters in this case. 
        /// We can construct S = "yxxy", where the number of distinct letters is equal to 2, 
        /// and this is the only optimal solution.
        /// </summary>
        [Fact]
        public void ShouldReturnTwoWhenPIsAxxzAndQiYzwys()
        {
            var P = "axxz";
            var Q = "yzwy";
            var minDistinct = CodilityChallenge.PiCodeGM2(P, Q);
            minDistinct.Should().Be(2);

        }

        /// <summary>
        /// Given P = "abc", Q = "bcd", your function should return 2. 
        /// All possible strings S that can be constructed are: 
        /// "abc", "abd", "acc", "acd", "bbc", "bbd", "bcc", "bcd". 
        /// The minimum number of distinct letters is 2, 
        /// which be obtained by constructing the following strings: "acc", "bbc", "bbd", "bcc".
        /// </summary>
        [Fact]
        public void ShouldReturnTwoWhenPIsabcAndQisbcd()
        {
            string P = "abc";
            string Q = "bcd";
            var minDistinct = CodilityChallenge.PiCodeGM2(P, Q);
            minDistinct.Should().Be(2);

        }

        /// <summary>
        /// Given P = "bacad", Q = "abada", your function should return 1. 
        /// We can choose the letter 'a' in each position, so S can be equal to "aaaaa"
        /// </summary>
        [Fact]
        public void ShouldReturnOneWhenPIsBacadAndQISabada()
        {
            var P = "bacad";
            var Q = "abada";
            var minDistinct = CodilityChallenge.PiCodeGM2(P, Q);
            minDistinct.Should().Be(1);

        }
    }
}