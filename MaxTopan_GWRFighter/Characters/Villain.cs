using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Characters
{
    public class Villain
    {
        public string Name { get; set; }
        public int Health { get; set; } = 50;
        public int AttackPower { get; set; } = 10;
        public Villain(string name)
        {
            Name = name;
        }
        public void Attack(Hero hero)
        {
            hero.Health -= AttackPower;
            Console.WriteLine($"{Name} attacks {hero.Name} for {AttackPower} damage!");
        }
    }
}
