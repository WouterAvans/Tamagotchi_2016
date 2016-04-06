using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using Tamagotchi_prog.Models;
using Tamagotchi_prog.Models.GameRules;

namespace Tamagotchi_prog.Repository
{
    public class GameRuleModule : NinjectModule
    {
        private String _gameRule;

        public override void Load()
        {
            _gameRule = GetGameRule();
            _gameRule = _gameRule.ToLower();

            switch (_gameRule)
            {
                case "fatigue":
                    Bind<IGameRule>().To<FatigueRule>();
                    break;
                case "hunger":
                    Bind<IGameRule>().To<HungerRule>();
                    break;
                case "boredom":
                    Bind<IGameRule>().To<BoredomRule>();
                    break;
                case "isolation":
                    Bind<IGameRule>().To<IsolationRule>();
                    break;
                default:
                    throw new Exception("unknown rule given");
            }
        }

        private String GetGameRule()
        {
            
        }
       
    }
}