using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImgRdr;
using LittleHelper.stat;
using LittleHelper.butcords;
using System.Threading;

namespace LittleHelper.src
{
    enum AIName
    {
        Rat,
        Snake,
        Pig,
        Wolf
    }

    class AutoAttack : BaseInstruction
    {
        private Coords village_pos = new Coords(577,415);
        private const double CAP_SPEED = 0.70;

        ImageReader reader;

        List<AttackTarget> targets = new List<AttackTarget>();
        Dictionary<AIName, WrapImg> shields_dict = new Dictionary<AIName, WrapImg>()
        {
            {AIName.Rat,new WrapImg("shd\\shield_rat.bmp",5)},
            {AIName.Snake,new WrapImg("shd\\shield_snake.bmp",9)},
            {AIName.Pig,new WrapImg("shd\\shield_pig.bmp",13)},
            {AIName.Wolf,new WrapImg("shd\\shield_wolf.bmp",7)}
        };

        /// <summary>Default castles examples</summary>
        List<WrapImg> castles = new List<WrapImg>() {
            new WrapImg("cst\\castle_0.bmp", 15),
            new WrapImg("cst\\castle_1.bmp", 16),
            new WrapImg("cst\\castle_2.bmp", 20),
            new WrapImg("cst\\castle_3.bmp", 13),
        };

        public AutoAttack(double execute_rate_sec,double start_after_sec = 0)
        {
            if(start_after_sec != 0)
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
        public void AddTarget(AIName name, int castle_level,int formation, int army_cost = 100)
        {
            targets.Add(new AttackTarget(name, castle_level,formation,army_cost));
        }

        public override void Execute()
        {
            if (!IsReady())
                return;
            Commands.ResetVillageNumber();
            Commands.ActDectFilter(MainScreen.Filters.AI_FILTER);
            foreach (var castle in castles) // Check default types
            {
                List<Pair> exist_castles = reader.FindImageOnScreen(MainScreen.READER_AREA, castle);

                if(exist_castles.Count != 0)
                {
                    Thread.Sleep(1000);
                    foreach (var targ in exist_castles) // Check finded castles
                    {
                        Controller.AutoClick(targ);
                        Thread.Sleep(1000);

                        List<Pair> shields = new List<Pair>();

                        foreach (var shield in targets)
                        {
                            shields = reader.FindImageOnScreen(MainScreen.SELECTED_CASTLE_AREA,shields_dict[shield.Name]);
                            if (shields.Count != 0)
                                break;
                        }
                       
                        Controller.AutoClick(MainScreen.TAB_VILLAGE);
                        Controller.AutoClick(MainScreen.TAB_MAP);
                        Thread.Sleep(2000);
                        foreach (var check in targets) // Check selected castle
                        {
                            List<Pair> type = reader.FindImageOnScreen(MainScreen.SELECTED_CASTLE_AREA, castles[check.Level]);
                            if(shields.Count != 0 && type.Count != 0)
                            {
                                Controller.AutoClick(village_pos);
                                Controller.AutoClick(AttackScreen.MAP_ATTACK_BUTTON);
                                Thread.Sleep(2000);
                                Commands.Attacking.LoadFormation(AttackScreen.LocalSettings.formations[check.Formation]);
                                Controller.AutoClick(AttackScreen.SENDATTACK_BUTTON);
                                Thread.Sleep(500);
                                Controller.AutoClick(AttackScreen.SendingScreen.ATTACK_BUTTON);
                                Controller.AutoClick(AttackScreen.SendingScreen.SEND_BUTTON);
                                CountNextExecute(new Coords(targ.X, targ.Y));
                                Commands.WriteToLog("Army sended, level: " + check.Level.ToString());
                                Thread.Sleep(2000);
                                Completed();
                                return;
                            }
                        }
                        
                    }
                    Commands.WriteToLog("No castles to attack");
                    Commands.ResetVillageNumber();
                }
            }
            //execute_rate_sec = Cvrt.ToSeconds(30, 0);
            Commands.ActDectFilter(MainScreen.Filters.ERASE_FILTER);
        }
        public override void Completed()
        {
            this.last_execute = DateTime.Now;
        }
        public override bool IsReady()
        {
            return last_execute == null ? true : DateTime.Now.Subtract(last_execute).TotalSeconds >= execute_rate_sec; 
        }
        
        private void CountNextExecute(Coords target)
        {
            double distance = Math.Sqrt(Math.Pow((int)target.X - (int)village_pos.X, 2) + Math.Pow((int)target.Y - (int)village_pos.Y, 2));
            execute_rate_sec = (distance / CAP_SPEED) * 2;
        }
    }

    class AttackTarget
    {
        public int Level;
        public int Formation;
        public int Cost;
        public AIName Name;

        public AttackTarget(AIName name, int castle_level, int formation, int cost = 100)
        {
            Name = name;
            Level = castle_level;
            Formation = formation;
            Cost = cost;
        }
    }
}
