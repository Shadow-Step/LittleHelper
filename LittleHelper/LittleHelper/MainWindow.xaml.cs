using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

using LittleHelper.butcords;
using LittleHelper.model;
using LittleHelper.src;


namespace LittleHelper
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Random rand = new Random();
            List<BaseInstruction> list = new List<BaseInstruction>();
            list.Add(new Instruction<Coords, int[], int[]>  (
                ExecuteMode.EveryTime, 
                750.0, 
                Commands.SendTraders,
                Trading.TAB_FOOD_7, 
                new int[] {0,5}, 
                new int[] {3,2,1 } ));

            //list.Add(new Instruction<Coords[], int[], int>(
            //    ExecuteMode.EveryTime, 
            //    650.0, 
            //    Commands.ArmyBuy, 
            //    new Coords[] {Army.BUY_ARCHER_1,Army.BUY_PICKEMAN_1 }, 
            //    new int[] {2,1 },
            //    3 ));


            while (true)
            {
                Thread.Sleep(rand.Next(2000,5000));
                Commands.DoSomething();
                foreach (var item in list)
                {
                    item.Execute();
                }

            }
           
        }
    }
}
