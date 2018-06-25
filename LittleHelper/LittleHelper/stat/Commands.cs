using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LittleHelper.butcords;
using ImgRdr;
using System.Drawing;
using System.IO;

namespace LittleHelper.stat
{
    enum CastleOptions
    {
        OnlyRepair,
        RepairAndRestoreArmy,
        RepairAndRestoreCastle,
        RepairAll
    }
    

    class Commands
    {
        static Random rand = new Random();
        
        public delegate void Operation(); // public

        public static Dictionary<int, Operation> sleep_commands = new Dictionary<int, Operation>()
        {
            {0,()=>
            {
                Controller.AutoClick(MainScreen.TAB_REPORTS);
                Thread.Sleep(rand.Next(3000,5000));
            } },
            {1,()=>
            {
                Controller.AutoClick(MainScreen.TAB_MAP);
                Controller.AutoClick(MainScreen.TAB_QUEST);
                Thread.Sleep(rand.Next(700,1500));
            } },
            {2,()=>
            {
                Controller.AutoClick(MainScreen.TAB_PARISH);
                Thread.Sleep(rand.Next(2000,4000));
                Controller.AutoClick(Village.TAB_CASTLE);
                Thread.Sleep(rand.Next(1800,2500));
                Controller.AutoClick(MainScreen.TAB_MAP);
            } },
            {3,()=>
            {
                Controller.AutoClick(MainScreen.TAB_RANK);
                Thread.Sleep(rand.Next(1000,2000));
            } },
            {4,()=>
            {
                Controller.AutoClick(MainScreen.MAIL_BUTTON);
                Thread.Sleep(rand.Next(5000,7000));
            } },
            {5,()=>
            {
                Controller.AutoClick(MainScreen.TAB_MAP);
                Thread.Sleep(rand.Next(10000,15000));
            } },
            {6,()=>
            {
                
                ImageReader reader = new ImageReader();
                var x = reader.FindImageOnScreen(Research.READER_AREA,"research_bar.bmp",0);
                if(x.Count == 0)
                {
                    Controller.AutoClick(MainScreen.TAB_RESEARCH);
                    Thread.Sleep(2000);
                    Controller.AutoClick(Research.SKILL_4);
                    WriteToLog("I click research!");
                }
                Thread.Sleep(rand.Next(10000,15000));
            } },
        }; // public

