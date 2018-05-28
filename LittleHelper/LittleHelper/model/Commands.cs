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
        
    }
}
