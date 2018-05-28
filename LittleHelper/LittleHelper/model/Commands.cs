using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace LittleHelper.model
{
    class Commands
    {
        public static void RepairCastle()
        {
            
        }
        public static void SwitchVillage()
        {
            Controller.Reset();
            Controller.MoveTo(Buttons.NEXTVILLAGE_BUTTON);
            Controller.Click();
        }
        public static void OpenVillage()
        {
            Controller.AutoClick(Buttons.VILLAGE_BUTTON);
        }
    }
}
