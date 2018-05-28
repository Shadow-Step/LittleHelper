﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleHelper.model;

namespace LittleHelper.model
{
    class Buttons
    {
        //Start of main buttons bar
        int start_point = 345;
        //Space between buttons
        int space = 18;

        //MAIN BUTTONS
        public static Coords MAP_BUTTON         = new Coords(345, 35);
        public static Coords VILLAGE_BUTTON     = new Coords(363, 35);
        public static Coords PARISH_BUTTON      = new Coords(381, 35);
        public static Coords RESEARCH_BUTTON    = new Coords(399, 35);
        public static Coords RANK_BUTTON        = new Coords(417, 35);
        public static Coords QUEST_BUTTON       = new Coords(435, 35);
        public static Coords ATTACK_BUTTON      = new Coords(453, 35);
        public static Coords REPORTS_BUTTON     = new Coords(471, 35);
        public static Coords FRACTION_BUTTON    = new Coords(489, 35);
        public static Coords NEXTVILLAGE_BUTTON = new Coords(345, 23);
        //VILLAGE BUTTONS
        public static Coords VILLAGE_VILLAGE;
        public static Coords VILLAGE_CASTLE;
        public static Coords VILLAGE_RESOURCES;
        public static Coords VILLAGE_TRADE;
        public static Coords VILLAGE_ARMY;
        public static Coords VILLAGE_SCOUT;
        public static Coords VILLAGE_BANQUET;
        public static Coords VILLAGE_LORDS;


        public static void InitCoords()
        {
           
        }
    }
}
