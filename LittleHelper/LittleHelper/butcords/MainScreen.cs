using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleHelper.model;

namespace LittleHelper.butcords
{
    class MainScreen
    {
        //MAIN BAR
        public static Coords TAB_MAP         = new Coords(345, 35);
        public static Coords TAB_VILLAGE     = new Coords(363, 35);
        public static Coords TAB_PARISH      = new Coords(381, 35);
        public static Coords TAB_RESEARCH    = new Coords(399, 35);
        public static Coords TAB_RANK        = new Coords(417, 35);
        public static Coords TAB_QUEST       = new Coords(435, 35);
        public static Coords TAB_ATTACK      = new Coords(453, 35);
        public static Coords TAB_REPORTS     = new Coords(471, 35);
        public static Coords TAB_FRACTION    = new Coords(489, 35);

        //OTHER
        public static Coords NEXTVILLAGE_BUTTON = new Coords(345, 23);
        public static Coords FREECARD_BUTTON    = new Coords(15, 85);
        public static Coords CLOSECARD_BUTTON   = new Coords(427, 53);
        public static Coords PLAYERINFO_BUTTON  = new Coords(465, 243);
        public static Coords MAIL_BUTTON        = new Coords(355, 13);
        //
        public static class Map
        {
            public static Coords SCOUT_BUTTON   = new Coords(467, 73);
            public static Coords SEND_SCOUT     = new Coords(305, 210);
        }
        public static class PlayerInfo
        {
            public static Coords VILLAGE_1 = new Coords(305,117);
            public static Coords VILLAGE_2 = new Coords(305, 130);
            public static Coords VILLAGE_3 = new Coords(305, 143);
        }
    }
}
