using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LittleHelper.stat;
using LittleHelper.butcords;
using System.Threading;

namespace LittleHelper.src
{
    class Bot
    {
        List<BaseInstruction> commands = new List<BaseInstruction>();
        AutoScout   Scout   = null;
        AutoTrading Trader  = null;
        AutoAttack  Attack  = null;

        List<AutoScout> Test = new List<AutoScout>();

        private int Villages { get; set; }
        private int Delay { get; set; }

        public Bot(int villages, int delayed_launch)
        {
            Villages = villages;
            Delay = delayed_launch;
        }
        public void Execute()
        {
            Random rand = new Random();
            //scout.ActivateCard(2, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 00, 00));
            //list.Add(new Instruction<Coords, int>(ExecuteMode.EveryTime, Cvrt.ToSeconds(60, 0), Commands.ArmyBuy, Army.BUY_CATAPULT_1, 4));
            Thread.Sleep(Delay * 1000);
            while (true)
            {
                foreach (var com in commands)
                {
                    com.Execute();
                }
                Commands.DoSomething();
                Thread.Sleep(rand.Next(2000, 5000));
            }
        }
        public void AddScout(bool isChecked, int delayed_launch)
        {
           if(isChecked)
            {
                if(Scout == null)
                {
                    for (int i = 0; i < Villages; i++)
                    {
                        Scout = new AutoScout(i, delayed_launch);

                        
                        Scout.AddTarget(Resource.Stack);

                        Scout.AddTarget(Resource.Pitch);
                        Scout.AddTarget(Resource.Iron);
                        Scout.AddTarget(Resource.Stone);
                        Scout.AddTarget(Resource.Wood);

                        Scout.AddTarget(Resource.Catapults);
                        Scout.AddTarget(Resource.Bows);
                        //Scout.AddTarget(Resource.Swords);
                        Scout.AddTarget(Resource.Armor);
                        Scout.AddTarget(Resource.Pickes);

                        Scout.AddTarget(Resource.Wine);
                        Scout.AddTarget(Resource.Salt);
                        Scout.AddTarget(Resource.Spice);
                        Scout.AddTarget(Resource.Silk);
                        Scout.AddTarget(Resource.Venison);
                        Scout.AddTarget(Resource.Furniture);
                        Scout.AddTarget(Resource.Clothes);
                        Scout.AddTarget(Resource.MetalWare);

                        Scout.AddTarget(Resource.Fish);
                        Scout.AddTarget(Resource.Vegetables);
                        Scout.AddTarget(Resource.Ale);
                        Scout.AddTarget(Resource.Bread);
                        Scout.AddTarget(Resource.Meat);
                        Scout.AddTarget(Resource.Cheese);
                        Scout.AddTarget(Resource.Apples);

                        

                        commands.Add(Scout);
                    }
                    
                }
            }
           else
            {
               
                if(Scout != null)
                {
                    foreach (var item in Test)
                    {
                        commands.Remove(item);
                    }
                    commands.Remove(Scout);
                    Scout = null;
                }
            }

            
        }
        public void AddTrader(bool isChecked, int delayed_launch)
        {
            if(isChecked)
            {
                if(Trader == null)
                {
                    Trader = new AutoTrading(Cvrt.ToSeconds(2, 24) * 2 , delayed_launch);

                    Trader.AddSellingType(Trading.TAB_RESOURCES_4, 2);
                    Trader.AddSellingType(Trading.TAB_BANQUET_8, null);
                    Trader.AddSellingType(Trading.TAB_FOOD_7, null);
                    Trader.AddTargets(7,4,6,3,5,1,2,0,9);

                    commands.Add(Trader);
                }
            }
            else
            {
                if(Trader != null)
                {
                    commands.Remove(Trader);
                    Trader = null;
                }
            }
        }
        public void AddAttack(bool isChecked, int delayed_launch)
        {
            if(isChecked)
            {
                if(Attack == null)
                {
                    for (int i = 0; i < Villages; i++)
                    {
                        Attack = new AutoAttack(i, delayed_launch);

                        Attack.AddTarget(AIName.Rat, 0, 1);
                        Attack.AddTarget(AIName.Rat, 1, 1);
                        //Attack.AddTarget(AIName.Rat, 2, 3);

                        commands.Add(Attack);
                    }
                   
                }
            }
            else
            {
                if(Attack != null)
                {
                    commands.Remove(Attack);
                    Attack = null;
                }
            }
           
        }
    }
}
