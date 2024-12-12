namespace MaxTopan_GWRFighter.Characters.Villains
{
    /// <summary>
    /// Villain that gains Health and AttackPower each turn
    /// </summary>
    internal class Nilbog : Villain
    {
        public override string Name => "Nilbog";
        public override string Description => "What is that? It's getting stronger.";
        public override int Health { get; protected set; } = 20;
        public override int AttackPower { get; protected set; } = 5;
        private readonly int _attackGrowthRate = 5;
        private readonly int _healthGrowthRate = 7;

        public override void TakeTurn(Character hero)
        {
            Attack(hero);
            Heal(_healthGrowthRate);
            AttackPower += _attackGrowthRate;

            Console.WriteLine($"{Name} recovered {_healthGrowthRate} health.");
            Console.WriteLine($"{Name} gained {_attackGrowthRate} attack.");
        }
    }
}
