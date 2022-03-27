using FluentAssertions;
using Leipper.PlutoRoverCoding.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Leipper.PlutoRoverCoding.Tests
{
    public class EnumHelperTests
    {
        [Theory]
        [InlineData(Orientation.East, "E")]
        [InlineData(Orientation.South, "S")]
        [InlineData(Orientation.West, "W")]
        [InlineData(Orientation.North, "N")]
        public void GetEnumDescriptionTest(Orientation direction, string expectedResult)
        {
            var directionName = EnumHelper.GetEnumDescription(direction);

            directionName.Should().NotBeNull();

            directionName.Should().BeEquivalentTo(expectedResult);
        }
    }
}
