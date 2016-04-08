using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tamagotchi_prog.Models
{
    [Table("StatusEffect")]
    public class StatusEffect
    {
        public StatusEffect()
        {
            Tamagotchis = new List<Tamagotchi>();
        }

        [Key]
        public int StatusEffectId { get; set; }

        public virtual ICollection<Tamagotchi> Tamagotchis { get; set; }

        public Boolean Munchies { get; set; }

        public Boolean Athlete { get; set; }

        public Boolean Crazy { get; set; }

    }

}