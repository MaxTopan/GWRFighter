using MaxTopan_GWRFighter.Characters;

namespace MaxTopan_GWRFighter.Models
{
    /// <summary>
    /// Base class with a shared implementation of ChanceTrigger() for weapons that utilise random chance
    /// </summary>
    public abstract class RandomChanceWeapon : IWeapon, IRandomChance
    {
        public abstract string Name { get; }
        public abstract int DamageAmount { get; }
        /// <summary>
        /// Percentage chance for ChanceTrigger() to trigger (0.01 - 0.99)
        /// </summary>
        public abstract double Percentage { get; }
        public abstract void Use(Character hero, Character villain);
        public bool ChanceTrigger()
        {
            Random r = new Random();
            return r.NextDouble() < Percentage;
        }
    }
}
