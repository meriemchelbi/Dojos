using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DojoTemplateTestProject
{
    public class TimeConversion
    {
        [Fact]
        public void Test1()
        {
            var result = ConvertTime("07:05:45PM");

            Assert.Equal("19:05:45", result);
        }

        private string ConvertTime(string input)
        {
            var convertedHours = string.Empty;
            var hours = input.Substring(0, 2);

            if (input.Substring(8) == "AM")
                convertedHours = hours == "12" ? "00" : hours;

            else
                convertedHours = hours == "12"
                                ? "12"
                                : (int.Parse(hours) + 12).ToString();

            var minutesSeconds = input.Substring(2, 6);

            return convertedHours + minutesSeconds;
        }
    }
}
