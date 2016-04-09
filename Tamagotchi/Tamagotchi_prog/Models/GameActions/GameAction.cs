using System;
using System.Collections.Generic;

namespace Tamagotchi_prog.Models.GameActions
{
    public abstract class GameAction
    {
        protected Actions Action { get; set; }

        public abstract void ExecuteGameAction(Tamagotchi tamagotchi, Dictionary<String, double> actionMultipliers, Dictionary<String, double> actionTimeSpan);
    }
}
