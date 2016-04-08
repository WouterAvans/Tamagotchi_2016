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
        public GameActionModule ActionModule;
        public List<IGameRule> EnabledRules { get; set; }

        public Game(List<IGameRule> enabledRules )
        {
            EnabledRules = enabledRules;
            _myContext = new MyContext();
            ActionModule = new GameActionModule();

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
            foreach (var rule in EnabledRules)
            {
                tamagotchi = rule.ExecuteRule(tamagotchi, PassedTime(tamagotchi.LastAccessTime) , RuleMultipliers);
            }

            _myContext.Tamagotchis.AddOrUpdate(tamagotchi);
            _myContext.SaveChanges();
        }

        public void ExecuteAction(Tamagotchi tamagotchi, Action action)
        {
            
        }

        public Tamagotchi GetTamagotchi()
        {
            return _myContext.Tamagotchis.Find("TestTamagotchi");
        }
    }
}