using MaxTopan_GWRFighter.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MaxTopan_GWRFighter.Program;

namespace MaxTopan_GWRFighter.Models
{
    public class Sword : IWeapon
    {
        public string Name => "Sword";
        public int Damage => 10;
        public void Use(Hero hero, Villain villain)
        {
            villain.Health -= Damage;
            Console.WriteLine($"{hero.Name} slashes with the {Name} for {Damage} damage!");
        }
    }
}
