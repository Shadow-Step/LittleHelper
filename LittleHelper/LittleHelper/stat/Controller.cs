using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ImgRdr;

namespace LittleHalper.stat
{
    class Controller
    {
        private const UInt32 ABSOLUTE = 65535;
        private const int SCREEN_WIDTH = 1360;
        private const int SCREEN_HEIGHT = 768;
        //Mouse event constants
        private static UInt32 ABSOLUTE_FLAG = 0x8000;
        private static UInt32 MOUSE_MOVE = 0x0001;
        private static UInt32 MOUSE_BUTTONDOWN = 0x0002;
        private static UInt32 MOUSE_BUTTONUP = 0x0004;
        private static UInt32 WHEEL_ROTATE = 0x0800;
        
        [DllImport("user32.dll")]
        public static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, int dwData, IntPtr dwExtraInfo);

        public static int ToMilliseconds(int hours = 0, int minutes = 0, int seconds = 0)
        {
            minutes += hours * 60;
            seconds += minutes * 60;
            return seconds * 1000;
        }
        //Controller commands
        
        static public void MoveTo(Coords coords)
        {
            mouse_event(ABSOLUTE_FLAG | MOUSE_MOVE, coords.X * (ABSOLUTE / SCREEN_WIDTH), coords.Y * (ABSOLUTE / SCREEN_HEIGHT), 0, IntPtr.Zero);
        }
        static public void MoveTo(UInt32 x, UInt32 y)
        {
                mouse_event(ABSOLUTE_FLAG | MOUSE_MOVE, x * (ABSOLUTE / SCREEN_WIDTH), y * (ABSOLUTE / SCREEN_HEIGHT), 0, IntPtr.Zero);
        }
        static public void Click()
        {
            mouse_event(MOUSE_BUTTONDOWN, 0, 0, 0, IntPtr.Zero);
            Thread.Sleep(50);
            mouse_event(MOUSE_BUTTONUP, 0, 0, 0, IntPtr.Zero);
            Thread.Sleep(50);
        }
        static public void AutoClick(Coords coords)
        {
            Random rand = new Random();
            MoveTo(coords);
            Thread.Sleep(rand.Next(200,500));
            Click();
            Thread.Sleep(rand.Next(1000,2000));
        }
        static public void AutoClick(Pair coords)
        {
            Random rand = new Random();
            MoveTo(coords.X,coords.Y);
            Thread.Sleep(rand.Next(200, 500));
            Click();
            Thread.Sleep(rand.Next(1000, 2000));
        }
        static public void WheelRotate(int direction,int times)
        {
            for (int i = 0; i < times; i++)
            {
                mouse_event(WHEEL_ROTATE, 0, 0, 120 * direction, IntPtr.Zero);
                Thread.Sleep(200);
            }
            Thread.Sleep(500);
        }
        
    }
}
