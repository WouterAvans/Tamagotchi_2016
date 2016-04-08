using System.Data.Entity;
using Tamagotchi_prog.Models;

namespace Tamagotchi_prog.Repository
{
    public class MyContext : DbContext
    {
        public DbSet<Tamagotchi> Tamagotchis { get; set; }
        public DbSet<Settings> Settings { get; set; }

        public MyContext()
            : base("name=DefaultConnection")
        {
            System.Data.Entity.Database.SetInitializer(new MyContextInitializer());
        }

    }
}