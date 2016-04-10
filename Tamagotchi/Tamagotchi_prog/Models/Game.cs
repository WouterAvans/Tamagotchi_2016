using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.UI.WebControls;
using Ninject;
using Tamagotchi_prog.Models.GameActions;
using Tamagotchi_prog.Models.GameRules;
using Tamagotchi_prog.Repository;

namespace Tamagotchi_prog.Models
{
    public class Game
    {
        private GameAction _action;

        public MyContext MyContext { get; set;}
        public Dictionary<String, double> RuleMultipliers { get; set; }
        public Dictionary<String, double> ActionMultipliers { get; set; }
        public Dictionary<String, double> ActionTimeSpan { get; set; }
        public List<IGameRule> EnabledRules { get; set; }

        public Game(List<IGameRule> enabledRules, MockMyContext mockMyContext)
        {
            EnabledRules = enabledRules;
            mockMyContext = new MockMyContext();

            //Base Rule Multipliers in minutes. Will be overriden by status effects
            RuleMultipliers = new Dictionary<string, double>
            {
                {"boredom", 0.25},
                {"isolation", 0.083},
                {"hunger", 0.083},
                {"fatigue", 0.083}
            };

            //Base Action Multipliers.
            ActionMultipliers = new Dictionary<string, double>
            {
                {"eat", 100},
                {"sleep", 100},
                {"play", 10},
                {"workout", 5},
                {"hug", 10}
            };

            //Time actions last in minutes
            ActionTimeSpan = new Dictionary<string, double>
            {
                {"eat", 0.5},
                {"sleep", 120},
                {"play", 0.5},
                {"workout", 1},
                {"hug", 1}
            };
        }

        public Game(List<IGameRule> enabledRules )
        {
            EnabledRules = enabledRules;
            MyContext = new MyContext();

            //Base Rule Multipliers in minutes. Will be overriden by status effects
            RuleMultipliers = new Dictionary<string, double>
            {
                {"boredom", 0.25},
                {"isolation", 0.083},
                {"hunger", 0.083},
                {"fatigue", 0.083}
            };

            //Base Action Multipliers.
            ActionMultipliers = new Dictionary<string, double>
            {
                {"eat", 100},
                {"sleep", 100},
                {"play", 10},
                {"workout", 5},
                {"hug", 10}
            };

            //Time actions last in minutes
            ActionTimeSpan = new Dictionary<string, double>
            {
                {"eat", 0.5},
                {"sleep", 120},
                {"play", 0.5},
                {"workout", 1},
                {"hug", 1}
            };
        }
       
        public double PassedTime(DateTime time)
        {
             var timeNow = DateTime.Now;
             return Math.Round(((timeNow - time).TotalMinutes), 2);
        }

        public void CreateTamagotchi(String name)
        {
            var newTamagotchi = new Tamagotchi()
            {
                Name = name,
                Health = 0,
                Hunger = 0,
                Sleep = 0,
                Boredom = 0,
                IsDead = false,
                LastAccessTime = DateTime.Now,
                LastAction = Actions.None,
                StartActionTime = DateTime.Now,
                ImageURL = "../Content/img/normal_tamagotchi.png",
                StatusEffects = new StatusEffect()
                {
                    Athlete = false,
                    Crazy = false,
                    Munchies = false
                }
            };

            MyContext.Tamagotchis.Add(newTamagotchi);
            MyContext.SaveChanges();
        }

        public void ExecuteAllRules(Tamagotchi tamagotchi)
        {
            CheckActionReady(tamagotchi);

            foreach (var rule in EnabledRules)
            {
                tamagotchi = rule.ExecuteRule(tamagotchi, PassedTime(tamagotchi.LastAccessTime) , RuleMultipliers);
            }

            tamagotchi.LastAccessTime = DateTime.Now;
            CheckMinMaxValues(tamagotchi);

            MyContext.Tamagotchis.AddOrUpdate(tamagotchi);
            MyContext.SaveChanges();
           
        }

        public void ExecuteAction(Tamagotchi tamagotchi, Actions action)
        {
            CheckActionReady(tamagotchi);

            _action = PickActionObject(action);
            ExecuteAllRules(tamagotchi);
            _action.ExecuteGameAction(tamagotchi, ActionTimeSpan);
            
            tamagotchi.LastAccessTime = DateTime.Now;
            CheckMinMaxValues(tamagotchi);

            MyContext.Tamagotchis.AddOrUpdate(tamagotchi);
            MyContext.SaveChanges();
            
        }

        private void CheckActionReady(Tamagotchi tamagotchi)
        {
            if (tamagotchi.LastAction != Actions.None)
            {
                var LastAction = PickActionObject(tamagotchi.LastAction);
                LastAction.StopAction(tamagotchi, ActionMultipliers, PassedTime(tamagotchi.StartActionTime));
            }
        }

        private void CheckMinMaxValues(Tamagotchi tamagotchi)
        {
            if (tamagotchi.Hunger > 100)
            {
                tamagotchi.Hunger = 100;
            }
            else if (tamagotchi.Hunger < 0)
            {
                tamagotchi.Hunger = 0;
            }

            if (tamagotchi.Health > 100)
            {
                tamagotchi.Health = 100;
            }
            else if (tamagotchi.Health < 0)
            {
                tamagotchi.Health = 0;
            }

            if (tamagotchi.Boredom > 100)
            {
                tamagotchi.Boredom = 100;
            }
            else if (tamagotchi.Boredom < 0)
            {
                tamagotchi.Boredom = 0;
            }

            if (tamagotchi.Sleep > 100)
            {
                tamagotchi.Sleep = 100;
            }
            else if (tamagotchi.Sleep < 0)
            {
                tamagotchi.Sleep = 0;
            }

        }

        private GameAction PickActionObject(Actions action)
        {
            GameAction returnAction;

            switch (action)
            {
                case Actions.Hug:
                    returnAction = new Hug();
                    break;
                case Actions.Workout:
                    returnAction = new Workout();
                    break;
                case Actions.Play:
                    returnAction = new Play();
                    break;
                case Actions.Eat:
                    returnAction = new Eat();
                    break;
                case Actions.Sleep:
                    returnAction = new Sleep();
                    break;
                default:
                    throw new Exception("Invalid Action");
            }
            return returnAction;
        }

        public Tamagotchi GetTamagotchi()
        {
            return MyContext.Tamagotchis.Find("TestTamagotchi");
        }
    }
}