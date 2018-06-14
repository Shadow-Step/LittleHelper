using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleHelper.src
{
    class Instruction : BaseInstruction
    {
        public delegate void Action();
        Action action;

        public Instruction(ExecuteMode execute_mode,double execute_rate,Action action)
        {
            this.action = action;
            this.execute_mode = execute_mode;
            this.execute_rate = execute_rate;
        }
        public override void Execute()
        {
            if (!IsReady())
                return;
            action();
            Completed();
        }
    }
    class Instruction<T1> : BaseInstruction
    {
        public delegate void Action(T1 p1);
        Action action;
        T1 p1;

        public Instruction(ExecuteMode execute_mode, double execute_rate, Action action,T1 p1)
        {
            this.action = action;
            this.execute_mode = execute_mode;
            this.execute_rate = execute_rate;
            this.p1 = p1;
        }
        public override void Execute()
        {
            if (!IsReady())
                return;
            action(p1);
            Completed();
        }
    }
    class Instruction<T1, T2> : BaseInstruction
    {
        public delegate void Action(T1 p1,T2 p2);
        Action action;
        T1 p1;
        T2 p2;

        public Instruction(ExecuteMode execute_mode, double execute_rate, Action action, T1 p1,T2 p2)
        {
            this.action = action;
            this.execute_mode = execute_mode;
            this.execute_rate = execute_rate;
            this.p1 = p1;
            this.p2 = p2;
        }
        public override void Execute()
        {
            if (!IsReady())
                return;
            action(p1,p2);
            Completed();
        }
    }
    class Instruction<T1, T2, T3> : BaseInstruction
    {
        public delegate void Action(T1 p1, T2 p2, T3 p3);
        Action action;
        T1 p1;
        T2 p2;
        T3 p3;

        public Instruction(ExecuteMode execute_mode, double execute_rate, Action action, T1 p1, T2 p2, T3 p3)
        {
            this.action = action;
            this.execute_mode = execute_mode;
            this.execute_rate = execute_rate;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }
        public override void Execute()
        {
            if (!IsReady())
                return;
            action(p1, p2, p3);
            Completed();
        }
    }
}
