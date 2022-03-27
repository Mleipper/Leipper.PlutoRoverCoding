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

        public Rover(int xAxisMax, int yAxisMax, int xAxisStart, int yAxisStart, Direction orientation)
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
