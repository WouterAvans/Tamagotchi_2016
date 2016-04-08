using System;
using Tamagotchi_prog.Models;

namespace Tamagotchi_prog_console
{
    public class CommandHandler
    {

        public void PrintTamagotchi(Tamagotchi tama)
        {
                Console.WriteLine("Name: " + tama.Name);
                Console.WriteLine("LastAccesed: " + tama.LastAccessTime);
                Console.WriteLine("----------------------");
                Console.WriteLine("Health: " + tama.Health);
                Console.WriteLine("Hunger: " + tama.Hunger);
                Console.WriteLine("Boredom: " + tama.Boredom);
                Console.WriteLine("Sleep / Fatigue: " + tama.Sleep);
                Console.WriteLine("StatusEffects: " + tama.StatusEffects);
                Console.WriteLine("Death: " + tama.IsDead);
        }
    }
}
