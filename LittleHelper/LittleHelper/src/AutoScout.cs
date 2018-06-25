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
    public enum Resource
    {
        Stack,

        Wood,
        Stone,
        Iron,
        Pitch,

        Apples,
        Cheese,
        Meat,
        Bread,
        Vegetables,
        Fish,
        Ale,

        Bows,
        Pickes,
        Armor,
        Swords,
        Catapults,

        Venison,
        Furniture,
        MetalWare,
        Clothes,
        Wine,
        Salt,
        Spice,
        Silk
        
    }

    class AutoScout : BaseInstruction
    {
        static public Dictionary<Resource, WrapImg> resdict = new Dictionary<Resource, WrapImg>()
        {
            {Resource.Stack, new WrapImg("res\\res_stack_14.bmp", 14) },

            {Resource.Wood, new WrapImg("res\\res_wood_15.bmp", 15) },
            {Resource.Stone, new WrapImg("res\\res_stone_15.bmp", 15) },
            {Resource.Iron, new WrapImg("res\\res_iron_15.bmp", 15) },
            {Resource.Pitch, new WrapImg("res\\res_pitch_14.bmp", 14) },

            {Resource.Apples, new WrapImg("res\\res_apples_06.bmp", 6) },
            {Resource.Cheese, new WrapImg("res\\res_cheese_06.bmp", 6) },
            {Resource.Meat, new WrapImg("res\\res_meat_08.bmp", 8) },
            {Resource.Bread, new WrapImg("res\\res_bread_11.bmp", 11) },
            {Resource.Vegetables, new WrapImg("res\\res_vegetables_11.bmp", 11) },
            {Resource.Fish, new WrapImg("res\\res_fish_17.bmp", 17) },
            {Resource.Ale, new WrapImg("res\\res_ale_14.bmp", 14) },

            {Resource.Bows, new WrapImg("res\\res_bow_22.bmp", 22) },
            {Resource.Pickes, new WrapImg("res\\res_pickes_08.bmp", 8) },
            {Resource.Armor, new WrapImg("res\\res_armor_03.bmp", 3) },
            {Resource.Swords, new WrapImg("res\\res_sword.bmp", 9, 9, true, 50) },
            {Resource.Catapults, new WrapImg("res\\res_catapults_07.bmp", 7) },

            {Resource.Venison, new WrapImg("res\\res_venison_11.bmp", 11, 0, false, 35) },
            {Resource.Furniture, new WrapImg("res\\res_furniture_13.bmp", 13) },
            {Resource.MetalWare, new WrapImg("res\\res_metalwear_18.bmp", 18) },
            {Resource.Clothes, new WrapImg("res\\res_cloth_06.bmp", 6) },
            {Resource.Wine, new WrapImg("res\\res_wine_14.bmp", 14) },
            {Resource.Salt, new WrapImg("res\\res_salt_06.bmp", 6) },
            {Resource.Spice, new WrapImg("res\\res_spice_08.bmp", 8) },
            {Resource.Silk, new WrapImg("res\\res_silk_11.bmp", 11) }
        };
        private const double SCOUT_SPEED = 1.91;
        private Coords village_pos = new Coords(577, 415);

        private DateTime? card_ended;
        private int card_value = 1;
        private int village;

        private List<WrapImg> targets = new List<WrapImg>();
        private List<double> return_time = new List<double>();
        private List<ScoutTarget> sended_scouts = new List<ScoutTarget>();

        public int Available_scouts = 8;

        ImageReader reader;

        public AutoScout(int village, double execute_rate_sec, double defer = 0)
        {
            this.village = village;
            last_execute = DateTime.Now;
            this.execute_rate_sec = defer;
            this.reader = new ImageReader();
        }
        public void AddTarget(Resource resource)
        {
            targets.Add(resdict[resource]);
        }
        
        public void ActivateCard(int value, params int[] when_ended)
        {
            card_ended = DateTime.Now.AddSeconds((when_ended[0] * 60 + when_ended[1]) * 60 + when_ended[2]);
            card_value = value;
        }
        public void ActivateCard(int value, DateTime end_time)
        {
            card_ended = end_time;
            card_value = value;
        }

        public override void Execute()
        {
            if (!IsReady())
                return;

            Commands.ResetVillageNumber(village);
            Commands.ZoomOutMap(1);
            Commands.ActDectFilter(FilterEnabled.Scout);

            foreach (var item in targets)
            {
                List<Pair> target = reader.FindImageOnScreen(MainScreen.READER_AREA, item,true);
                if(target.Count != 0)
                {
                    Commands.WriteToScoutLog($"{village}| Founded \"{item.Path.Substring(8, item.Path.Length - 15)}\" {target.Count}");
                    int scouts_onstack = target.Count > Available_scouts ? 1 : Available_scouts / target.Count;
                    foreach (var stc in target)
                    {
                        if (!AlreadySended(stc))
                        {
                            Controller.AutoClick(stc);
                            Controller.AutoClick(MainScreen.MIDDLE_OFSCREEN);
                            Commands.Scouting.SendScout(scouts_onstack);
                            sended_scouts.Add(new ScoutTarget(scouts_onstack, CountNextExecute(new Coords(stc.X, stc.Y)), DateTime.Now, stc));
                            Available_scouts -= scouts_onstack;
                            last_execute = DateTime.Now;
                            Commands.WriteToScoutLog(village.ToString() + "| Scouts sended: " + scouts_onstack.ToString() + " Resource: " + item.Path.Substring(8, item.Path.Length - 15));

                            if (Available_scouts > 0)
                            {
                                Commands.ResetVillageNumber(village);
                                Commands.ZoomOutMap(1);
                            }
                            else
                            {
                                Completed();
                                return;
                            }
                        }
                    }
                    if (Available_scouts == 0)
                    {
                        Completed();
                        return;
                    }
                }
            }

            Commands.WriteToLog("No resources on the map");
            execute_rate_sec = 120;
            Completed();

        }
        public override bool IsReady()
        {
            sended_scouts.RemoveAll((ScoutTarget target) =>
            {
                if (target.Returned())
                    Available_scouts += target.Scouts;
                return target.Returned();
            });
            return Available_scouts > 0;
            //return last_execute == null ? true : DateTime.Now.Subtract(last_execute).TotalSeconds >= execute_rate_sec;
        }
        public override void Completed()
        {
            //double max = 0;
            //foreach (var item in return_time)
            //{
            //    max = item > max ? item : max;
            //}
            //execute_rate_sec = max;
            //return_time.Clear();

            //Commands.DoSomething();
            Commands.WriteToScoutLog("---------------");
        }
        
        private bool AlreadySended(Pair pos)
        {
            foreach (var scout in sended_scouts)
            {
                if (scout.SamePos(pos))
                    return true;
            }
            return false;
        }
        private double CountNextExecute(Coords target)
        {
            double distance = Math.Sqrt(Math.Pow((int)target.X - (int)village_pos.X, 2) + Math.Pow((int)target.Y - (int)village_pos.Y, 2));
            return ((distance / SCOUT_SPEED) * 2) / CheckCard();
        }
        private int CheckCard()
        {
           
            if (card_ended == null)
                return 1;
            else if(DateTime.Now >= card_ended)
            {
                card_ended = null;
                return 1;
            }
            else
            {
                return card_value;
            }
        }

    }

    class ScoutTarget
    {
        public int Scouts;
        public DateTime Sended_time;
        public double Return_time;
        public Pair Pos;

        public ScoutTarget(int scouts,double return_time,DateTime sended_time, Pair pos)
        {
            Scouts = scouts;
            Return_time = return_time;
            Sended_time = sended_time;
            Pos = pos;
        }
        public bool Returned()
        {
            return DateTime.Now.Subtract(Sended_time).TotalSeconds >= Return_time;
        }
        public bool SamePos(Pair target)
        {
            int x = Math.Abs((int)target.X - (int)Pos.X);
            int y = Math.Abs((int)target.Y - (int)Pos.Y);
            return x < 50 && y < 50;
        }
    }
}
