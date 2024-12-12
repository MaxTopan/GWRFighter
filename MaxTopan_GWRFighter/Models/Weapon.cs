using MaxTopan_GWRFighter.Characters;

namespace MaxTopan_GWRFighter.Models
{
    public abstract class Weapon
    {
        public abstract string Name { get; }
        public abstract int DamageAmount { get; }
        public abstract void Use(Character hero, Character villain);
    }
}
