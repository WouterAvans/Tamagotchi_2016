using System;
using System.Collections.Generic;
using System.Data.Entity;
using Tamagotchi_prog.Models;

namespace Tamagotchi_prog.Repository
{
    public class MyContextInitializer : DropCreateDatabaseAlways<MyContext>
    {

        protected override void Seed(MyContext context)
        {
            base.Seed(context);

            context.Tamagotchis.Add(new Tamagotchi()
            {
                Name = "TestTamagotchi",
                Boredom = 60,
                Health = 50,
                Hunger = 40,
                Sleep = 30,
                IsDead = false,
                LastAccessTime = DateTime.Now,
                StatusEffects = new List<StatusEffect>()
            });

            context.Settings.Add(new Settings()
            {
                EnabledRules = new Dictionary<String, bool>
                {
                    {"Boredom", true},
                    {"Hunger", true},
                    {"Fatigue", true},
                    {"Isolation", true}
                }
            });

            context.SaveChanges();
        }
    }
}
