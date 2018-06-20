using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleHelper.model;
using LittleHelper.butcords;
using System.Threading;
using ImgRdr;

namespace LittleHelper.src
{
    class AutoScout : BaseInstruction
    {
        private const double SCOUT_SPEED = 1.91;
        private Coords village_pos = new Coords(577, 415);
        private Dictionary<string, int> targets = new Dictionary<string, int>();
        private List<double> return_time = new List<double>();

        ImageReader reader;

        public AutoScout(double execute_rate_sec, double start_after_sec = 0)
        {
            if (start_after_sec != 0)
            {
                last_execute = DateTime.Now;
                this.execute_rate_sec = start_after_sec;
            }
            else
            {
                this.execute_rate_sec = execute_rate_sec;
            }
            this.reader = new ImageReader();
        }
        public void AddTarget(string target, int bias)
        {
            targets.Add(target, bias);
        }

        public override void Execute()
        {
            if (!IsReady())
                return;
            
            Commands.ResetVillageNumber();
            Commands.ZoomOutMap(1);
            Commands.ActDectFilter(MainScreen.Filters.SCOUT_FILTER);

            foreach (var item in targets)
            {
                List<Pair> target = reader.FindImageOnScreen(MainScreen.READER_AREA, item.Key, item.Value);
                if(target.Count != 0)
                {
                    Thread.Sleep(2000);
                    int scouts_onstack = 8 / target.Count;
                    foreach (var stc in target)
                    {
                        Controller.AutoClick(stc);
                        Controller.AutoClick(MainScreen.MIDDLE_OFSCREEN);
                        Thread.Sleep(1000);
                        Commands.Scouting.SendScout(scouts_onstack);

                        last_execute = DateTime.Now;
                        return_time.Add(CountNextExecute(new Coords(stc.X, stc.Y)));

                        if (target.Count > 1)
                        {
                            Commands.ResetVillageNumber();
                            Commands.ZoomOutMap(1);
                        }
                    }
                    Completed();
                    return;
                }

            }
            
        }
        public override bool IsReady()
        {
            return last_execute == null ? true : DateTime.Now.Subtract(last_execute).TotalSeconds >= execute_rate_sec;
        }
        public override void Completed()
        {
            double max = 0;
            foreach (var item in return_time)
            {
                max = item > max ? item : max;
            }
            execute_rate_sec = max;
            return_time.Clear();

            Commands.DoSomething();
        }
        private double CountNextExecute(Coords target)
        {
            double distance = Math.Sqrt(Math.Pow((int)target.X - (int)village_pos.X, 2) + Math.Pow((int)target.Y - (int)village_pos.Y, 2));
            return (distance / SCOUT_SPEED) * 2;
        }
    }
}
