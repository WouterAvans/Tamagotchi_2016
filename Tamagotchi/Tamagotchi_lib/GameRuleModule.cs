using System;
using System.Collections.Generic;
using System.Linq;
using Ninject.Modules;
using Tamagotchi_lib.GameRules;
using Tamagotchi_prog.Models;

namespace Tamagotchi_lib
{
    public class GameRuleModule : NinjectModule
    {

        public override void Load()
        {
            var settingsDictonary = GetGameRule();

            if (settingsDictonary["Fatigue"])
            {
                Bind<IGameRule>().To<FatigueRule>();
            }

            if (settingsDictonary["Hunger"])
            {
                Bind<IGameRule>().To<HungerRule>();
            }

            if (settingsDictonary["Boredom"])
            {
                Bind<IGameRule>().To<BoredomRule>();
            }

            if (settingsDictonary["Isolation"])
            {
                Bind<IGameRule>().To<IsolationRule>();
            }

        }

        private Dictionary<String, bool> GetGameRule()
        {
            MyContext Context = new MyContext();
            return Context.Settings.First().EnabledRules;
        }
       
    }
}