using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleHelper.stat;
using System.Drawing;

namespace LittleHelper.butcords
{
    enum FilterEnabled
    {
        None,
        Scout,
        Army,
        AI
    }
    class MainScreen
    {
        //MAIN BAR
        public static Coords TAB_MAP         = new Coords(925, 90);
        public static Coords TAB_VILLAGE     = new Coords(975, 90);
        public static Coords TAB_PARISH      = new Coords(1025, 90);
        public static Coords TAB_RESEARCH    = new Coords(1080, 90);
        public static Coords TAB_RANK        = new Coords(1130, 90);
        public static Coords TAB_QUEST       = new Coords(1180, 90);
        public static Coords TAB_ATTACK      = new Coords(1230, 90);
        public static Coords TAB_REPORTS     = new Coords(1285, 90);
        public static Coords TAB_FRACTION    = new Coords(1330, 90);

        //OTHER
        public static Coords NEXTVILLAGE_BUTTON = new Coords(928, 61);
        public static Coords FREECARD_BUTTON    = new Coords(34, 217);
        public static Coords CLOSECARD_BUTTON   = new Coords(1152, 140);
        public static Coords PLAYERINFO_BUTTON  = new Coords(1260, 662);
        public static Coords MAIL_BUTTON        = new Coords(954, 34);
        public static Coords FILTER_BUTTON      = new Coords(1190,712);

        public static Coords SELECTED_CASTLE = new Coords(1190, 712);
        public static Coords MIDDLE_OFSCREEN = new Coords(580,420);
        //
        public static Rectangle READER_AREA = new Rectangle(0, 114, 1159, 613);
        public static Rectangle SELECTED_CASTLE_AREA = new Rectangle(540, 370, 80, 70);

        public static class Map
        {
            public static Coords SCOUT_BUTTON   = new Coords(1263, 201);
            public static Coords SEND_SCOUT     = new Coords(818, 561);
            public static Coords X_BUTTON       = new Coords(905,204);
        }
        public static class PlayerInfo
        {
            public static Coords VILLAGE_1 = new Coords(820, 315);
            public static Coords VILLAGE_2 = new Coords(820, 350);
            public static Coords VILLAGE_3 = new Coords(820, 385);
            public static Coords VILLAGE_4 = new Coords(820, 420);
            public static Coords VILLAGE_5 = new Coords(820, 455);
            public static Coords VILLAGE_6 = new Coords(820, 490);
            public static Coords VILLAGE_7 = new Coords(820, 525);
            public static Coords VILLAGE_8 = new Coords(820, 560);
            public static Coords VILLAGE_9 = new Coords(820, 595);
            public static Coords VILLAGE_10 = new Coords(820, 630);
            public static List<Coords> village_list = new List<Coords>() { VILLAGE_1, VILLAGE_2, VILLAGE_3, VILLAGE_4, VILLAGE_5, VILLAGE_6, VILLAGE_7 };
        }
        public static class Filters
        {
            public static FilterEnabled filterEnabled = FilterEnabled.None;
            public static Coords SCOUT_FILTER = new Coords(1228, 228);
            public static Coords ARMY_FILTER = new Coords(1264, 228);
            public static Coords AI_FILTER = new Coords(1298, 228);

            public static Dictionary<FilterEnabled, Coords> filters = new Dictionary<FilterEnabled, Coords>()
            {
                { FilterEnabled.Scout, SCOUT_FILTER},
                { FilterEnabled.Army, ARMY_FILTER},
                { FilterEnabled.AI, AI_FILTER}
            };

            public static Coords ERASE_FILTER = new Coords(1221, 362);
        }
    }
}
