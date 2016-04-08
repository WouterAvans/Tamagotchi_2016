using System;
using System.Collections.Generic;

namespace Tamagotchi_prog.Models.GameRules
{
    public class IsolationRule : IGameRule
    {
        public Tamagotchi ExecuteRule(Tamagotchi tamagotchi, double timePassed, Dictionary<string, double> multipliers)
        {
            tamagotchi.Health += (int) Math.Round(timePassed*multipliers["isolation"]);

            if (tamagotchi.Health <= 20)
            {
                tamagotchi.StatusEffects.Athlete = true;
            }
            else if (tamagotchi.StatusEffects.Athlete)
            {
                tamagotchi.StatusEffects.Athlete = false;
            }

            if(tamagotchi.Health >= 100)
            {
                tamagotchi.StatusEffects.Crazy = true;
            }
            else if (tamagotchi.StatusEffects.Crazy)
            {
                tamagotchi.StatusEffects.Crazy = false;
            }

            return tamagotchi;
        }

    }
}