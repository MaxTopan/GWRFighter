using MaxTopan_GWRFighter.Characters;

namespace MaxTopan_GWRFighter.Models
{
    public class Sword : IWeapon
    {
        public string Name => "Sword";
        public int DamageAmount => 10;

        public void Use(Character hero, Character villain)
        {
            /* MOVE THIS TO SOMETHING THAT OWNS DIALGOUE DUE TO SRP */
            Console.WriteLine($"{hero.Name} slashes with the {Name} for {DamageAmount} damage!");
            
            villain.Damage(DamageAmount);
        }
    }
}
