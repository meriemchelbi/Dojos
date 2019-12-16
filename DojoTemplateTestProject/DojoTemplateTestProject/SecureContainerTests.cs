using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using DojoTemplateConsoleApp;

namespace DojoTemplateTestProject
{
    public class SecureContainerTests
    {
        [Theory]
        [InlineData(156218, 652527, 1148)]
        public void DisplayNumberOfMatchingPasswords(int lowerBound, int upperBound, int expectedResult)
        {
            var secureContainer = new SecureContainer();
            var result = secureContainer.FindNumberOfMatches(lowerBound, upperBound);

            Assert.Equal(expectedResult, result);
        }
        
        [Theory]
        [InlineData(123456, false)]
        [InlineData(112345, true)]
        [InlineData(111234, false)]
        [InlineData(111123, false)]
        [InlineData(111112, false)]
        [InlineData(111111, false)]
        [InlineData(123455, true)]
        [InlineData(123444, false)]
        [InlineData(123333, false)]
        [InlineData(122222, false)]
        [InlineData(123345, true)]
        [InlineData(122345, true)]
        [InlineData(123445, true)]
        [InlineData(122234, false)]
        [InlineData(123334, false)]
        [InlineData(111222, false)]
        [InlineData(122333, true)]
        [InlineData(122223, false)]
        [InlineData(112233, true)]
        [InlineData(122233, true)]
        [InlineData(222448, true)]
        public void PasswordContainsTwoAdjacentDigits(int password, bool containsAdjacentDoubleDigits)
        {
            var secureContainer = new SecureContainer();
            var result = secureContainer.HasTwoAdjacentMatchingDigits(password);

            result.Should().Be(containsAdjacentDoubleDigits);
        }

        [Theory]
        [InlineData(123456, true)]
        [InlineData(125726, false)]
        [InlineData(405789, false)]
        [InlineData(457893, false)]
        [InlineData(124078, false)]
        [InlineData(112345, true)]
        [InlineData(111234, true)]
        [InlineData(111123, true)]
        [InlineData(111112, true)]
        [InlineData(111111, true)]
        [InlineData(123455, true)]
        [InlineData(123444, true)]
        public void PasswordHasOnlyIncreasingDigits(int password, bool hasDecreasingDigits)
        {
            var secureContainer = new SecureContainer();
            var result = secureContainer.HasOnlyIncreasingDigits(password);

            result.Should().Be(hasDecreasingDigits);
        }

    }
}
