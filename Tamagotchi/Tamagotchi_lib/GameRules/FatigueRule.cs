using System;
using System.Collections.Generic;
using Tamagotchi_prog.Models;

namespace Tamagotchi_lib.GameRules
{
    public class FatigueRule : IGameRule
    {
        public void ExecuteRule(Tamagotchi tamagotchi, double timePassed, Dictionary<string, double> multipliers)
        {

            tamagotchi.Sleep += (int)Math.Round(timePassed * multipliers["fatigue"]);

            if (tamagotchi.Sleep >= 100 && !tamagotchi.StatusEffects.Contains(StatusEffect.Athlete))
            {
                tamagotchi.IsDead = true;
            }
        }
    }
}