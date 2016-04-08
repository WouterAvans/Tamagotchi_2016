using System;
using System.Collections.Generic;

namespace Tamagotchi_prog.Models.GameActions
{
    interface IGameAction
    {
        void ExecuteGameAction(Dictionary<String, double> actionMultipliers, Dictionary<String, double> actionTimeSpan);
    }
}
