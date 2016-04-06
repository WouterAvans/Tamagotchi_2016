using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tamagotchi_prog.Models
{
    public class Game
    {
        public double PassedTime(DateTime time)
        {
            DateTime timeNow = DateTime.Now;
            return Math.Round(((timeNow - time).TotalHours) , 2); 
        }
    }
}