using Leipper.PlutoRoverCoding.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Leipper.PlutoRoverCoding.NasaRover
{
    public class Rover : IRover
    {
        private readonly Regex VaildCommandRegex = new Regex("^([FBRL])+$");
        private int XAxisMax { get; }
        private int YAxisMax { get; }
        private Position Position { get;}

        private const char LeftCommand = 'L';
        private const char RightCommand = 'R';
        private const char BackCommand = 'B';
        private const char ForwardCommand = 'F';

        public Rover(int xAxisMax, int yAxisMax, int xAxisStart, int yAxisStart, Orientation orientation)
        {
            XAxisMax = xAxisMax;
            YAxisMax = yAxisMax;
            Position = new Position(xAxisStart, yAxisStart, orientation);

        }

        public Position MoveRover(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                throw new Exception("Invalid Command");
            }

            if (!IsVaildCommand(command))
            {
                throw new Exception("Invalid Command");
            }



            foreach (var letter in command)
            {
                if (letter == LeftCommand)
                {
                    Position.RotateOrientationRight();
                    continue;
                }

                if (letter == RightCommand)
                {
                    Position.RotateOrientationRight();
                    continue;
                }

                if (letter == ForwardCommand)
                {
                    Position.MoveForward();
                    continue;
                }

                if (letter == BackCommand)
                {
                    Position.MoveBackwards();
                    continue;
                }
            }

            return Position;
        }


        public bool IsVaildCommand(string command)
        {
           var i =  VaildCommandRegex.Matches(command);
            var b = VaildCommandRegex.IsMatch(command);
            return VaildCommandRegex.IsMatch(command);
        }
    }


}
