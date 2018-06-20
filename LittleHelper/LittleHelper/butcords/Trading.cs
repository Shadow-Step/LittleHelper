using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleHelper.model;
using System.Drawing;

namespace LittleHelper.butcords
{
    class Trading
    {
        public static Rectangle AREA_SELLBUTON = new Rectangle(1000, 520, 146, 31);

        public static Coords TAB_RESOURCES_4 = new Coords(250, 245);
        public static Coords TAB_FOOD_7 = new Coords(325, 245);
        public static Coords TAB_WEAPON_5 = new Coords(400, 245);
        public static Coords TAB_BANQUET_8 = new Coords(480, 245);

        public static Coords BUTTON_TARGETMENU = new Coords(670, 250);
        public static Coords BUTTON_BUY = new Coords(1070, 340);
        public static Coords BUTTON_SELL = new Coords(1070, 537);

        /// <summary> Wood, Apples, Bows, Venison </summary>
        public static Coords RES_1 = new Coords(320, 355);
        /// <summary> Stone, Cheese, Pikes, Furniture </summary>
        public static Coords RES_2 = new Coords(320, 395);
        /// <summary> Iron, Meat, Armour, Metalware </summary>
        public static Coords RES_3 = new Coords(320, 435);
        /// <summary> Pitch, Bread, Swords, Clothes </summary>
        public static Coords RES_4 = new Coords(320, 475);
        /// <summary> -----, Vegetables, Catapults, Wine </summary>
        public static Coords RES_5 = new Coords(320, 515);
        /// <summary> -----, Fish, -----, Salt </summary>
        public static Coords RES_6 = new Coords(320, 555);
        /// <summary> -----, Ale, -----, Spices </summary>
        public static Coords RES_7 = new Coords(320, 595);
        /// <summary> -----, -----, -----, Silk </summary>
        public static Coords RES_8 = new Coords(320, 635);

        public static List<Coords> resource_list = new List<Coords>() { RES_1, RES_2, RES_3, RES_4, RES_5, RES_6, RES_7, RES_8 };

        public static class TargetMenu
        {
            public static Coords TARGET_0 = new Coords(600, 292);
            public static Coords TARGET_1 = new Coords(600, 310);
            public static Coords TARGET_2 = new Coords(600, 328);
            public static Coords TARGET_3 = new Coords(600, 346);
            public static List<Coords> targets = new List<Coords>() { TARGET_0, TARGET_1, TARGET_2, TARGET_3 };
        }
        
    }
}
