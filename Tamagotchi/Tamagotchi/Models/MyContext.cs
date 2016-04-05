using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Tamagotchi.Models
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=Azure")
        {
            System.Data.Entity.Database.SetInitializer(new MyContextInitializer());
        }

        public DbSet<Tamagotchi> Tamagotchis { get; set; }
    }
}