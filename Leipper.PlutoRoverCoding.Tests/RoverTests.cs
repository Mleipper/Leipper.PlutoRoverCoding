using FluentAssertions;
using Leipper.PlutoRoverCoding.Enums;
using Leipper.PlutoRoverCoding.NasaRover;
using System;
using Xunit;

namespace Leipper.PlutoRoverCoding.Tests
{
    public class RoverTests
    {
        [Fact]
        public void RoverWithInvalidCommand_ShouldThrow()
        {

            IRover subject = new Rover(100, 100, 0, 0, Orientation.North);

            string testCommand = "RLBllldfsa";

            subject.Invoking(y => y.MoveRover(testCommand))
                .Should().Throw<Exception>()
                .WithMessage("Invalid Command");
        }

        [Theory]
        [InlineData(100, 100, 0, 0, Orientation.North, "  ")]
        [InlineData(100, 100, 0, 0, Orientation.East, "  ")]
        [InlineData(100, 100, 0, 0, Orientation.North, "")]
        [InlineData(100, 100, 0, 0, Orientation.North, "FFaawad")]
        [InlineData(100, 100, 0, 0, Orientation.North, "thes")]
        [InlineData(100, 100, 0, 0, Orientation.North, "123")]
        public void RoverWithCommandWithWhiteSpace_ShouldThrow(int xMax, int yMax, int xStart, int yStart, Orientation orientation, string command)
        {

            IRover subject = new Rover(xMax, yMax, xStart, yStart, orientation);

            subject.Invoking(y => y.MoveRover(command))
                .Should().Throw<Exception>()
                .WithMessage("Invalid Command");
        }

        [Fact]
        public void MoveRoverTest_ShouldThrowException()
        {
            var postion = new Position(1, 1, Orientation.East, 100, 100);

            IRover subject = new Rover(100, 100, 0, 0, Orientation.North);

            string testCommand = "BBB";

            subject.Invoking(y => y.MoveRover(testCommand))
                .Should().Throw<IndexOutOfRangeException>()
                .WithMessage("Unable to move to area off grid");
        }


        [Theory]
        [InlineData(100, 100, Orientation.East, 1, 1, "FFFRRFLF",  3, 0, Orientation.South)]
        [InlineData(100, 100, Orientation.East, 0, 0, "FRF", 1, 1, Orientation.South)]
        public void MoveRoverTests(int xaxisMax, int yaxisMax, Orientation startingOrientation, int xStart, int yStart, string testCommand, int xFinalPos, int yFinalPos, Orientation FinalOrientation)
        {
            var postion = new Position(xFinalPos, yFinalPos, FinalOrientation, xaxisMax, yaxisMax);

            IRover subject = new Rover(xaxisMax, yaxisMax, xStart, yStart, startingOrientation);

            var result = subject.MoveRover(testCommand);

            result.Should().NotBeNull();
            result.GetCurrentOrientationAsString().Should().BeEquivalentTo(postion.GetCurrentOrientationAsString());
            result.GetCurrentXAxisPosition().Should().Be(postion.GetCurrentXAxisPosition());
            result.GetCurrentYAxisPosition().Should().Be(postion.GetCurrentYAxisPosition());
        }



    }
}
