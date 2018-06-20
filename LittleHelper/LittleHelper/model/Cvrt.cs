using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.model
{
    static class Cvrt
    {
        public static double ToSeconds(int minutes = 0, int seconds = 0)
        {
            return minutes * 60 + seconds;
        }
    }
}
