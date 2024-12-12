using MaxTopan_GWRFighter.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Models
{
    internal class Coin : RandomChanceWeapon
    {
        public override string Name => "Coin of Destiny";

        public override int DamageAmount => 25;

        public override double Percentage => 0.5;

        public override void Use(Character hero, Character villain)
        {
            if (((Utilities.IRandomChance)this).ChanceTrigger())
            {
                Console.WriteLine($"Tails. Fate gets {hero.Name} for {DamageAmount}.");
                hero.Damage(DamageAmount);
            }
            else
            {
                Console.WriteLine($"Heads! Fate strikes {villain.Name} for {DamageAmount}!");
                villain.Damage(DamageAmount);
            }
        }
    }
}
