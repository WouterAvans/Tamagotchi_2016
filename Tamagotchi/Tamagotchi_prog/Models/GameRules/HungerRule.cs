using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models.GameRules
{
    public class HungerRule : IGameRule
    {
        public void ExecuteRule(Tamagotchi tamagotchi, double timePassed, Dictionary<String, int> multipliers)
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