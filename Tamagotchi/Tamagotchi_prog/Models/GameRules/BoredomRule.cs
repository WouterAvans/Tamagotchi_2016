using System;
using System.Collections.Generic;

namespace Tamagotchi_prog.Models.GameRules
{
    public class BoredomRule : IGameRule
    {
        public Tamagotchi ExecuteRule(Tamagotchi tamagotchi, double timePassed, Dictionary<string, double> multipliers)
        {
            tamagotchi.MunchieTime = (80 - tamagotchi.Boredom)/multipliers["boredom"];
            tamagotchi.Boredom += (int) Math.Round(timePassed * multipliers["boredom"]);

            if (tamagotchi.Boredom >= 80)
            {
                tamagotchi.StatusEffects.Munchies = true;
            }
            else if(tamagotchi.StatusEffects.Munchies)
            {
                tamagotchi.StatusEffects.Munchies = false;
            }

            return tamagotchi;
        }
    }
}