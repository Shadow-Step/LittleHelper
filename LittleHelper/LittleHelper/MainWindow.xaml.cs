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
using System.Drawing;
using LittleHelper.butcords;
using LittleHalper.stat;
using LittleHelper.src;
using ImgRdr;


namespace LittleHelper
{
    public partial class MainWindow : Window
    {
        Thread bot_thread;

        public MainWindow()
        {
            InitializeComponent();
            
            bot_thread = new Thread(Start);
            bot_thread.Start();

            //ImageTest();
        }
        public void Start()
        {
            Random rand = new Random();
            List<BaseInstruction> list = new List<BaseInstruction>();

            AutoTrading trader = new AutoTrading(Cvrt.ToSeconds(2,24) * 2);
            AutoScout scout = new AutoScout(100);
            AutoAttack attack = new AutoAttack(100);

            attack.AddTarget(AIName.Rat, 0, 1);
            attack.AddTarget(AIName.Rat, 1, 1);
            attack.AddTarget(AIName.Rat, 2, 3);

            trader.AddSellingType(Trading.TAB_RESOURCES_4, 3);
            trader.AddSellingType(Trading.TAB_BANQUET_8, null);
            trader.AddSellingType(Trading.TAB_FOOD_7, null);
            trader.AddTargets(0);

            scout.AddTarget(Resource.Swords);
            scout.AddTarget(Resource.Stack);

            scout.AddTarget(Resource.Pitch);
            scout.AddTarget(Resource.Iron);
            

            scout.AddTarget(Resource.Catapults);
            scout.AddTarget(Resource.Bows);
            
            scout.AddTarget(Resource.Armor);
            scout.AddTarget(Resource.Pickes);

            scout.AddTarget(Resource.Wine);
            scout.AddTarget(Resource.Salt);
            scout.AddTarget(Resource.Spice);
            scout.AddTarget(Resource.Silk);
            scout.AddTarget(Resource.Venison);
            scout.AddTarget(Resource.Furniture);
            scout.AddTarget(Resource.Clothes);
            scout.AddTarget(Resource.MetalWare);

            scout.AddTarget(Resource.Fish);
            scout.AddTarget(Resource.Vegetables);
            scout.AddTarget(Resource.Ale);
            scout.AddTarget(Resource.Bread);
            scout.AddTarget(Resource.Meat);
            scout.AddTarget(Resource.Cheese);
            scout.AddTarget(Resource.Apples);

            scout.AddTarget(Resource.Stone);
            scout.AddTarget(Resource.Wood);

            //scout.ActivateCard(2, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 00, 00));

            list.Add(scout);
            //list.Add(attack);
            //list.Add(trader);
            //list.Add(new Instruction<Coords, int>(ExecuteMode.EveryTime, Cvrt.ToSeconds(60, 0), Commands.ArmyBuy, Army.BUY_CATAPULT_1, 4));

            while (true)
            {
                Thread.Sleep(rand.Next(2000, 5000));
                foreach (var item in list)
                {
                    item.Execute();
                }
                Commands.DoSomething();
            }
        }
        public void CountDistance(int x, int y,double seconds)
        {
            int v_x = 580;
            int v_y = 420;
            double distance = Math.Sqrt(Math.Pow((int)x - (int)v_x, 2) + Math.Pow((int)y - (int)v_y, 2));
            double speed = distance / seconds;
        }
        public void ImageTest()
        {
            Thread.Sleep(2000);
            ImageReader reader = new ImageReader();
            //var x = reader.CheckColorSaturation(Research.READER_AREA, ColorEnum.Green, 200);
            var x = reader.FindImageOnScreen(MainScreen.READER_AREA, new WrapImg("research_bar.bmp", 0));
        }
    }
    
}
