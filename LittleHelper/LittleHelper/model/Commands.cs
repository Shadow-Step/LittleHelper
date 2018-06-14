using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LittleHelper.butcords;


namespace LittleHelper.model
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
        delegate void Operation();

        private static Dictionary<int, Operation> sleep_commands = new Dictionary<int, Operation>()
        {
            {0,()=>
            {
                Controller.AutoClick(MainScreen.TAB_REPORTS);
                Thread.Sleep(rand.Next(1500,3000));
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
        };

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
            Thread.Sleep(500);
            for (int i = 0; i < value; i++)
            {
                Controller.AutoClick(Village.Info.TAX_PLUS);
                Thread.Sleep(200);
            }
        }
        public static void DecreaseTaxes(int value)
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_VILLAGE);
            Controller.AutoClick(Village.Info.get_coords);
            Thread.Sleep(500);
            for (int i = 0; i < value; i++)
            {
                Controller.AutoClick(Village.Info.TAX_MINUS);
                Thread.Sleep(200);
            }
        }
        public static void SendScout()
        {
            Controller.AutoClick(MainScreen.Map.SCOUT_BUTTON);
            Thread.Sleep(1000);
            Controller.AutoClick(MainScreen.Map.SEND_SCOUT);
        }
        public static void ArmyBuy(Coords unit,int value)
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_ARMY);
            Thread.Sleep(1000);
            for (int i = 0; i < value; i++)
            {
                Controller.AutoClick(unit);
                Thread.Sleep(50);
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
        public static void ResearchSkill(Coords tab, Coords skill)
        {
            Controller.AutoClick(MainScreen.TAB_RESEARCH);
            Controller.AutoClick(tab);
            Controller.AutoClick(skill);
        }
        public static void SendTraders(Coords tab, Coords res, int[] targets)
        {
            ResetVillageNumber();
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_TRADE);
            Controller.AutoClick(tab);
            foreach (var x in targets)
            {
                Controller.AutoClick(Trading.RES_1);
                Controller.AutoClick(Trading.RES_2);
                Controller.AutoClick(res);
                Controller.AutoClick(Trading.BUTTON_TARGETMENU);
                Controller.AutoClick(Trading.TargetMenu.targets[x]);
                Controller.AutoClick(Trading.BUTTON_SELL);
                Thread.Sleep(1000);
                Controller.AutoClick(MainScreen.NEXTVILLAGE_BUTTON);
                Thread.Sleep(2000);
            }
           
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
        public static Player InitPlayer()
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Thread.Sleep(500);
            Controller.AutoClick(MainScreen.TAB_MAP);
            Thread.Sleep(1000);
            int gold = Reader.GetData(ImagesPos.GOLD);
            int honor = Reader.GetData(ImagesPos.HONOR);
            int fair = Reader.GetData(ImagesPos.FAIR);
            int villages = Reader.GetData(ImagesPos.VILLAGES);
            return new Player(villages, gold, honor, fair);
        }
        public static void DoSomething()
        {
            Random rand = new Random();
            sleep_commands[rand.Next(0, sleep_commands.Count)]();
        }
        
    }
}
