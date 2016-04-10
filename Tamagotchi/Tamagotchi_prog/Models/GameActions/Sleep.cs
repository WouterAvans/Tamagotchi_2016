using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models.GameActions
{
    public class Sleep : GameAction
    {
        public Sleep()
        {
            this.Action = Actions.Sleep;
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
                tamagotchi.CooldownTime = actionTimeSpan["sleep"];
                tamagotchi.LastAction = Actions.Sleep;
                return 1;
            }
            return 0;
        }

        public override int StopAction(Tamagotchi tamagotchi, Dictionary<string, double> actionMultipliers, double passedTime)
        {
            if (tamagotchi.CooldownTime < passedTime)
            {
                tamagotchi.Sleep = (int)(tamagotchi.Sleep - actionMultipliers["sleep"]);
                tamagotchi.LastAction = Actions.None;
                return 1;
            }
            return 0;
        }
    }
}