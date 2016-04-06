using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models
{
    public class Game
    {
        public Dictionary<String, int> Multipliers;
        public List<IGameRule> EnabledRules { get; set; }

        public Game()
        {
            //Base Multipliers used will overriden by status effects
            Multipliers = new Dictionary<string, int>
            {
                {"boredom", 15},
                {"isolation", 5},
                {"hunger", 5},
                {"sleep", 5}
            };
        }
       
        public double PassedTime(DateTime time)
        {
            DateTime timeNow = DateTime.Now;
            return Math.Round(((timeNow - time).TotalHours) , 2); 
        }

        public void ExecuteAllRules(Tamagotchi tamagotchi)
        {
            foreach (var rule in EnabledRules)
            {
                rule.ExecuteRule(tamagotchi, PassedTime(tamagotchi.LastAccessTime) , Multipliers);
            }
        }
    }
}