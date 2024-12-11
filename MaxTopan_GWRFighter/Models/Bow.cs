﻿using MaxTopan_GWRFighter.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MaxTopan_GWRFighter.Program;

namespace MaxTopan_GWRFighter.Models
{
    /// <summary>
    /// Weapon with a chacne to deal additional crit damage
    /// </summary>
    public class Bow : RandomChanceWeapon
    {
        public override string Name => "Bow";

        public override int Damage => 5;

        public override double Percentage => 0.2;

        public override void Use(Hero hero, Villain villain)
        {
            int damage = Damage;
            if (ChanceTrigger())
            {
                damage *= 4;
            }

            villain.Health -= damage;

            /* MOVE THIS TO SOMETHING THAT OWNS DIALGOUE DUE TO SRP */
            Console.WriteLine($"{hero.Name} slashes with the {Name} for {Damage} damage!");
        }
    }
}
