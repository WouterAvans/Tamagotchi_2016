using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Ninject;
using Tamagotchi_prog.Models.GameActions;
using Tamagotchi_prog.Models.GameRules;
using Tamagotchi_prog.Repository;

namespace Tamagotchi_prog.Models
{
    public class Game
    {
        private readonly MyContext _myContext;
        public Dictionary<String, double> RuleMultipliers;
        public Dictionary<String, double> ActionMultipliers;
        public Dictionary<String, double> ActionTimeSpan;
        private GameAction _action;
        public List<IGameRule> EnabledRules { get; set; }

        public Game(List<IGameRule> enabledRules )
        {
            EnabledRules = enabledRules;
            _myContext = new MyContext();

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
            return Math.Round(((timeNow - time).TotalMinutes) , 2); 
        }

        public void ExecuteAllRules(Tamagotchi tamagotchi)
        {
            if (tamagotchi.LastAction != Actions.None)
            {
                var LastAction = PickActionObject(tamagotchi.LastAction);
                LastAction.StopAction(tamagotchi, ActionMultipliers, PassedTime(tamagotchi.LastAccessTime));
            }

            foreach (var rule in EnabledRules)
            {
                tamagotchi = rule.ExecuteRule(tamagotchi, PassedTime(tamagotchi.LastAccessTime) , RuleMultipliers);
            }

            tamagotchi.LastAccessTime = DateTime.Now;
            _myContext.Tamagotchis.AddOrUpdate(tamagotchi);
            _myContext.SaveChanges();
        }

        public void ExecuteAction(Tamagotchi tamagotchi, Actions action)
        {
            if (tamagotchi.LastAction != Actions.None)
            {
                var LastAction = PickActionObject(tamagotchi.LastAction);
                LastAction.StopAction(tamagotchi, ActionMultipliers, PassedTime(tamagotchi.LastAccessTime));
            }

            _action = PickActionObject(action);
            ExecuteAllRules(tamagotchi);
            _action.ExecuteGameAction(tamagotchi, ActionTimeSpan);

            tamagotchi.LastAccessTime = DateTime.Now;
            _myContext.Tamagotchis.AddOrUpdate(tamagotchi);
            _myContext.SaveChanges();
        }

        public GameAction PickActionObject(Actions action)
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
            return _myContext.Tamagotchis.Find("TestTamagotchi");
        }
    }
}