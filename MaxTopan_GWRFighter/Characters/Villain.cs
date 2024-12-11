using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Characters
{
    public abstract class Villain : ICharacter
    {
        public string Name { get; set; }
        public int Health { get; set; } = 50;
        public int AttackPower { get; set; } = 10;
        public Villain(string name)
        {
            Name = name;
        }
        public void Attack(ICharacter hero)
        {
            hero.Damage(AttackPower);

            /* TODO: MOVE TO SOMETHING THAT OWNS DIALOGUE DUE TO SRP */
            Console.WriteLine($"{Name} attacks {hero.Name} for {AttackPower} damage!");
        }

        public void Heal(int value)
        {
            throw new NotImplementedException();
        }

        public void Damage(int value)
        {
            throw new NotImplementedException();
        }
    }
}
