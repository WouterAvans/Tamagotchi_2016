using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models
{
    [Table("Tamagotchi")]
    public class Tamagotchi
    {
        [Key]
        public String Name { get; set; }

        public int Hunger { get; set; }

        public int Sleep { get; set; }

        public int Boredom { get; set; }

        public int Health { get; set; }

        public DateTime LastAccessTime { get; set; }

    }
}