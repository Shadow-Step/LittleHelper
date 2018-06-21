using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgRdr
{
    public class WrapImg
    {
        public string Path;
        public int Bias_X;
        public int Bias_Y;
        public int Alpha;
        public bool Diagonal;

        public WrapImg(string path, int bias_y, int bias_x = 0, bool diagonal = false, int alpha = 15)
        {
            Path = path;
            Bias_Y = bias_y;
            Bias_X = bias_x;
            Alpha = alpha;
            Diagonal = diagonal;
        }
    }
}
