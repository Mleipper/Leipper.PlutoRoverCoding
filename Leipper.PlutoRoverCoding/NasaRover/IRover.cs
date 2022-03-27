using System;
using System.Collections.Generic;
using System.Text;

namespace Leipper.PlutoRoverCoding.NasaRover
{
    public interface IRover
    {
        Position MoveRover(string command);
    }
}
