using System;
using System.Collections.Generic;

namespace Tamagotchi_lib
{
    interface IGameAction
    {
        void ExecuteGameAction(Dictionary<String, double> actionMultipliers, Dictionary<String, double> actionTimeSpan);
    }
}