        public static void RepairCastle(int iterations, CastleOptions options)
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_CASTLE);
            while (iterations != 0)
            {
                Controller.AutoClick(Castle.Options.get_coords);
                Controller.AutoClick(Castle.Options.REPAIR);
                Thread.Sleep(rand.Next(1800,2500));
                if(options != CastleOptions.OnlyRepair)
                {
                    if (options == CastleOptions.RepairAndRestoreArmy || options == CastleOptions.RepairAll)
                    {
                        Controller.AutoClick(Castle.Options.Settings.get_coords);
                        Controller.AutoClick(Castle.Options.Settings.LOAD_ARMY);
                        Controller.AutoClick(Castle.Options.Settings.OK_BUTTON);
                        Controller.AutoClick(Castle.CLEAR_PLACE);
                        Controller.AutoClick(Castle.Options.ACCEPT);
                        Thread.Sleep(rand.Next(1800,2400));
                    }
                    if (options == CastleOptions.RepairAndRestoreCastle || options == CastleOptions.RepairAll)
                    {
                        Controller.AutoClick(Castle.Options.Settings.get_coords);
                        Controller.AutoClick(Castle.Options.Settings.LOAD_CASTLE);
                        Controller.AutoClick(Castle.Options.ACCEPT);
                        Thread.Sleep(rand.Next(1800,2200));
                    }
                }
                Controller.AutoClick(MainScreen.NEXTVILLAGE_BUTTON);
                Thread.Sleep(rand.Next(1000,1400));
                iterations--;
            }
        }
        public static void IncreaseTaxes(int value)
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_VILLAGE);
            Controller.AutoClick(Village.Info.get_coords);
            Thread.Sleep(rand.Next(400, 700));
            for (int i = 0; i < value; i++)
            {
                Controller.AutoClick(Village.Info.TAX_PLUS);
                Thread.Sleep(rand.Next(100, 200));
            }
        }
        public static void DecreaseTaxes(int value)
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_VILLAGE);
            Controller.AutoClick(Village.Info.get_coords);
            Thread.Sleep(rand.Next(400, 700));
            for (int i = 0; i < value; i++)
            {
                Controller.AutoClick(Village.Info.TAX_MINUS);
                Thread.Sleep(rand.Next(100,200));
            }
        }
        
        public static void ArmyBuy(Coords[] unit, int[] value,int times)
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_ARMY);
            for (int t = 0; t < times; t++)
            {
                Thread.Sleep(rand.Next(800,1200));
                for (int i = 0; i < unit.Length; i++)
                {
                    for (int x = 0; x < value[i]; x++)
                    {
                        Controller.AutoClick(unit[i]);
                        Thread.Sleep(rand.Next(50,80));
                    }
                }
                Controller.AutoClick(MainScreen.NEXTVILLAGE_BUTTON);
            }
            
        }
        public static void ArmyBuy(Coords unit, int value)
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_ARMY);
                Thread.Sleep(rand.Next(800, 1200));
                    for (int x = 0; x < value; x++)
                    {
                        Controller.AutoClick(unit);
                        Thread.Sleep(rand.Next(50, 80));
                    }
            Commands.WriteToLog("Try to buy some catapults");
        }
        public static void ResearchSkill(Coords tab, Coords skill)
        {
            Controller.AutoClick(MainScreen.TAB_RESEARCH);
            Controller.AutoClick(tab);
            Controller.AutoClick(skill);
        }
        public static void SendTraders(Coords tab, int[] resources, int[] targets)
        {
            ResetVillageNumber();
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_TRADE);
            Controller.AutoClick(tab);
            foreach (var x in targets)
            {
                Random rand = new Random();
                Controller.AutoClick(Trading.RES_1);
                Controller.AutoClick(Trading.RES_2);
                Controller.AutoClick(Trading.resource_list[rand.Next(resources[0],resources[1])]);
                Controller.AutoClick(Trading.BUTTON_TARGETMENU);
                Controller.AutoClick(Trading.TargetMenu.targets[x]);
                Controller.AutoClick(Trading.BUTTON_SELL);
                Thread.Sleep(rand.Next(800,1200));
                Controller.AutoClick(MainScreen.NEXTVILLAGE_BUTTON);
                Thread.Sleep(rand.Next(1800,2300));
            }
        }
        public static void ResetVillageNumber()
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(MainScreen.TAB_MAP);
            Controller.AutoClick(MainScreen.PLAYERINFO_BUTTON);
            Thread.Sleep(rand.Next(4000,6000));
            Controller.AutoClick(MainScreen.PlayerInfo.VILLAGE_1);
        }
        public static void ResetVillageNumber(int number)
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(MainScreen.TAB_MAP);
            Controller.AutoClick(MainScreen.PLAYERINFO_BUTTON);
            Thread.Sleep(rand.Next(2000, 3000));
            Controller.AutoClick(MainScreen.PlayerInfo.village_list[number]);
            Thread.Sleep(2000);
        }
        public static void ZoomOutMap(int times)
        {
            Controller.WheelRotate(-1, times);
            Thread.Sleep(500 * times);
        }
        public static void ActDectFilter(Coords filter)
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(MainScreen.TAB_MAP);
            Controller.MoveTo(MainScreen.FILTER_BUTTON);
            Thread.Sleep(100);
            Controller.MoveTo(1360 / 2, 768 / 2);
            Thread.Sleep(1000);
            Controller.AutoClick(MainScreen.FILTER_BUTTON);
            Controller.AutoClick(filter);
            Thread.Sleep(1000);
        }
        public static void ActDectFilter(FilterEnabled filter)
        {
            if (MainScreen.Filters.filterEnabled != filter)
            {
                Controller.AutoClick(MainScreen.TAB_VILLAGE);
                Controller.AutoClick(MainScreen.TAB_MAP);
                Controller.MoveTo(MainScreen.FILTER_BUTTON);
                Thread.Sleep(100);
                Controller.MoveTo(1360 / 2, 768 / 2);
                Thread.Sleep(1000);
                Controller.AutoClick(MainScreen.FILTER_BUTTON);
                Controller.AutoClick(MainScreen.Filters.filters[filter]);
                MainScreen.Filters.filterEnabled = filter;
                Thread.Sleep(1000);
            }
        }

        public static void WriteToLog(string message)
        {
            DateTime time = DateTime.Now;
            using (StreamWriter stream = new StreamWriter("tlog.txt", true, Encoding.Default))
            {
                stream.WriteLine(time.ToLongTimeString() +" : "+ message);
            }
        }
        public static void WriteToScoutLog(string message)
        {
            DateTime time = DateTime.Now;
            using (StreamWriter stream = new StreamWriter("scoutlog.txt", true, Encoding.Default))
            {
                stream.WriteLine(time.ToLongTimeString() + " : " + message);
            }
        }

        public static void DoSomething()
        {
            Random rand = new Random();
            sleep_commands[rand.Next(0, sleep_commands.Count)]();
        }

        public static class Scouting
        {
            
            public static Coords SCOUT_MINUS = new Coords(302,578);
            public static Coords SCOUT_PLUS = new Coords(405, 578);

            
            public static void SendScout(int value)
            {
                Controller.AutoClick(MainScreen.Map.SCOUT_BUTTON);
                Thread.Sleep(1000);
                Controller.MoveTo(SCOUT_MINUS);
                for (int i = 0; i < 8; i++)
                {
                    Controller.Click();
                    Thread.Sleep(100);
                }
                Controller.MoveTo(SCOUT_PLUS);
                for (int i = 1; i < value; i++)
                {
                    Controller.Click();
                    Thread.Sleep(100);
                }
                Controller.AutoClick(MainScreen.Map.SEND_SCOUT);
                Thread.Sleep(500);
                Controller.AutoClick(MainScreen.Map.X_BUTTON);
            }
            public static void CollectStacks()
            {
                ResetVillageNumber();
                ZoomOutMap(1);
                ActDectFilter(MainScreen.Filters.SCOUT_FILTER);
                ImageReader reader = new ImageReader();
                List<Pair> stacks = reader.FindImageOnScreen(MainScreen.READER_AREA, "stack.bmp", 14);
                Thread.Sleep(2000);

                if (stacks.Count != 0)
                {
                    int scouts_onstack = 8 / stacks.Count;

                    foreach (var stc in stacks)
                    {
                        Controller.MoveTo(stc.X, stc.Y);
                        Thread.Sleep(100);
                        Controller.Click();
                        Controller.Click();
                        Thread.Sleep(1000);
                        SendScout(scouts_onstack);
                        ResetVillageNumber();
                        ZoomOutMap(1);
                    }
                }
                ActDectFilter(MainScreen.Filters.ERASE_FILTER);

            }
        }
        public static class Attacking
        {
            public static void LoadFormation(Coords formation)
            {
                Controller.AutoClick(AttackScreen.SETTINGS_BUTTON);
                Thread.Sleep(1000);
                Controller.AutoClick(formation);
                Controller.AutoClick(AttackScreen.LocalSettings.LOADFORMATION_BUTTON);
                Thread.Sleep(1000);
                Controller.AutoClick(AttackScreen.LocalSettings.X_BUTTON);

            }
            public static void Attack()
            {
                ResetVillageNumber();
                ActDectFilter(MainScreen.Filters.AI_FILTER);
                ImageReader reader = new ImageReader();
                List<Pair> castles = reader.FindImageOnScreen(MainScreen.READER_AREA, "castle_2.bmp", 20);
                Thread.Sleep(2000);

                foreach(var item in castles)
                {
                    Controller.AutoClick(item);
                    Thread.Sleep(1000);

                    List<Pair> shields = reader.FindImageOnScreen(MainScreen.READER_AREA, "shield_rat.bmp", 5);
                    List<Pair> type = reader.FindImageOnScreen(MainScreen.READER_AREA, "castle_2_selected.bmp", 20);

                    if (shields.Count == 0 || type.Count == 0)
                    {
                        ResetVillageNumber();
                    }
                    else
                    {
                        Controller.AutoClick(AttackScreen.MAP_ATTACK_BUTTON);
                        Thread.Sleep(2000);
                        LoadFormation(AttackScreen.LocalSettings.FORM_3);
                        Controller.AutoClick(AttackScreen.SENDATTACK_BUTTON);
                        Thread.Sleep(500);
                        Controller.AutoClick(AttackScreen.SendingScreen.ATTACK_BUTTON);
                        Controller.AutoClick(AttackScreen.SendingScreen.SEND_BUTTON);
                        Thread.Sleep(2000);
                        break;
                    }
                }
                ActDectFilter(MainScreen.Filters.ERASE_FILTER);
            }
        }
    }
}
