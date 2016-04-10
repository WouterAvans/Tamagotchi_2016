using System;
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
            Ninject.IKernel kernel = new StandardKernel(new GameRuleModule());
            var game = kernel.Get<Game>();
            var tamagotchi = game.GetTamagotchi();
            game.ExecuteAllRules(tamagotchi);
            Console.WriteLine(tamagotchi.Name);
            Console.WriteLine(tamagotchi.LastAccessTime);
            Console.WriteLine(tamagotchi.Health);
            Console.WriteLine(tamagotchi.Hunger);
            Console.WriteLine(tamagotchi.Boredom);
            Console.WriteLine(tamagotchi.Sleep);
            Console.WriteLine(tamagotchi.IsDead);
            game.ExecuteAction(tamagotchi, Actions.Eat);
            Console.WriteLine(tamagotchi.Name);
            Console.WriteLine(tamagotchi.LastAccessTime);
            Console.WriteLine(tamagotchi.Health);
            Console.WriteLine(tamagotchi.Hunger);
            Console.WriteLine(tamagotchi.Boredom);
            Console.WriteLine(tamagotchi.Sleep);
            Console.WriteLine(tamagotchi.IsDead);
            Console.ReadKey();
        }
    }
}
