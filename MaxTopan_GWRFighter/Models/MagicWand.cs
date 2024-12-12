using MaxTopan_GWRFighter.Characters;

namespace MaxTopan_GWRFighter.Models
{
    public class MagicWand : RandomChanceWeapon
    {
        public override string Name => "Magic Wand";

        public override int DamageAmount => 7;

        public override double Percentage => 0.3;

        public int HealAmount => 15;

        public override void Use(Character hero, Character villain)
        {
            if (ChanceTrigger())
            {
                hero.Heal(HealAmount);
                /* MOVE THIS TO SOMETHING THAT OWNS DIALGOUE DUE TO SRP */
                Console.WriteLine($"{hero.Name} cast a spell to heal for {HealAmount}!");
            }
            /* MOVE THIS TO SOMETHING THAT OWNS DIALGOUE DUE TO SRP */
            Console.WriteLine($"{hero.Name} waves the {Name} for {DamageAmount} damage!");
            
            villain.Damage(DamageAmount);
        }
    }
}
