using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImgRdr;
using LittleHelper.model;
using LittleHelper.butcords;
using System.Threading;

namespace LittleHelper.src
{
    class AutoAttack : BaseInstruction
    {
        private Coords village_pos = new Coords(577,415);
        private const double CAP_SPEED = 0.70;
        ImageReader reader;
        Dictionary<string, int> targets;
        Dictionary<string, int> biases;

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
            targets = new Dictionary<string, int>();
            biases = new Dictionary<string, int>();
        }
        public void AddTarget(string castle_examplename,int bias,int formation)
        {
            targets.Add(castle_examplename, formation);
            biases.Add(castle_examplename, bias);
        }

        public override void Execute()
        {
            if (!IsReady())
                return;
            Commands.ResetVillageNumber();
            Commands.ActDectFilter(MainScreen.Filters.AI_FILTER);
            foreach (var tar in targets)
            {
                List<Pair> castles = reader.FindImageOnScreen(MainScreen.READER_AREA, tar.Key, biases[tar.Key]);
                if(castles.Count != 0)
                {
                    Commands.ResetVillageNumber();
                    Thread.Sleep(1000);
                    foreach (var item in castles)
                    {
                        Controller.AutoClick(item);
                        Thread.Sleep(1000);

                        List<Pair> shields = reader.FindImageOnScreen(MainScreen.SELECTED_CASTLE_AREA, "shield_rat.bmp", 5);
                        Controller.AutoClick(MainScreen.TAB_VILLAGE);
                        Controller.AutoClick(MainScreen.TAB_MAP);
                        foreach (var check in targets)
                        {
                            List<Pair> type = reader.FindImageOnScreen(MainScreen.SELECTED_CASTLE_AREA, check.Key, biases[check.Key]);
                            //if (shields.Count == 0 || type.Count == 0)
                            //{
                            //    Commands.ResetVillageNumber();
                            //    continue;
                            //}
                            if(shields.Count != 0 && type.Count != 0)
                            {

                                Controller.AutoClick(village_pos);
                                Controller.AutoClick(AttackScreen.MAP_ATTACK_BUTTON);
                                Thread.Sleep(2000);
                                Commands.Attacking.LoadFormation(AttackScreen.LocalSettings.formations[check.Value]);
                                Controller.AutoClick(AttackScreen.SENDATTACK_BUTTON);
                                Thread.Sleep(500);
                                Controller.AutoClick(AttackScreen.SendingScreen.ATTACK_BUTTON);
                                Controller.AutoClick(AttackScreen.SendingScreen.SEND_BUTTON);
                                CountNextExecute(new Coords(item.X, item.Y));
                                Thread.Sleep(2000);
                                Completed();
                                return;
                            }
                        }
                        
                    }
                }
            }
           

            
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
}
