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
using LittleHelper.model;
using LittleHelper.src;
using ImgRdr;


namespace LittleHelper
{
    public partial class MainWindow : Window
    {
        Thread bot_thread;
        Dictionary<string, int> res;

        public MainWindow()
        {
            InitializeComponent();
            bot_thread = new Thread(Start);
            bot_thread.Start();
        }
        public void Start()
        {
            Random rand = new Random();
            List<BaseInstruction> list = new List<BaseInstruction>();

            AutoTrading trader = new AutoTrading(Cvrt.ToSeconds(2,24) * 2);
            AutoScout scout = new AutoScout(100);
            AutoAttack attack = new AutoAttack(100);

            attack.AddTarget("castle_0.bmp", 15, 1);
            attack.AddTarget("castle_1.bmp", 16, 1);
            attack.AddTarget("castle_2.bmp", 20, 3);

            trader.AddSellingType(Trading.TAB_RESOURCES_4, 2, 3);
            trader.AddSellingType(Trading.TAB_BANQUET_8, null);
            trader.AddSellingType(Trading.TAB_FOOD_7, null);
            trader.AddTargets(0);

            scout.AddTarget("res\\res_stack_14.bmp", 14);
            scout.AddTarget("res\\res_stone_15.bmp", 15);
            scout.AddTarget("res\\res_wood_15.bmp", 15);
            scout.AddTarget("res\\res_pitch_14.bmp", 14);
            scout.AddTarget("res\\res_iron_15.bmp", 15);

            scout.AddTarget("res\\res_spice_8.bmp", 8);
            scout.AddTarget("res\\res_vine_14.bmp", 14);
            scout.AddTarget("res\\res_salt_6.bmp", 6);
            scout.AddTarget("res\\res_silk_11.bmp", 11);

            scout.AddTarget("res\\res_catapults_7.bmp", 7);
            scout.AddTarget("res\\res_bow_22.bmp", 22);
            scout.AddTarget("res\\res_sword_14.bmp", 14);
            scout.AddTarget("res\\res_armor_3.bmp", 3);
            scout.AddTarget("res\\res_pickes_8.bmp", 8);

            scout.AddTarget("res\\res_fish_17.bmp", 17);
            scout.AddTarget("res\\res_vegetables_11.bmp", 11);
            scout.AddTarget("res\\res_bread_11.bmp", 11);
            scout.AddTarget("res\\res_cheese_6.bmp", 6);
            scout.AddTarget("res\\res_meat_8.bmp", 8);
            scout.AddTarget("res\\res_apples_6.bmp", 6);
            scout.AddTarget("res\\res_ale_14.bmp", 14);

            scout.AddTarget("res\\res_metalwear_18.bmp", 18);
            scout.AddTarget("res\\res_cloth_6.bmp", 6);
            scout.AddTarget("res\\res_furniture_13.bmp", 13);
            scout.AddTarget("res\\res_venison_11.bmp", 11);

            //list.Add(attack);
            //list.Add(trader);
            list.Add(scout);
            

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
        public void InitDict()
        {
            ImageReader reader = new ImageReader();
            var catapults = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_catapults_7.bmp", 7);
            var pikes = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_pickes_8.bmp", 8);
            var wood = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_wood_15.bmp", 15);
            var pitch = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_pitch_14.bmp", 14);
            var stack = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_stack_14.bmp", 14);
            var venison = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_venison_11.bmp", 11);
            var vine = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_vine_14.bmp", 14);
            var meat = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_meat_8.bmp", 8);
            var metalwear = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_metalwear_18.bmp", 18);
            var ale = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_ale_14.bmp", 14);
            var furniture = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_furniture_13.bmp", 13);
            var bow = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_bow_22.bmp", 22);
            var salt = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_salt_6.bmp", 6);
            var iron = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_iron_15.bmp", 15);
            var spice = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_spice_8.bmp", 8);
            var cloth = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_cloth_6.bmp", 6);
            var armor = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_armor_3.bmp", 3);
            var fish = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_fish_17.bmp", 17);
            var apples = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_apples_6.bmp", 6);
            var sword = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_sword_14.bmp", 14);
            var silk = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_silk_11.bmp", 11);
            var bread = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_bread_11.bmp", 11);
            var vegetables = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_vegetables_11.bmp", 11);
            var cheese = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_cheese_6.bmp", 6);
            var stone = reader.FindImageOnScreen(MainScreen.READER_AREA, "res\\res_stone_15.bmp", 15);

        }
    }
    
}
