using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models.GameActions
{
    public class Workout : GameAction
    {
        public Workout()
        {
            this.Action = Actions.Workout;
        }

        public override int ExecuteGameAction(Tamagotchi tamagotchi, Dictionary<String, double> actionTimeSpan)
        {
            if (CheckDeath(tamagotchi))
            {
                tamagotchi.IsDead = true;
                return 0;
            }

            if (tamagotchi.CooldownTime <= 0)
            {
                tamagotchi.CooldownTime = actionTimeSpan["workout"];
                tamagotchi.LastAction = Actions.Workout;
                return 1;
            }
            return 0;
        }

        public override int StopAction(Tamagotchi tamagotchi, Dictionary<string, double> actionMultipliers, double passedTime)
        {
            if (tamagotchi.CooldownTime < passedTime)
            {
                tamagotchi.Health = (int)(tamagotchi.Health - actionMultipliers["workout"]);
                tamagotchi.LastAction = Actions.None;
                return 1;
            }
            return 0;
        }
    }
}