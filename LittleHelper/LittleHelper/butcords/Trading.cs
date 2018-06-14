using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleHelper.model;

namespace LittleHelper.butcords
{
    class Trading
    {
        public static Coords TAB_RESOURCES_4 = new Coords(95, 95);
        public static Coords TAB_FOOD_7 = new Coords(125, 95);
        public static Coords TAB_WEAPON_5 = new Coords(155, 95);
        public static Coords TAB_BANQUET_8 = new Coords(185, 95);

        public static Coords BUTTON_TARGETMENU = new Coords(230, 95);
        public static Coords BUTTON_BUY = new Coords(395, 125);
        public static Coords BUTTON_SELL = new Coords(395, 198);

        /// <summary> Wood, Apples, Bows, Venison </summary>
        public static Coords RES_1 = new Coords(125, 132);
        /// <summary> Stone, Cheese, Pikes, Furniture </summary>
        public static Coords RES_2 = new Coords(125, 150);
        /// <summary> Iron, Meat, Armour, Metalware </summary>
        public static Coords RES_3 = new Coords(125, 162);
        /// <summary> Pitch, Bread, Swords, Clothes </summary>
        public static Coords RES_4 = new Coords(125, 178);
        /// <summary> -----, Vegetables, Catapults, Wine </summary>
        public static Coords RES_5 = new Coords(125, 192);
        /// <summary> -----, Fish, -----, Salt </summary>
        public static Coords RES_6 = new Coords(125, 208);
        /// <summary> -----, Ale, -----, Spices </summary>
        public static Coords RES_7 = new Coords(125, 222);
        /// <summary> -----, -----, -----, Silk </summary>
        public static Coords RES_8 = new Coords(125, 235);

        public static List<Coords> resource_list = new List<Coords>() { RES_1, RES_2, RES_3, RES_4, RES_5, RES_6, RES_7, RES_8 };

        public static class TargetMenu
        {
            public static Coords TARGET_1 = new Coords(230, 110);
            public static Coords TARGET_2 = new Coords(230, 115);
            public static Coords TARGET_3 = new Coords(230, 122);
            public static Dictionary<int, Coords> targets = new Dictionary<int, Coords>()
            {
                {1,TARGET_1 },
                {2,TARGET_2 },
                {3,TARGET_3}
            };
        }
        
    }
}
