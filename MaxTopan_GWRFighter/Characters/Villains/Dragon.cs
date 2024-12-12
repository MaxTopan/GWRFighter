namespace MaxTopan_GWRFighter.Characters.Villains
{
    internal class Dragon : Villain
    {
        public override string Name => "Dragon";
        public override string Description => "Fast and strong but fragile. Can dodge attacks.";
        public override int Health { get; protected set; } = 20;
        public override int AttackPower { get; protected set; } = 20;

        // chance for Dragon to take no damage
        private readonly double _dodgePercentage = 0.35;

        public override void Damage(int value)
        {
            Random r = new Random();
            if (r.NextDouble() < _dodgePercentage)
            {
                Console.WriteLine($"The {Name} dodged and took no damage!");
                return;
            }
            base.Damage(value);
        }
    }
}
