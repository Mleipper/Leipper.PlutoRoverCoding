﻿using Leipper.PlutoRoverCoding.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leipper.PlutoRoverCoding.NasaRover
{


    public class Position
    {
        private int XAxisPosition { get; set; }
        private int YAxisPosition { get; set; }

        private Direction Orientation;


        public Position(int xAxisPosition, int yAxisPosition, Direction orientation)
        {
            this.XAxisPosition = xAxisPosition;
            this.YAxisPosition = yAxisPosition;
            this.Orientation = orientation;
        }

        public string GetCurrentOrientation()
        {
            return EnumHelper.GetEnumDescription(Orientation);
        }

        public int GetCurrentXAxisPosition()
        {
            return XAxisPosition;
        }

        public int GetCurrentYAxisPosition()
        {
            return YAxisPosition;
        }

        public void IncrementYPosition(int amount)
        {
            YAxisPosition += amount;
        }

        public void IncrementXPosition(int amount)
        {
            YAxisPosition += amount;
        }

    }
}