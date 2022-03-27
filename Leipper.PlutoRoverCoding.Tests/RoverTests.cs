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


        [Fact]
        public void RoverWithCommandWithNoLength_ShouldThrow()
        {

            IRover subject = new Rover(100, 100, 0, 0, Orientation.North);

            string testCommand = "";

            subject.Invoking(y => y.MoveRover(testCommand))
                .Should().Throw<Exception>()
                .WithMessage("Invalid Command");
        }


        [Fact]
        public void RoverWithCommandWithWhiteSpace_ShouldThrow()
        {

            IRover subject = new Rover(100, 100, 0, 0, Orientation.North);

            string testCommand = "  ";

            subject.Invoking(y => y.MoveRover(testCommand))
                .Should().Throw<Exception>()
                .WithMessage("Invalid Command");
        }

        [Fact]
        public void MoveRoverTest()
        {
            var postion = new Position(1, 1, Orientation.East, 100, 100);

            IRover subject = new Rover(100, 100, 0, 0, Orientation.North);

            string testCommand = "FRF";

            var result = subject.MoveRover(testCommand);

            result.Should().NotBeNull();
            result.GetCurrentOrientationAsString().Should().BeEquivalentTo(postion.GetCurrentOrientationAsString());
            result.GetCurrentXAxisPosition().Should().Be(postion.GetCurrentXAxisPosition());
            result.GetCurrentYAxisPosition().Should().Be(postion.GetCurrentYAxisPosition());
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



    }
}
