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
    class AutoTrading : BaseInstruction
    {
        ImageReader reader;
        List<Coords> selling_types;
        List<int[]> resources;
        int[] targets;
        int iterator_type = 0;
        int iterator_res = 0;

        public AutoTrading(double execute_rate_sec, double start_after_sec = 0)
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
            reader = new ImageReader();
            this.selling_types = new List<Coords>();
            this.resources = new List<int[]>();
        }
        public void AddSellingType(Coords type, params int[]resources)
        {
            selling_types.Add(type);
            if(resources == null)
            {
                if (type == Trading.TAB_RESOURCES_4)
                    this.resources.Add(new int[4] {0, 1, 2, 3 });
                else if (type == Trading.TAB_WEAPON_5)
                    this.resources.Add(new int[5] { 0, 1, 2, 3, 5 });
                else if (type == Trading.TAB_FOOD_7)
                    this.resources.Add(new int[7] { 0, 1, 2, 3, 4, 5, 6 });
                else if (type == Trading.TAB_BANQUET_8)
                    this.resources.Add(new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 });
            }
            else
            this.resources.Add(resources);
        }
        public void AddTargets(params int[] targets)
        {
            this.targets = targets;
        }

        public override void Execute()
        {
            if (!IsReady())
                return;

            Commands.ResetVillageNumber();
            Controller.AutoClick(MainScreen.TAB_VILLAGE);
            Controller.AutoClick(Village.TAB_TRADE);

            int t_iter = 0;
            int r_iter = 0;

            foreach (var x in targets)
            {
                Controller.AutoClick(selling_types[t_iter]);
                Random rand = new Random();
                Controller.AutoClick(Trading.RES_1);
                Controller.AutoClick(Trading.RES_2);

                while (true)
                {
                    Controller.AutoClick(Trading.resource_list[resources[t_iter][r_iter]]);
                    var canbesold = reader.FindImageOnScreen(Trading.AREA_SELLBUTON, "sell_button.bmp", 24);
                    if(canbesold.Count == 0)
                    {
                        r_iter = (r_iter + 1) % resources[t_iter].Length;
                        if (r_iter == 0)
                        {
                            t_iter = (t_iter + 1) % resources.Count;
                            Controller.AutoClick(selling_types[t_iter]);
                        }
                        if (r_iter == 0 && t_iter == 0)
                            break;
                    }
                    else
                    {
                        Controller.AutoClick(Trading.BUTTON_TARGETMENU);
                        Controller.AutoClick(Trading.TargetMenu.targets[x]);
                        Controller.AutoClick(Trading.BUTTON_SELL);
                        Thread.Sleep(rand.Next(800, 1200));
                        break;
                    }
                }
                if (targets.Length > 1)
                {
                    Controller.AutoClick(MainScreen.NEXTVILLAGE_BUTTON);
                    Thread.Sleep(rand.Next(1800, 2300));
                }
            }
            iterator_res = (iterator_res + 1) % resources[iterator_type].Length;
            if (iterator_res == 0)
                iterator_type = (iterator_type + 1) % resources.Count;
            Completed();
        }
        public override bool IsReady()
        {
            return last_execute == null ? true : DateTime.Now.Subtract(last_execute).TotalSeconds >= execute_rate_sec;
        }
        public override void Completed()
        {
            last_execute = DateTime.Now;
            Commands.DoSomething();
        }
    }
}
