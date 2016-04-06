using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models
{
    [Table("Settings")]
    public class Settings
    {
        public Dictionary<String, bool> EnabledRules;
    }
}