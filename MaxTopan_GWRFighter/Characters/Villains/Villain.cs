using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Characters.Villains
{
    public abstract class Villain : Character
    {
        public abstract string Description { get; }
        public abstract int AttackPower { get; protected set; }

        public virtual void TakeTurn(Character hero)
        {
            Attack(hero);
        }

        public override void Attack(Character hero)
        {
            hero.Damage(AttackPower);

            /* TODO: MOVE TO SOMETHING THAT OWNS DIALOGUE DUE TO SRP */
            Console.WriteLine($"{Name} attacks {hero.Name} for {AttackPower} damage!");
        }
    }
}
