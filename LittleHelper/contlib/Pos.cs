using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contlib
{
    public class Pos
    {
        public UInt32 X { get; set; }
        public UInt32 Y { get; set; }
        public Pos(UInt32 x, UInt32 y)
        {
            X = x;
            Y = y;
        }
        public Pos(int x, int y)
        {
            X = (UInt32)x;
            Y = (UInt32)y;
        }
    }
}
