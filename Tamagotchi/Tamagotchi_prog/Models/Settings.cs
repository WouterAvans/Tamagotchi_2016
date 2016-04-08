using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models
{
    [Table("Settings")]
    public class Settings
    {
        //This was required for entity framework to preform a succesfull model to code...
        [Key] public int SettingsId { get; set; }

        //Contains all rules currently enabled
        public Dictionary<String, bool> EnabledRules { get; set; }
    }
}