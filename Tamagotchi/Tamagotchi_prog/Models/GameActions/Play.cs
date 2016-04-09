using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models.GameActions
{
    public class Play : GameAction
    {
        public Play()
        {
            this.Action = Actions.Play;
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
                tamagotchi.CooldownTime = actionTimeSpan["play"];
                tamagotchi.LastAction = Actions.Play;
                return 1;
            }
            return 0;
        }

        public override int StopAction(Tamagotchi tamagotchi, Dictionary<string, double> actionMultipliers, double passedTime)
        {
            if (tamagotchi.CooldownTime < passedTime)
            {
                tamagotchi.Boredom = (int)(tamagotchi.Boredom - actionMultipliers["play"]);
                tamagotchi.LastAction = Actions.None;
                return 1;
            }
            return 0;
        }
    }
}