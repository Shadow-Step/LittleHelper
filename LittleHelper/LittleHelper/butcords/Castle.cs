using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleHalper.stat;


namespace LittleHelper.butcords
{
    class Castle
    {
        public static Coords CLEAR_PLACE = new Coords(1080, 700);
        public static class Options
        {
            public static Coords get_coords = new Coords(1270, 230);
            public static Coords REPAIR = new Coords(1219, 282);
            //public static Coords SETTINGS = new Coords(465, 140);

            public static class Settings
            {
                public static Coords get_coords = new Coords(1261, 380);
                public static Coords LOAD_ARMY = new Coords(590, 387);
                public static Coords LOAD_CASTLE = new Coords(760, 387);
                public static Coords OK_BUTTON = new Coords(790, 575);
            }
            public static Coords ACCEPT = new Coords(1218, 300);
        }
        
        
        
    }
}
