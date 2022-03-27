using Leipper.PlutoRoverCoding.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leipper.PlutoRoverCoding.NasaRover
{


    public class Position
    {
        private int XAxisPosition { get; set; }
        private int YAxisPosition { get; set; }

        private int XAxisMax { get; }
        private int YAxisMax { get; }


        private Orientation Orientation;


        public Position(int xAxisPosition, int yAxisPosition, Orientation orientation, int xAxisMax, int yAxisMax)
        {
            XAxisPosition = xAxisPosition;
            YAxisPosition = yAxisPosition;
            Orientation = orientation;
            XAxisMax = xAxisMax;
            YAxisMax = yAxisMax;
        }


        public void RotateOrientationRight()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    {
                        Orientation = Orientation.East;
                        break;
                    }
                case Orientation.East:
                    {
                        Orientation = Orientation.South;
                        break;
                    }
                case Orientation.South:
                    {
                        Orientation = Orientation.West;
                        break;
                    }
                case Orientation.West:
                    {
                        Orientation = Orientation.North;
                        break;
                    }
            }

        }

        public void RotateOrientationLeft()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    {
                        Orientation = Orientation.West;
                        break;
                    }
                case Orientation.East:
                    {
                        Orientation = Orientation.North;
                        break;
                    }
                case Orientation.South:
                    {
                        Orientation = Orientation.East;
                        break;
                    }
                case Orientation.West:
                    {
                        Orientation = Orientation.South;
                        break;
                    }
            }
        }

        public void MoveForward()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    {
                        IncrementYPosition(1);
                        break;
                    }
                case Orientation.East:
                    {
                        IncrementXPosition(1);
                        break;
                    }
                case Orientation.South:
                    {
                        IncrementYPosition(-1);
                        break;
                    }
                case Orientation.West:
                    {
                        IncrementXPosition(-1);
                        break;
                    }
            }

        }

        public void MoveBackwards()
        {
            switch (Orientation)
            {
                case Orientation.North:
                    {
                        IncrementYPosition(-1);
                        break;
                    }
                case Orientation.East:
                    {
                        IncrementXPosition(-1);
                        break;
                    }
                case Orientation.South:
                    {
                        IncrementYPosition(1);
                        break;
                    }
                case Orientation.West:
                    {
                        IncrementXPosition(1);
                        break;
                    }
            }
        }

        public string GetCurrentOrientationAsString()
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
            var incrementValue = YAxisPosition + amount;

            if (incrementValue < 0)
            {
                throw new IndexOutOfRangeException("Unable to move to area off grid");
            }

            if (incrementValue > YAxisMax)
            {
                throw new IndexOutOfRangeException("Unable to move to area off grid");
            }

            YAxisPosition = incrementValue;
        }

        public void IncrementXPosition(int amount)
        {
            var incrementValue = XAxisPosition + amount;

            if (incrementValue < 0)
            {
                throw new IndexOutOfRangeException("Unable to move to area off grid");
            }

            if (incrementValue > XAxisMax)
            {
                throw new IndexOutOfRangeException("Unable to move to area off grid");
            }

            XAxisPosition = incrementValue;
        }

    }
}
