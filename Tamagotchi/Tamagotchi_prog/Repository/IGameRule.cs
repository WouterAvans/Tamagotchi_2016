using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Tamagotchi_prog.Models
{
    public interface IGameRule
    {
        void ExecuteRule(Tamagotchi tamagotchi, double timePassed, Dictionary<String , int> multipliers);
    }
}
