using System;
using System.Collections.Generic;

namespace Tamagotchi_prog.Models.GameRules
{
    public class FatigueRule : IGameRule
    {
        public Tamagotchi ExecuteRule(Tamagotchi tamagotchi, double timePassed, Dictionary<string, double> multipliers)
        {

            tamagotchi.Sleep += (int)Math.Round(timePassed * multipliers["fatigue"]);

            if (tamagotchi.Sleep >= 100 && !tamagotchi.StatusEffects.Athlete)
            {
                tamagotchi.IsDead = true;
            }

            return tamagotchi;
        }
    }
}