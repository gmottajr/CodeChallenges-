using CodeChallenge.Classes.CodeWars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace CodeChallengeTests.CodeWars
{
    public class IncreasingOrDecreasingCounterShould
    {
        [Theory]
        [InlineData(234559, true)]
        [InlineData(2, true)]
        [InlineData(34, true)]
        [InlineData(134579, true)]
        public void IsIncreasingNumberShouldReturnTrue(int value, bool expected)
        {
            //Arrange

            //Act
            var _rst = IncreasingOrDecreasingCounter.IsIncreasingNumber(value);
            //Assert
            _rst.Should().Be(expected);
        }

        [Theory]
        [InlineData(239559, false)]
        [InlineData(97732, false)]
        [InlineData(101, false)]
        public void IsIncreasingNumberShouldReturnFalse(int value, bool expected)
        {
            //Arrange

            //Act
            var _rst = IncreasingOrDecreasingCounter.IsIncreasingNumber(value);
            //Assert
            _rst.Should().Be(expected);
        }

        [Theory]
        [InlineData(97732, true)]
        [InlineData(5432, true)]
        [InlineData(9753, true)]
        public void IsDecreasingNumberShouldReturnTrue(int value, bool expected)
        {
            //Arrange
            //Act
            var _rst = IncreasingOrDecreasingCounter.IsDecreasingNumber(value);
            //Assert
            _rst.Should().Be(expected);
        }

        [Theory]
        [InlineData(239559, false)]
        [InlineData(977382, false)]
        [InlineData(101, false)]
        public void IsDecreasingNumberShouldReturnFalse(int value, bool expected)
        {
            //Arrange

            var _rst = IncreasingOrDecreasingCounter.IsDecreasingNumber(value);
            //Assert
            _rst.Should().Be(expected);
        }

        [Theory]
        [InlineData(234559, true)]
        [InlineData(2, true)]
        [InlineData(34, true)]
        [InlineData(134579, true)]
        [InlineData(97732, true)]
        [InlineData(5432, true)]
        [InlineData(9753, true)]
        [InlineData(400, true)]
        [InlineData(41110, true)]
        [InlineData(90001, false)]
        public void IsIncreasingNumberOrDecreasingNumberShouldReturnTrue(int value, bool expected)
        {
            //Arrange

            //Act
            var _rst = IncreasingOrDecreasingCounter.IsIncreasingNumberOrDecreasingNumber(value);
            //Assert
            _rst.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 10)]
        [InlineData(2, 100)]
        [InlineData(3, 475)]
        [InlineData(4, 1675)]
        [InlineData(5, 4954)]
        [InlineData(6, 12952)]
        public void ReturnTheTotalOccurrencesOfAllTheIncreasingOrDecreasingNumbers(int value, int expected)
        {
            //Act
            var _rst = IncreasingOrDecreasingCounter.OccurrencesOfAllTheIncreasingOrDecreasingNumbers(value);
            //Assert
            _rst.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 10)]
        [InlineData(2, 100)]
        [InlineData(3, 475)]
        [InlineData(4, 1675)]
        [InlineData(5, 4954)]
        [InlineData(6, 12952)]
        public void FindOutHowManyNotBouncy(int value, int expected)
        {
            //Act
            var _rst = IncreasingOrDecreasingCounter.TotalIncDec(value);
            //Assert
            _rst.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 10)]
        [InlineData(2, 100)]
        [InlineData(3, 475)]
        [InlineData(4, 1675)]
        [InlineData(5, 4954)]
        [InlineData(6, 12952)]
        public void FindOutDeOutroJeito(int value, int expected)
        {
            //Act
            var _rst = IncreasingOrDecreasingCounter.DeOutroJeito(value);
            //Assert
            _rst.Should().Be(expected);
        }


    }
}
