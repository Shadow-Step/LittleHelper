using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleHelper.model;


namespace LittleHelper.butcords
{
    class Castle
    {
        //public static Coords OPTIONS = new Coords(470, 85);
        public static class Options
        {
            public static Coords get_coords = new Coords(470, 85);
            public static Coords REPAIR = new Coords(450, 103);
            //public static Coords SETTINGS = new Coords(465, 140);

            public static class Settings
            {
                public static Coords get_coords = new Coords(465, 140);
                public static Coords LOAD_ARMY = new Coords(220, 145);
                public static Coords LOAD_CASTLE = new Coords(285, 145);
            }
            public static Coords ACCEPT = new Coords(450, 110);
        }
        
        
        
    }
}
