using System;
using Tamagotchi_prog.Models;

namespace Tamagotchi_prog_console
{
    public class Program
    {
        static void Main(string[] args)
        {
            CommandHandler commandHandler = new CommandHandler();
            Game game = new Game();
            commandHandler.PrintTamagotchi(game.GetTamagotchi());
            Console.WriteLine("Bullshit");
            Console.ReadKey();
        }
    }
}
