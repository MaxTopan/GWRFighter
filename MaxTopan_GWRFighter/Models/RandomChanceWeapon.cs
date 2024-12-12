using MaxTopan_GWRFighter.Characters;
using MaxTopan_GWRFighter.Utilities;

namespace MaxTopan_GWRFighter.Models
{
    /// <summary>
    /// Base class with a shared implementation of ChanceTrigger() for weapons that utilise random chance
    /// </summary>
    public abstract class RandomChanceWeapon : Weapon, IRandomChance
    {
        public abstract double Percentage { get; }
        public bool ChanceTrigger()
        {
            Random r = new Random();
            return r.NextDouble() < Percentage;
        }
    }
}
