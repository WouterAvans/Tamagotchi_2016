using System;
using System.Collections.Generic;

namespace Tamagotchi_prog.Models.GameActions
{
    public abstract class GameAction
    {
        protected Actions Action { get; set; }

        public abstract int ExecuteGameAction(Tamagotchi tamagotchi, Dictionary<String, double> actionTimeSpan);

        public abstract int StopAction(Tamagotchi tamagotchi, Dictionary<String, double> actionMultipliers , double passedTime);

        public Boolean CheckDeath(Tamagotchi tamagotchi)
        {
            if (tamagotchi.StatusEffects.Crazy)
            {
                var random = new Random();
                return random.Next(0, 1) == 1;
            }
            return false;
        }
    }
}
