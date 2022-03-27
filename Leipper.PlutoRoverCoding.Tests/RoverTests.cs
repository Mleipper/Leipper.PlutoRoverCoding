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

            IRover subject = new Rover(100, 100, 0, 0, Direction.North);

            string testCommand = "RLBllldfsa";

            subject.Invoking(y => y.MoveRover(testCommand))
                .Should().Throw<Exception>()
                .WithMessage("Invalid Command");
        }


        [Fact]
        public void RoverWithCommandWithNoLength_ShouldThrow()
        {

            IRover subject = new Rover(100, 100, 0, 0, Direction.North);

            string testCommand = "";

            subject.Invoking(y => y.MoveRover(testCommand))
                .Should().Throw<Exception>()
                .WithMessage("Invalid Command");
        }


        [Fact]
        public void RoverWithCommandWithWhiteSpace_ShouldThrow()
        {

            IRover subject = new Rover(100, 100, 0, 0, Direction.North);

            string testCommand = "  ";

            subject.Invoking(y => y.MoveRover(testCommand))
                .Should().Throw<Exception>()
                .WithMessage("Invalid Command");
        }




    }
}
