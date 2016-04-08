using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models
{
    [Table("RuleSettings")]
    public class RuleSettings
    {
        //This was required for entity framework to preform a succesfull model to code...
        [Key] public int SettingsId { get; set; }

        public Boolean Boredom { get; set; }
        public Boolean Hunger { get; set; }
        public Boolean Fatigue { get; set; }
        public Boolean Isolation { get; set; }

    }
}