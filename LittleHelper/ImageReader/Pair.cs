using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgRdr
{
    public class Pair
    {
        public UInt32 X { get; set; }
        public UInt32 Y { get; set; }
        public Pair(UInt32 x, UInt32 y)
        {
            X = x;
            Y = y;
        }
        public Pair(int x, int y)
        {
            X = (UInt32)x;
            Y = (UInt32)y;
        }
    }
}
