using System;
using System.Collections.Generic;
using Tamagotchi_prog.Models;

namespace Tamagotchi_lib
{
    public class Game
    {
        public Dictionary<String, double> RuleMultipliers;
        public Dictionary<String, double> ActionMultipliers;
        public Dictionary<String, double> ActionTimeSpan;
        public GameActionModule ActionModule;
        public List<IGameRule> EnabledRules { get; set; }

        public Game()
        {
            //Base Rule Multipliers in minutes. Will be overriden by status effects
            RuleMultipliers = new Dictionary<string, double>
            {
                {"boredom", 0.25},
                {"isolation", 0.083},
                {"hunger", 0.083},
                {"sleep", 0.083}
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

            ActionModule = new GameActionModule();

        }
       
        public double PassedTime(DateTime time)
        {
            DateTime timeNow = DateTime.Now;
            return Math.Round(((timeNow - time).TotalMinutes) , 2); 
        }

        public void ExecuteAllRules(Tamagotchi tamagotchi)
        {
            foreach (var rule in EnabledRules)
            {
                rule.ExecuteRule(tamagotchi, PassedTime(tamagotchi.LastAccessTime) , RuleMultipliers);
            }
        }

        public void ExecuteAction(Tamagotchi tamagotchi, Action action)
        {
            
        }
    }
}