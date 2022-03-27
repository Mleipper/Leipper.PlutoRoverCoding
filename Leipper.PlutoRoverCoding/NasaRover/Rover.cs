using Leipper.PlutoRoverCoding.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leipper.PlutoRoverCoding.NasaRover
{
    public class Rover : IRover
    {
        private int XAxisMax { get; }
        private int YAxisMax { get; }
        private int XAxisStart { get; }
        private int YAxisStart { get; }

        private Direction currentOrientation;

        public Rover(int xAxisMax, int yAxisMax, int xAxisStart, int yAxisStart, Direction orientation)
        {
            XAxisMax = xAxisMax;
            YAxisMax = yAxisMax;
            XAxisStart = xAxisStart;
            YAxisStart = yAxisStart;
            currentOrientation = orientation;
        }


    }


}
