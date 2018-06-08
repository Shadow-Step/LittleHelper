using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using LittleHelper.butcords;


namespace LittleHelper.model
{
    class Commands
    {
        public static void RepairCastle()
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_CASTLE);
            Controller.AutoClick(Castle.Options.get_coords);
            Controller.AutoClick(Castle.Options.REPAIR);
            Thread.Sleep(2000);
        }
        public static void RepairCastle(int iterations)
        {
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_CASTLE);
            while (iterations != 0)
            {
                Controller.AutoClick(Castle.Options.get_coords);
                Controller.AutoClick(Castle.Options.REPAIR);
                Thread.Sleep(2000);
                Controller.AutoClick(MainScreen.NEXTVILLAGE_BUTTON);
                Thread.Sleep(1000);
                iterations--;
            }
        }
        public static Player InitPlayer()
        {
            int gold = Reader.GetData(RFields.GOLD);
            int honor = Reader.GetData(RFields.HONOR);
            int fair = Reader.GetData(RFields.FAIR);
            int villages = Reader.GetData(RFields.VILLAGES);
            return new Player(villages, gold, honor, fair);
        }
    }
}
