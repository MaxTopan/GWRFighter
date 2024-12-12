using MaxTopan_GWRFighter.Characters;

namespace MaxTopan_GWRFighter.Models
{
    public class MagicWand : RandomChanceWeapon
    {
        public override string Name => "Magic Wand";

        public override int DamageAmount => 7;

        /// <summary>
        /// Percentage chance to heal Character using the wand
        /// </summary>
        public override double Percentage => 0.45;

        public int HealAmount => 15;

        public override void Use(Character hero, Character villain)
        {
            if (ChanceTrigger())
            {
                hero.Heal(HealAmount);
                Console.WriteLine($"{hero.Name} cast a spell to heal for {HealAmount}!");
            }

            Console.WriteLine($"{hero.Name} waves the {Name} for {DamageAmount} damage!");
            villain.Damage(DamageAmount);
        }
    }
}
