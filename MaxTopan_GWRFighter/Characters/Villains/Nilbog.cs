namespace MaxTopan_GWRFighter.Characters.Villains
{
    internal class Nilbog : Villain
    {
        public override string Name => "Nilbog";
        public override string Description => "What is that? It's getting stronger.";
        public override int Health { get; protected set; } = 20;
        public override int AttackPower { get; protected set; } = 5;
        private int _attackGrowthRate = 5;
        private int _healthGrowthRate = 7;

        public override void TakeTurn(Character hero)
        {
            Attack(hero);
            Heal(_healthGrowthRate);
            AttackPower += _attackGrowthRate;

            /* TODO: MOVE TO SOMETHING THAT OWNS DIALOGUE */
            Console.WriteLine($"{Name} recovered {_healthGrowthRate} health.");
            Console.WriteLine($"{Name} gained {_attackGrowthRate} attack.");
        }
    }
}
