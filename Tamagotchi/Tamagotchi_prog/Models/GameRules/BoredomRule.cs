using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models.GameRules
{
    public class BoredomRule : IGameRule
    {
        public void ExecuteRule(Tamagotchi tamagotchi, double timePassed, Dictionary<String, int> multipliers)
        {

            tamagotchi.Boredom += (int) Math.Round(timePassed * multipliers["Boredom"]);

            if (tamagotchi.Boredom >= 80)
            {
                tamagotchi.StatusEffects.Add(StatusEffect.Munchies);
            }
            else if(tamagotchi.StatusEffects.Contains(StatusEffect.Munchies))
            {
                tamagotchi.StatusEffects.Remove(StatusEffect.Munchies);
            }
        }
    }
}