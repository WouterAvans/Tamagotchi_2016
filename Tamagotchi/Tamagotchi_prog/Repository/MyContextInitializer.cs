using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
                LastAccessTime = new DateTime(2016, 4, 8, 11, 0, 0),
                StatusEffects = new StatusEffect()
                {
                    Athlete = false,
                    Crazy = false,
                    Munchies = false
                }
            });

            context.RuleSettings.Add(new RuleSettings()
            {
                Boredom = true,
                Hunger = true,
                Fatigue = true,
                Isolation = true
            });

            context.SaveChanges();
        }
    }
}
