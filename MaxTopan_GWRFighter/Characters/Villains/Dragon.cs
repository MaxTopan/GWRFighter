namespace MaxTopan_GWRFighter.Characters.Villains
{
    internal class Dragon : Villain
    {
        public override string Name => "Dragon";
        public override string Description => "Fast and strong but fragile. Can dodge attacks.";
        public override int Health { get; protected set; } = 20;
        public override int AttackPower { get; protected set; } = 20;

        private double dodgePercentage = 0.35;

        public override void Damage(int value)
        {
            Random r = new Random();
            if (r.NextDouble() < dodgePercentage)
            {
                Console.WriteLine($"{Name} dodged!");
                return;
            }
            base.Damage(value);
        }
    }
}
