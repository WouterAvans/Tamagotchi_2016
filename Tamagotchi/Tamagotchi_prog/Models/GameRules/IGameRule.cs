using System;
using System.Collections.Generic;

namespace Tamagotchi_prog.Models.GameRules
{
    public interface IGameRule
    {
        Tamagotchi ExecuteRule(Tamagotchi tamagotchi, double timePassed, Dictionary<String , double> multipliers);
    }
}
