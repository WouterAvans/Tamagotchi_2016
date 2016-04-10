using System;
using System.ComponentModel.Design;
using System.Threading;
using Ninject;
using Tamagotchi_prog.Models;
using Tamagotchi_prog.Models.GameActions;
using Tamagotchi_prog.Models.GameRules;

namespace Tamagotchi_Console
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var commandHandler = new CommandHandler();

            Console.WriteLine("----------Welcome to tamagotchi--------");
            Console.WriteLine("----------Available Commands-----------");
            Console.WriteLine("Select [TamagotchiName]");
            Console.WriteLine("Action [Eat | Hug | Play | Sleep | Workout]");
            Console.WriteLine("Status [TamagotchiName]");
            Console.WriteLine("Create [TamagotchiName]");
            Console.WriteLine("Clear");
            Console.WriteLine("Exit");
            Console.WriteLine("-------------Good Luck-----------------");

            while (true)
            {
                Console.WriteLine("Enter Command:");
                var command = Console.ReadLine();
                command = command.ToLower();

                if (command.Equals("exit"))
                {
                    return;
                }

                if (!commandHandler.HandleCommand(command))
                {
                    Console.WriteLine("Invalid Command");
                }
            }
        }
    }
}
