using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.model
{
    class Coords
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        public Coords()
        {
            X = 0;
            Y = 0;
        }
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
