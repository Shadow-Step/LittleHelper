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
using System.Windows.Interop;
using LittleHelper.butcords;
using LittleHelper.stat;
using LittleHelper.src;
using ImgRdr;
using System.Drawing;
using System.IO;

namespace LittleHelper
{
    public partial class MainWindow : Window
    {
        const int F5 = 0x74;
        const int F8 = 0x77;
        const int HotF5 = 0;
        const int HotF8 = 1;

        Thread bot_thread;
        IntPtr Hwnd = IntPtr.Zero;
        HwndSource source;
        Bot bot;
        

        public MainWindow()
        {
            InitializeComponent();
            //ImageTest();
        }
        public void Start()
        {
            
            Random rand = new Random();
            List<BaseInstruction> list = new List<BaseInstruction>();

            AutoTrading trader = new AutoTrading(Cvrt.ToSeconds(2,24) * 2);
            AutoScout scout = new AutoScout(0,100);
            AutoAttack attack = new AutoAttack(0,100);

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
                foreach (var item in list)
                {
                    item.Execute();
                }
                Commands.DoSomething();
                Thread.Sleep(rand.Next(2000, 5000));
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
            var time = DateTime.Now;
            List<int> asd = new List<int>();
            foreach (var item in AutoScout.resdict)
            {
                var x = reader.FindImageOnScreen(MainScreen.READER_AREA, item.Value,true);
                asd.Add(x.Count);

            }

            var nstop = DateTime.Now.Subtract(time).TotalSeconds;

            var screeshot_time = ImageReader.screen_time;
            var color_list = ImageReader.color_time;
            var find_time = ImageReader.find_time;

        }
        void Test()
        {
           
        }
        private void InitBot(bool reset)
        {
            if(reset || bot == null)
            bot = new Bot(int.Parse(TextBoxVillages.Text));

            bot.AddScout((bool)AScout.IsChecked,0);
            bot.AddTrader((bool)ATrade.IsChecked,0);
            bot.AddAttack((bool)AAttack.IsChecked,0);
        }
        private void InitBot(bool reset, int defer)
        {
            if (reset || bot == null)
                bot = new Bot(int.Parse(TextBoxVillages.Text));

            bot.AddScout((bool)AScout.IsChecked,defer);
            bot.AddTrader((bool)ATrade.IsChecked,defer);
            bot.AddAttack((bool)AAttack.IsChecked,defer);
        }
        private IntPtr MsgListener(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_HOTKEY = 0x0312;
            switch (msg)
            {
                case WM_HOTKEY:
                    var key = wParam.ToInt32();
                    switch (key)
                    {
                        case HotF5:
                            StartEndThread();
                            break;
                        case HotF8:
                            PauseThread();
                            break;
                    }
                    break;
                default:
                    break;
            }

            return IntPtr.Zero;
        }
        private void StartEndThread()
        {
            if (bot_thread != null && bot_thread.IsAlive)
            {
                bot_thread.Abort();
                bot_thread = null;
                bot = null;
            }
            else
            {
                if (bot == null)
                {
                    InitBot(true,int.Parse(TextBox.Text));
                }
                bot_thread = new Thread(bot.Execute);
                bot_thread.Start();
                
            }

        }
        private void PauseThread()
        {
           if(bot != null)
            {
                if (bot_thread != null && bot_thread.IsAlive)
                {
                    bot_thread.Abort();
                    bot_thread = null;
                }
                else
                {
                    InitBot(false);
                    bot_thread = new Thread(bot.Execute);
                    bot_thread.Start();
                }
                    
            }
           else
            {
                InitBot(true);
                bot_thread = new Thread(bot.Execute);
                bot_thread.Start();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            source.RemoveHook(MsgListener);
            source = null;
            Controller.UnregisterHotKey(Hwnd, HotF5);
            Controller.UnregisterHotKey(Hwnd, HotF8);

            base.OnClosed(e);
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Hwnd = new WindowInteropHelper(this).Handle;
            source = HwndSource.FromHwnd(Hwnd);
            source.AddHook(MsgListener);

            Controller.RegisterHotKey(Hwnd, HotF5, 0, F5);
            Controller.RegisterHotKey(Hwnd, HotF8, 0, F8);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Test();
        }
    }
    
}
