using System.Data.Entity;
using Tamagotchi_prog.Models;

namespace Tamagotchi_prog.Repository
{
    public class MyContext : DbContext
    {
        public DbSet<Tamagotchi> Tamagotchis { get; set; }
        public DbSet<RuleSettings> RuleSettings { get; set; }
        public DbSet<StatusEffect> StatusEffects { get; set; } 

        public MyContext()
            : base("name=DefaultConnection")
        {
            System.Data.Entity.Database.SetInitializer(new MyContextInitializer());
        }

    }
}