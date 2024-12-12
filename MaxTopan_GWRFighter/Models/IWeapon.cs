using MaxTopan_GWRFighter.Characters;

namespace MaxTopan_GWRFighter.Models
{
    public interface IWeapon
    {
        string Name { get; }
        int DamageAmount { get; }
        void Use(Character hero, Character villain);
    }
}
