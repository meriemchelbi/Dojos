using DojoTemplateConsoleApp;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DojoTemplateTestProject
{
    public class FloorValidatorTests
    {
        private readonly FloorValidator _sut;

        public FloorValidatorTests()
        {
            _sut = new FloorValidator();
        }

        [Fact]
        public void ValidateFloor_FloorWithinValidRange_ReturnsTrue()
        {
            var result = _sut.ValidateFloor(5);

            result.Should().BeTrue();
        }
        
        [Fact]
        public void ValidateFloor_FloorTooLow_ReturnsFalse()
        {
            var result = _sut.ValidateFloor(-2);

            result.Should().BeFalse();
        }
        
        [Fact]
        public void ValidateFloor_FloorTooHigh_ReturnsFalse()
        {
            var result = _sut.ValidateFloor(7);

            result.Should().BeFalse();
        }
    }
}
