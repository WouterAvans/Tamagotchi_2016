using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tamagotchi_prog.Models;
using Tamagotchi_prog.Repository;

namespace Tamagotchi.test
{
    public class MockMyContext : DbContext
    {
        public DbSet<Tamagotchi_prog.Models.Tamagotchi> Tamagotchis { get; set; }
        public DbSet<RuleSettings> RuleSettings { get; set; }
        public DbSet<StatusEffect> StatusEffects { get; set; } 

        public MockMyContext()
            : base("name=DefaultConnection")
        {
            System.Data.Entity.Database.SetInitializer(new MyContextInitializer());
        }
    }
}
