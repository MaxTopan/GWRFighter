using MaxTopan_GWRFighter.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public abstract void Use(ICharacter hero, ICharacter villain);
        public bool ChanceTrigger()
        {
            Random r = new Random();
            return r.NextDouble() < Percentage;
        }
    }
}
