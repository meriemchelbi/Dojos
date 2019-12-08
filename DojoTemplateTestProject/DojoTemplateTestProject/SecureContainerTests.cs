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
        [InlineData(156218, 652527, 1324)]
        public void DisplayNumberOfMatchingPasswords(int lowerBound, int upperBound, int expectedResult)
        {
            var secureContainer = new SecureContainer();
            var result = secureContainer.FindNumberOfMatches(lowerBound, upperBound);

            Assert.Equal(expectedResult, result);
        }
        
        [Theory]
        [InlineData(123456, false)]
        [InlineData(125526, true)]
        [InlineData(125556, false)]
        [InlineData(1222556, true)]
        [InlineData(112233, true)]
        [InlineData(112345, true)]
        [InlineData(123444, false)]
        [InlineData(11123444, false)]
        [InlineData(111122, true)]
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
        public void PasswordHasOnlyIncreasingDigits(int password, bool hasDecreasingDigits)
        {
            var secureContainer = new SecureContainer();
            var result = secureContainer.HasOnlyIncreasingDigits(password);

            result.Should().Be(hasDecreasingDigits);
        }

    }
}
