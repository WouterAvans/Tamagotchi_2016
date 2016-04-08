using System;
using System.Collections.Generic;
using Tamagotchi_prog.Models;

namespace Tamagotchi_lib
{
    public interface IGameRule
    {
        void ExecuteRule(Tamagotchi tamagotchi, double timePassed, Dictionary<String , double> multipliers);
    }
}
