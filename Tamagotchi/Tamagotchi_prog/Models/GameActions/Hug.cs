using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models.GameActions
{
    public class Hug : GameAction
    {
        public Hug()
        {
            this.Action = Actions.Hug;
        }

        public override void ExecuteGameAction(Tamagotchi tamagotchi, Dictionary<String, double> actionMultipliers, Dictionary<String, double> actionTimeSpan)
        {

        }
    }
}