using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models.GameRules
{
    public class IsolationRule : IGameRule
    {
        public void ExecuteRule(Tamagotchi tamagotchi, double timePassed, Dictionary<String, int> multipliers)
        {
            tamagotchi.Health += (int) Math.Round(timePassed*multipliers["isolation"]);

            if (tamagotchi.Health <= 20)
            {
                tamagotchi.StatusEffects.Add(StatusEffect.Athlete);
            }
            else if (tamagotchi.StatusEffects.Contains(StatusEffect.Athlete))
            {
                tamagotchi.StatusEffects.Remove(StatusEffect.Athlete);
            }

            if(tamagotchi.Health >= 100)
            {
                tamagotchi.StatusEffects.Add(StatusEffect.Crazy);
            }
            else if (tamagotchi.StatusEffects.Contains(StatusEffect.Crazy))
            {
                tamagotchi.StatusEffects.Remove(StatusEffect.Crazy);
            }

        }
    }
}