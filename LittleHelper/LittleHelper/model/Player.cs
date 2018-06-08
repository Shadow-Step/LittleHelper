using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.model
{
    class Player
    {

        public int villages    = 0;
        public int gold        = 0;
        public int honor       = 0;
        public int fair        = 0;

        public Player()
        {
           
        }
        public Player(int villages, int gold, int honor, int fair)
        {
            this.villages = villages;
            this.gold = gold;
            this.honor = honor;
            this.fair = fair;
        }

    }
}
