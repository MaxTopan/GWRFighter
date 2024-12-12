namespace MaxTopan_GWRFighter.Characters.Villains
{
    /// <summary>
    /// Villain with no special features
    /// </summary>
    internal class Goblin : Villain
    {
        public override string Name => "Goblin";
        public override string Description => "Basic enemy. Small and weak, not very strong, not very smart.";

        public override int Health { get; protected set; } = 30;

        public override int AttackPower { get; protected set; } = 5;
    }
}
