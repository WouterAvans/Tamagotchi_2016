using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models.GameRules
{
    public class FatigueRule : IGameRule
    {
        public void ExecuteRule(Tamagotchi tamagotchi, double timePassed, Dictionary<String, int> multipliers)
        {

            tamagotchi.Sleep += (int)Math.Round(timePassed * multipliers["fatigue"]);

            if (tamagotchi.Sleep >= 100 && !tamagotchi.StatusEffects.Contains(StatusEffect.Athlete))
            {
                tamagotchi.IsDead = true;
            }
        }
    }
}