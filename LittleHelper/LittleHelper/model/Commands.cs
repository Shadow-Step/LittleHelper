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
        public static void RepairCastle()
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_CASTLE);
            Controller.AutoClick(Castle.Options.get_coords);
            Controller.AutoClick(Castle.Options.REPAIR);
            Thread.Sleep(2000);
            Controller.AutoClick(Castle.Options.Settings.get_coords);
            Controller.AutoClick(Castle.Options.Settings.LOAD_ARMY);
            Controller.AutoClick(Castle.Options.ACCEPT);
            Thread.Sleep(2000);
        }
        public static void RepairCastle(int iterations, CastleOptions options)
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_CASTLE);
            while (iterations != 0)
            {
                Controller.AutoClick(Castle.Options.get_coords);
                Controller.AutoClick(Castle.Options.REPAIR);
                Thread.Sleep(2000);
                if(options != CastleOptions.OnlyRepair)
                {
                    if (options == CastleOptions.RepairAndRestoreArmy || options == CastleOptions.RepairAll)
                    {
                        Controller.AutoClick(Castle.Options.Settings.get_coords);
                        Controller.AutoClick(Castle.Options.Settings.LOAD_ARMY);
                        Controller.AutoClick(Castle.Options.Settings.OK_BUTTON);
                        Controller.AutoClick(Castle.CLEAR_PLACE);
                        Controller.AutoClick(Castle.Options.ACCEPT);
                        Thread.Sleep(2000);
                    }
                    if (options == CastleOptions.RepairAndRestoreCastle || options == CastleOptions.RepairAll)
                    {
                        Controller.AutoClick(Castle.Options.Settings.get_coords);
                        Controller.AutoClick(Castle.Options.Settings.LOAD_CASTLE);
                        Controller.AutoClick(Castle.Options.ACCEPT);
                        Thread.Sleep(2000);
                    }
                }
                Controller.AutoClick(MainScreen.NEXTVILLAGE_BUTTON);
                Thread.Sleep(1000);
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
                Thread.Sleep(100);
            }
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
    }
}
