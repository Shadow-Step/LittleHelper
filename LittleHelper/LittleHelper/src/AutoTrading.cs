using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleHelper.stat;
using LittleHelper.butcords;
using System.Threading;
using ImgRdr;

namespace LittleHelper.src
{
    class AutoTrading : BaseInstruction
    {
        string[,] res_dict = new string[4, 8]
        {
            {"Wood","Stone","Iron","Pitch","","","","" },
            {"Apples","Cheese","Meat","Bread","Vegetables","Fish","Ale","" },
            {"Bows","Pickes","Armor","Swords","Catapults","","","" },
            {"Venison","Furniture","Metalware","Clothes","Wine","Salt","Spice","Silk" },
        };
        Dictionary<Coords, string[]> log_dict = new Dictionary<Coords, string[]>()
        {
            {Trading.TAB_RESOURCES_4,new string[4]{ "Wood", "Stone", "Iron", "Pitch" } },
            {Trading.TAB_FOOD_7,new string[7]{ "Apples", "Cheese", "Meat", "Bread", "Vegetables", "Fish", "Ale" } },
            {Trading.TAB_WEAPON_5,new string[5]{ "Bows", "Pickes", "Armor", "Swords", "Catapults" } },
            {Trading.TAB_BANQUET_8,new string[8]{ "Venison", "Furniture", "Metalware", "Clothes", "Wine", "Salt", "Spice", "Silk" } },
        };
        ImageReader reader;
        List<Coords> selling_types = new List<Coords>();
        List<int[]> resources = new List<int[]>();
        int[] targets;
      
        public AutoTrading(double execute_rate_sec, double delayed_launch = 0)
        {
            this.last_execute = DateTime.Now;
            this.execute_rate_sec = delayed_launch;
            this.reader = new ImageReader();
        }
        public void AddSellingType(Coords type, params int[]resources)
        {
            selling_types.Add(type);
            if(resources == null)
            {
                if (type == Trading.TAB_RESOURCES_4)
                {
                    this.resources.Add(new int[4] { 0, 1, 2, 3 });
                }
                else if (type == Trading.TAB_WEAPON_5)
                {
                    this.resources.Add(new int[5] { 0, 1, 2, 3, 5 });
                }
                else if (type == Trading.TAB_FOOD_7)
                {
                    this.resources.Add(new int[7] { 0, 1, 2, 3, 4, 5, 6 });
                }
                else if (type == Trading.TAB_BANQUET_8)
                {
                    this.resources.Add(new int[8] { 0, 1, 2, 3, 4, 5, 6, 7 });
                }
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

            foreach (var x in targets)
            {
                int t_iter = 0; // Type iterator
                int r_iter = 0; // Resource iterator

                Controller.AutoClick(Trading.BUTTON_TARGETMENU);
                Controller.AutoClick(Trading.TargetMenu.targets[x]); // Select target

                Controller.AutoClick(selling_types[t_iter]); // Select type
                Random rand = new Random();
                Controller.AutoClick(Trading.RES_1); //RESET
                Controller.AutoClick(Trading.RES_2); //RESET

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
                        {
                            Commands.WriteToLog("Nothing to sell");
                            break;
                        }
                            
                    }
                    else
                    {
                        Controller.AutoClick(Trading.BUTTON_SELL);
                        Controller.AutoClick(Trading.BUTTON_TOOFAR);
                        Commands.WriteToLog("Traders sended, Resource: " + log_dict[selling_types[t_iter]][resources[t_iter][r_iter]] );
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
