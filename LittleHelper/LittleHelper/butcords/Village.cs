using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleHelper.model;

namespace LittleHelper.butcords
{
    class Village
    {
        //Bar buttons
        public static Coords TAB_VILLAGE = new Coords(977,125);
        public static Coords TAB_CASTLE = new Coords(1028, 125);
        public static Coords TAB_RESOURCES = new Coords(1080, 125);
        public static Coords TAB_TRADE = new Coords(1129, 125);
        public static Coords TAB_ARMY = new Coords(1182, 125);
        public static Coords TAB_SCOUT = new Coords(1232, 125);
        public static Coords TAB_BANQUET = new Coords(1284, 125);
        public static Coords TAB_LORDS = new Coords(1335, 125);

        //public static Coords INFO = new Coords(477, 65);
        //Village info
        public static class Info
        {
            public static Coords get_coords = new Coords(1275, 172);
            public static Coords TAX_MINUS = new Coords(1313, 223);
            public static Coords TAX_PLUS = new Coords(1338, 223);
            public static Coords FOOD_MINUS = new Coords(1313, 272);
            public static Coords FOOD_PLUS = new Coords(1338, 272);
            public static Coords ALE_MINUS = new Coords(1313, 321);
            public static Coords ALE_PLUS = new Coords(1338, 321);
        }
        
        
    }
}
