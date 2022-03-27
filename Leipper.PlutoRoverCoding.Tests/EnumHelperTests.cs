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
        [InlineData(Direction.East, "E")]
        [InlineData(Direction.South, "S")]
        [InlineData(Direction.West, "W")]
        [InlineData(Direction.North, "N")]
        public void GetEnumDescriptionTest(Direction direction, string expectedResult)
        {
            var directionName = EnumHelper.GetEnumDescription(direction);

            directionName.Should().NotBeNull();

            directionName.Should().BeEquivalentTo(expectedResult);
        }
    }
}
