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
        
        public void Execute()
        {
            Random rand = new Random();
            //scout.ActivateCard(2, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 19, 00, 00));
            //list.Add(new Instruction<Coords, int>(ExecuteMode.EveryTime, Cvrt.ToSeconds(60, 0), Commands.ArmyBuy, Army.BUY_CATAPULT_1, 4));
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

        public void AddScout(bool isChecked, int defer)
        {
           if(isChecked)
            {
                if(Scout == null)
                {
                    Scout = new AutoScout(defer);

                    Scout.AddTarget(Resource.Swords);
                    Scout.AddTarget(Resource.Stack);

                    Scout.AddTarget(Resource.Pitch);
                    Scout.AddTarget(Resource.Iron);


                    Scout.AddTarget(Resource.Catapults);
                    Scout.AddTarget(Resource.Bows);

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

                    Scout.AddTarget(Resource.Stone);
                    Scout.AddTarget(Resource.Wood);

                    commands.Add(Scout);
                }
            }
           else
            {
                if(Scout != null)
                {
                    commands.Remove(Scout);
                    Scout = null;
                }
            }

            
        }
        public void AddTrader(bool isChecked, int defer)
        {
            if(isChecked)
            {
                if(Trader == null)
                {
                    Trader = new AutoTrading(Cvrt.ToSeconds(2, 24) * 2 , defer);

                    Trader.AddSellingType(Trading.TAB_RESOURCES_4, 3);
                    Trader.AddSellingType(Trading.TAB_BANQUET_8, null);
                    Trader.AddSellingType(Trading.TAB_FOOD_7, null);
                    Trader.AddTargets(0);

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
        public void AddAttack(bool isChecked, int defer)
        {
            if(isChecked)
            {
                if(Attack == null)
                {
                    Attack = new AutoAttack(defer);

                    Attack.AddTarget(AIName.Rat, 0, 1);
                    Attack.AddTarget(AIName.Rat, 1, 1);
                    Attack.AddTarget(AIName.Rat, 2, 3);

                    commands.Add(Attack);
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
