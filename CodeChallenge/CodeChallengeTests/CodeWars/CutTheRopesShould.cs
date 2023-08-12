using CodeChallenge.Classes.CodeWars;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallengeTests.CodeWars
{
    /// <summary>
    /// You are given N ropes, where the length of each rope is a positive integer. At each step, you have to reduce all the ropes by the length of the smallest rope.
    /// The step will be repeated until no ropes are left. Given the length of N ropes, print the number of ropes that are left before each step.
    /// For a = [3, 3, 2, 9, 7], the result should be [5, 4, 2, 1]
    /// </summary>
    public class CutTheRopesShould
    {
        [Theory]
        [InlineData(new int[] { 3, 3, 2, 9, 7 }, 2)]
        [InlineData(new int[] { 4,5, 16, 20, -1 }, -1)]
        [InlineData(new int[] { 78, 93, 23 }, 23)]
        [InlineData(new int[] { 78, 93, 23, 9, 0 }, 9)]
        public void FindTheSmallestRope(int[] value, int expected)
        {
            //Arrange

            //Act
            int smallestRope = CutHope.GetSmallestHope(value);
            //Assert
            smallestRope.Should().Be(expected);
        }

        [Theory]
        [InlineData(new int[] { 3, 3, 2, 9, 7 }, new int[] { 1, 1, 0, 7, 5 })]
        [InlineData(new int[] { 4, 5, 16, 20, 1 }, new int[] { 3, 4, 15, 19, 0})]
        [InlineData(new int[] { 78, 93, 23 }, new int[] { 55, 70, 0 })]
        public void CutEachRopeByTheLengthOfTheSmallest(int[] value, int[] expected)
        {
            //Arrange

            //Act
            int[] CutSectionsOfTheRopes = CutHope.Cut(value);
            //Assert
            CutSectionsOfTheRopes.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(new int[] { 3, 3, 2, 9, 7 }, new int[] { 5, 4, 2, 1 })]
        [InlineData(new int[] { 4, 5, 16, 20, 1, 16 }, new int[] { 6, 5, 4, 3, 1})]
        [InlineData(new int[] { 78, 93, 23, 4, 23, 4, 2 }, new int[] { 7, 6, 4, 2, 1})]
        public void RepeatUntilNoRopesAreLeftPrintingTheNumberOfRopesThatAreLeftBeforeEachStep(int[] value, int[] expected) 
        {
            //Arrange

            //Act
            int[] CutSectionsOfTheRopes = CutHope.Process(value);
            //Assert
            CutSectionsOfTheRopes.Should().BeEquivalentTo(expected);
        }
    }
}
