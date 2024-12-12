using MaxTopan_GWRFighter.Models;

namespace MaxTopan_GWRFighter.Characters
{
    public class Hero : Character
    {
        public override string Name { get; }
        public override int Health { get; protected set; } = 100;
        public IWeapon? EquippedWeapon { get; private set; }

        public Hero(string name)
        {
            Name = name;
            EquippedWeapon = null;
        }

        public void EquipWeapon(IWeapon weapon)
        {
            EquippedWeapon = weapon;
            Console.WriteLine($"{Name} equipped the {weapon.Name}.");
        }

        public override void Attack(Character villain)
        {
            if (EquippedWeapon == null)
            {
                Console.WriteLine("No weapon equipped!");
                return;
            }
            EquippedWeapon.Use(this, villain);
        }

        public override void DisplayStats()
        {
            Console.WriteLine($"{Name} [Health: {Health}, Weapon: {(EquippedWeapon == null ? "Nothing Equipped" : EquippedWeapon.Name)}]");
        }
    }
}
