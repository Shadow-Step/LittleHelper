using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LittleHelper.model
{
    class Controller
    {
        
        //Mouse event constants
        private static UInt32 MOUSE_MOVE = 0x0001;
        private static UInt32 MOUSE_BUTTONDOWN = 0x0002;
        private static UInt32 MOUSE_BUTTONUP = 0x0004;
        
        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, int dx, int dy, UInt32 dwData, IntPtr dwExtraInfo);

        public static int ToMilliseconds(int hours = 0, int minutes = 0, int seconds = 0)
        {
            minutes += hours * 60;
            seconds += minutes * 60;
            return seconds * 1000;
        }
        //Controller commands
        static public void Reset()
        {
            mouse_event(MOUSE_MOVE, -2000, -2000, 0, IntPtr.Zero);
        }
        static public void MoveTo(Coords coords)
        {
            Reset();
            mouse_event(MOUSE_MOVE, coords.X, coords.Y, 0, IntPtr.Zero);
        }
        static public void MoveTo(int x, int y)
        {
                mouse_event(MOUSE_MOVE, x, y, 0, IntPtr.Zero);
        }
        static public void Click()
        {
            mouse_event(MOUSE_BUTTONDOWN, 0, 0, 0, IntPtr.Zero);
            mouse_event(MOUSE_BUTTONUP, 0, 0, 0, IntPtr.Zero);
        }
        static public void Click(Coords coords)
        {
            mouse_event(MOUSE_BUTTONDOWN, coords.X, coords.Y, 0, IntPtr.Zero);
            mouse_event(MOUSE_BUTTONUP, coords.X, coords.Y, 0, IntPtr.Zero);
        }
        static public void AutoClick(Coords coords)
        {
            Random rand = new Random();
            MoveTo(coords);
            Thread.Sleep(rand.Next(200,500));
            Click();
            Thread.Sleep(rand.Next(1000,2000));
        }
    }
}
