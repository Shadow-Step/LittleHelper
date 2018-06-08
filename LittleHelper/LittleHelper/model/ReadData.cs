using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LittleHelper.model
{
    class ReadData
    {
        public Rectangle Area;
        public int Sensitivity;
        public int FSize;

        public ReadData(Rectangle area, int sensitivity,int size)
        {
            this.Area = area;
            this.Sensitivity = sensitivity;
            this.FSize = size;
        }
    }
}
