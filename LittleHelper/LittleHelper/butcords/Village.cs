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
        public static Coords TAB_VILLAGE = new Coords(363,47);
        public static Coords TAB_CASTLE = new Coords(382, 47);
        public static Coords TAB_RESOURCES = new Coords(401, 47);
        public static Coords TAB_TRADE = new Coords(420, 47);
        public static Coords TAB_ARMY = new Coords(439, 47);
        public static Coords TAB_SCOUT = new Coords(458, 47);
        public static Coords TAB_BANQUET = new Coords(477, 47);
        public static Coords TAB_LORDS = new Coords(496, 47);

        //public static Coords INFO = new Coords(477, 65);
        //Village info
        public static class Info
        {
            public static Coords get_coords = new Coords(477, 65);
            public static Coords TAX_MINUS = new Coords(485, 83);
            public static Coords TAX_PLUS = new Coords(494, 83);
            public static Coords FOOD_MINUS = new Coords(485, 100);
            public static Coords FOOD_PLUS = new Coords(494, 100);
            public static Coords ALE_MINUS = new Coords(485, 118);
            public static Coords ALE_PLUS = new Coords(494, 119);
        }
        
        
    }
}
