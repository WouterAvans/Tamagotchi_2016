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

        public override void ExecuteGameAction(Tamagotchi tamagotchi, Dictionary<String, double> actionMultipliers, Dictionary<String, double> actionTimeSpan)
        {

        }
    }
}