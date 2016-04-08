using System;
using System.Collections.Generic;
using Tamagotchi_prog.Models;

namespace Tamagotchi_lib.GameRules
{
    public class HungerRule : IGameRule
    {
        public void ExecuteRule(Tamagotchi tamagotchi, double timePassed, Dictionary<string, double> multipliers)
        {
            if (tamagotchi.StatusEffects.Contains(StatusEffect.Munchies))
            {
                tamagotchi.Hunger += (int)Math.Round(timePassed * (multipliers["hunger"] * 2));
            }
            else
            {
                tamagotchi.Hunger += (int)Math.Round(timePassed * multipliers["hunger"]);
            }

            if (tamagotchi.Hunger >= 100 && !tamagotchi.StatusEffects.Contains(StatusEffect.Athlete))
            {
                tamagotchi.IsDead = true;
            }

        }
    }
}