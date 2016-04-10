using System;
using System.Linq;
using Ninject;
using Tamagotchi_prog.Models;
using Tamagotchi_prog.Models.GameActions;
using Tamagotchi_prog.Models.GameRules;

namespace Tamagotchi_Console
{
    public class CommandHandler
    {
        private Game _game;
        private Tamagotchi _selectedTamagotchi;

        public CommandHandler()
        {
            IKernel kernel = new StandardKernel(new GameRuleModule());
            _game = kernel.Get<Game>();
        }

        public Boolean HandleCommand(String s)
        {
            string[] commandStrings = s.Split(null);

            if (_selectedTamagotchi != null)
            {
                _game.ExecuteAllRules(_selectedTamagotchi);
            }

            switch (commandStrings[0])
            {
                case "select":
                    _selectedTamagotchi = _game.MyContext.Tamagotchis.Find(commandStrings[1]);
                    if (_selectedTamagotchi == null)
                    {
                        Console.WriteLine("Invalid Tamagotchi name");
                    }
                    else
                    {
                        _game.ExecuteAllRules(_selectedTamagotchi);
                    }
                    
                    return true;
                case "action":
                    if (_selectedTamagotchi != null)
                    {
                        switch (commandStrings[1])
                        {
                            case "eat":
                                _game.ExecuteAction(_selectedTamagotchi, Actions.Eat);
                                return true;
                            case "hug":
                                _game.ExecuteAction(_selectedTamagotchi, Actions.Hug);
                                return true;
                            case "play":
                                _game.ExecuteAction(_selectedTamagotchi, Actions.Play);
                                return true;
                            case "sleep":
                                _game.ExecuteAction(_selectedTamagotchi, Actions.Sleep);
                                return true;
                            case "workout":
                                _game.ExecuteAction(_selectedTamagotchi, Actions.Workout);
                                return true;
                            default:
                                Console.WriteLine("Invalid Action");
                                return true;
                        }
                    }

                    Console.WriteLine("Please select a tamagotchi first");
                    return true;

                case "status":
                    if (_selectedTamagotchi != null)
                    {
                        PrintStatus(_selectedTamagotchi);
                        return true;
                    }
                    else if (commandStrings[1] != null)
                    {
                        _selectedTamagotchi = _game.MyContext.Tamagotchis.Find(commandStrings[1]);
                        PrintStatus(_selectedTamagotchi);
                        return true;
                    }
                    Console.WriteLine("Please select a tamagotchi first");
                    break;
                case "clear":
                    Console.Clear();
                    return true;
                case "create":
                    if (commandStrings[1] != null)
                    {
                        foreach (var tamagotchi in _game.MyContext.Tamagotchis.ToList())
                        {
                            if (tamagotchi.Name.Equals(commandStrings[1]))
                            {
                                return true;
                            }
                        }

                        _game.CreateTamagotchi(commandStrings[1]);

                    }
                    else
                    {
                        Console.WriteLine("Please provide a valid name");
                    }

                    return true;
                default:
                    return false;
            }
            return true;
        }

        private void PrintStatus(Tamagotchi tamagotchi)
        {
            Console.WriteLine();
            Console.WriteLine("Name " + tamagotchi.Name);
            Console.WriteLine("Hunger: " + tamagotchi.Hunger);
            Console.WriteLine("Sleep: " + tamagotchi.Sleep);
            Console.WriteLine("Boredom: " + tamagotchi.Boredom);
            Console.WriteLine("Health: " + tamagotchi.Health);
            Console.WriteLine("LastAction: " + tamagotchi.LastAction);
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("---------------Tamagotchi 2016---------------");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine();
        }
    }
}
