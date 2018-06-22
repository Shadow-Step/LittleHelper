using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleHelper.stat;
namespace LittleHelper.butcords
{
    class AttackScreen
    {
        /// <summary> Only if target sellected </summary>
        public static Coords MAP_ATTACK_BUTTON = new Coords(1248, 232);
        public static Coords SETTINGS_BUTTON = new Coords(1253, 624);
        public static Coords SENDATTACK_BUTTON = new Coords(1253, 539);

        public static class LocalSettings
        {
            public static Coords X_BUTTON = new Coords(1009, 158);
            public static Coords LOADFORMATION_BUTTON = new Coords(675, 456);

            public static Coords FORM_0 = new Coords(615, 228);
            public static Coords FORM_1 = new Coords(615, 246);
            public static Coords FORM_2 = new Coords(615, 264);
            public static Coords FORM_3 = new Coords(615, 282);
            public static Coords FORM_4 = new Coords(615, 300);
            public static Coords FORM_5 = new Coords(615, 318);

            public static List<Coords> formations = new List<Coords>() { FORM_0, FORM_1, FORM_2, FORM_3, FORM_4, FORM_5 };
        }
        public static class SendingScreen
        {
            public static Coords ATTACK_BUTTON = new Coords(780, 362);
            public static Coords SEND_BUTTON = new Coords(818, 628);
        }
    }
}
