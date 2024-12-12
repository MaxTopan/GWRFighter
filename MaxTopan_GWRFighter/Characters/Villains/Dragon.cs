using MaxTopan_GWRFighter.Utilities;

namespace MaxTopan_GWRFighter.Characters.Villains
{
    internal class Dragon : Villain, IRandomChance
    {
        public override string Name => "Dragon";
        public override string Description => "Fast and strong but fragile. Can dodge attacks.";
        public override int Health { get; protected set; } = 20;
        public override int AttackPower { get; protected set; } = 20;

        /// <summary>
        /// Percentage chance to dodge an attack
        /// </summary>
        public double Percentage => 0.33;

        public override void Damage(int value)
        {
            Random r = new Random();
            if (((IRandomChance)this).ChanceTrigger())
            {
                Console.WriteLine($"The {Name} dodged and took no damage!");
                return;
            }
            base.Damage(value);
        }
    }
}
