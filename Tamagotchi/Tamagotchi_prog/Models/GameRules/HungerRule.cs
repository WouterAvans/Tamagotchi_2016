using System;
using System.Collections.Generic;

namespace Tamagotchi_prog.Models.GameRules
{
    public class HungerRule : IGameRule
    {
        public Tamagotchi ExecuteRule(Tamagotchi tamagotchi, double timePassed, Dictionary<string, double> multipliers)
        {
            if (tamagotchi.StatusEffects.Munchies)
            {
                tamagotchi.Hunger += (int)Math.Round(timePassed * (multipliers["hunger"] * 2));
            }
            else
            {
                tamagotchi.Hunger += (int)Math.Round(timePassed * multipliers["hunger"]);
            }

            if (tamagotchi.Hunger >= 100 && !tamagotchi.StatusEffects.Athlete)
            {
                tamagotchi.IsDead = true;
            }

            return tamagotchi;
        }
    }
}