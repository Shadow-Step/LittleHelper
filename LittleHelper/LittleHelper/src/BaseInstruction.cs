using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleHelper.model;

namespace LittleHelper.src
{
    enum ExecuteMode
    {
        Once,
        EveryTime,
        Alarm
    }
    abstract class BaseInstruction
    {
        protected ExecuteMode   execute_mode;
        protected DateTime      last_execute;
        protected DateTime      execute_alarm;
        protected bool          executed = false;
        protected double        execute_rate;
        
        public abstract void Execute();
        public void Completed()
        {
            last_execute = DateTime.Now;
            executed = true;
            if (execute_mode == ExecuteMode.Alarm)
                execute_mode = ExecuteMode.Once;
            Commands.DoSomething();
        }
        public bool IsReady()
        {
            Random rand = new Random();
            switch (execute_mode)
            {
                case ExecuteMode.Once:
                    return !executed;
                case ExecuteMode.EveryTime:
                    TimeSpan time = DateTime.Now.Subtract(last_execute);
                    return time.TotalSeconds >= execute_rate + (rand.Next((int)execute_rate, (int)execute_rate + (int)execute_rate / 10));
                case ExecuteMode.Alarm:
                    return DateTime.Now >= execute_alarm;
                default:
                    return false;
            }
        }
    }
}
