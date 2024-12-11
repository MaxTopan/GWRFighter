using MaxTopan_GWRFighter.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Models
{
    public class MagicWand : RandomChanceWeapon
    {
        public override string Name => "Magic Wand";

        public override int Damage => 7;

        public override double Percentage => 0.3;

        public int HealAmount => 15;

        public override void Use(ICharacter hero, ICharacter villain)
        {
            int damage = Damage;
            if (ChanceTrigger())
            {
                /* CHANGE THIS IMPLEMENTATION TO BE VIA A METHOD */
                hero.Heal(HealAmount);
                Console.WriteLine($"{hero.Name} gets healed for {HealAmount}");
            }

            villain.Health -= damage;

            /* MOVE THIS TO SOMETHING THAT OWNS DIALGOUE DUE TO SRP */
            Console.WriteLine($"{hero.Name} slashes with the {Name} for {Damage} damage!");
        }
    }
}
