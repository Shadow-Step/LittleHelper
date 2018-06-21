using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHalper.stat
{
    class Coords
    {
        public UInt32 X { get; set; }
        public UInt32 Y { get; set; }
        
        public Coords()
        {
            X = 0;
            Y = 0;
        }
        public Coords(UInt32 x, UInt32 y)
        {
            X = x;
            Y = y;
        }
    }
}
