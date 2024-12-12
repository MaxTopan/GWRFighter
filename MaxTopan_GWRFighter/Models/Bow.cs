using MaxTopan_GWRFighter.Characters;

namespace MaxTopan_GWRFighter.Models
{
    /// <summary>
    /// Weapon with a chacne to deal additional crit damage
    /// </summary>
    public class Bow : RandomChanceWeapon
    {
        public override string Name => "Bow";

        public override int DamageAmount => 5;

        /// <summary>
        /// Percentage chance for Bow to crit
        /// </summary>
        public override double Percentage => 0.2;

        public override void Use(Character hero, Character villain)
        {
            int damage = DamageAmount;
            if (ChanceTrigger())
            {
                damage *= 4;
                Console.WriteLine($"The {Name} hit a weak spot!");
            }

            /* MOVE THIS TO SOMETHING THAT OWNS DIALGOUE DUE TO SRP */
            Console.WriteLine($"{hero.Name} shoots the {Name} for {damage} damage!");

            villain.Damage(damage);
        }
    }
}
