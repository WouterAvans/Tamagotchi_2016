using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Tamagotchi_prog.Models
{
    public class MyContextInitializer : DropCreateDatabaseIfModelChanges<MyContext>
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
                Sleep = 30
            });

            context.SaveChanges();
        }
    }
}
