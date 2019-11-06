using System;
using DojoTemplateConsoleApp;
using Xunit;

namespace DojoTemplateTestProject
{
    public class CarriageTests
    {
        [Fact]
        public void IncrementerDecreasesCapacityByOne()
        {
            var sut = new Carriage("a")
            {
                NumberOfSeatsRemaining = 42
            };
            
            sut.Board();
            
            Assert.Equal(41, sut.NumberOfSeatsRemaining);

        }

        [Fact]
        public void AlightIncreasesCapacityByOne()
        {
            var sut = new Carriage("a")
            {
                NumberOfSeatsRemaining = 40
            };

            sut.Alight();

            Assert.Equal(41, sut.NumberOfSeatsRemaining);

        }


    }

    
}
