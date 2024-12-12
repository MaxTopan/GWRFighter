using MaxTopan_GWRFighter.Characters;

namespace MaxTopan_GWRFighter.Models
{
    public class Sword : Weapon
    {
        public override string Name => "Sword";
        public override int DamageAmount => 10;

        public override void Use(Character hero, Character villain)
        {
            Console.WriteLine($"{hero.Name} slashes with the {Name} for {DamageAmount} damage!");
            villain.Damage(DamageAmount);
        }
    }
}
