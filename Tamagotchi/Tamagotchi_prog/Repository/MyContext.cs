using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models
{
    public class MyContext : DbContext
    {
        public DbSet<Tamagotchi> Tamagotchis { get; set; }

        public MyContext()
            : base("name=DefaultConnection")
        {
            System.Data.Entity.Database.SetInitializer(new MyContextInitializer());
        }

    }
}