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

        [Fact]
        public void ShouldReturnThreeWhenPIsAmzAndQISamz()
        {
            var P = "amz";
            var Q = "amz";
            var minDistinct = CodilityChallenge.PiCodeGM2(P, Q);
            minDistinct.Should().Be(3);

        }

        [Fact]
        public void ShouldReturn3WhenPIsabcdefAndQIsbcdefa()
        {
            var P = "abcdef";
            var Q = "bcdefa";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(3);

        }

        [Fact]
        public void ShouldReturn2WhenPIs_dcba_AndQIs_cbad()
        {
            var P = "dcba";
            var Q = "cbad";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(2);

        }

        [Fact]
        public void ShouldReturn1WhenPIsabacabadAndQIsdabacaba()
        {
            var P = "abacabad";
            var Q = "dabacaba";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(1);

        }

        [Fact]
        public void ShouldReturn3WhenPIs_bgeafdd_AndQIs_geafddc()
        {
            var P = "bgeafdd";
            var Q = "geafddc";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(3);

        }

        [Fact]
        public void ShouldReturn1WhenPIs_a_AndQIs_c()
        {
            var P = "a";
            var Q = "c";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(1);

        }

        [Fact]
        public void ShouldReturn2WhenPIs_ad_AndQIs_bc()
        {
            var P = "ad";
            var Q = "bc";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(2);

        }

        [Fact]
        public void ShouldReturn1WhenPIs_dadcfdeb_AndQIs_cdaddedd()
        {
            var P = "dadcfdeb";
            var Q = "cdaddedd";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(1);

        }

        [Fact]
        public void ShouldReturn2WhenPIs_aaaacbcddd_AndQIs_cdaddedd()
        {
            var P = "aaaacbcddd";
            var Q = "bbbbacdaaa";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(2);

        }

        [Fact]
        public void ShouldReturn4WhenPIs_adbecf_AndQIs_becfad()
        {
            var P = "adbecf";
            var Q = "becfad";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(4);

        }

        [Fact]
        public void ShouldReturn4WhenPIs_aaaabbbccd_AndQIs_bcdecdedee()
        {
            var P = "aaaabbbccd";
            var Q = "bcdecdedee";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(4);

        }

        [Fact]
        public void ShouldReturn5WhenPIs_aabbbddeefggi_AndQIs_dhcgjgifjgijj()
        {
            var P = "aabbbddeefggi";
            var Q = "dhcgjgifjgijj";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(5);

        }

        [Fact]
        public void ShouldReturn4WhenPIs_aaaabddddefi_AndQIs_cghjgeefhjgj()
        {
            var P = "aaaabddddefi";
            var Q = "cghjgeefhjgj";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(4);

        }

        [Fact]
        public void ShouldReturn4WhenPIs_abbbbddddeeeehi_AndQIs_beghjeefjfijjij()
        {
            var P = "abbbbddddeeeehi";
            var Q = "beghjeefjfijjij";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(4);

        }

        [Fact]
        public void ShouldReturn4WhenPIs_aaabbcdddeeggg_AndQIs_ddfccjfijfghhh()
        {
            var P = "aaabbcdddeeggg";
            var Q = "ddfccjfijfghhh";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(4);

        }

        [Fact]
        public void ShouldReturn3WhenPIs_bbgeafdddbbgeafdddbbgeafddd_AndQIs_ggeafddccggeafddccggeafddcc()
        {
            var P = "bbgeafdddbbgeafdddbbgeafddd";
            var Q = "ggeafddccggeafddccggeafddcc";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(3);

        }

        [Fact]
        public void ShouldReturn5WhenPIs_abbccdeeefhhhij_AndQIs_hcedkfhjklikkjl()
        {
            var P = "abbccdeeefhhhij";
            var Q = "hcedkfhjklikkjl";
            var minDistinct = PiCodeCodilityChallenge.Solution(P, Q);
            minDistinct.Should().Be(5);

        }

    }
}