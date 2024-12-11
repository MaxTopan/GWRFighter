namespace MaxTopan_GWRFighter
{
    internal class Program
    {
        public interface IWeapon
        {
            string Name { get; }
            int Damage { get; }
            void Use(Hero hero, Villain villain);

        }
        public class Sword : IWeapon
        {
            public string Name => "Sword";
            public int Damage => 10;
            public void Use(Hero hero, Villain villain)
            {
                villain.Health -= Damage;
                Console.WriteLine($"{hero.Name} slashes with the {Name} for {Damage} damage!");
            }
        }
        public class Bow : IWeapon
        {
            public string Name => "Bow";
            public int Damage => 5;
            public void Use(Hero hero, Villain villain)
            {
                villain.Health -= Damage;
                Console.WriteLine($"{hero.Name} slashes with the {Name} for {Damage} damage!");
            }
        }
        // Add more weapons: Bow, MagicWand, etc.
        public class Hero
        {
            public string Name { get; set; }
            public int Health { get; set; } = 100;
            private IWeapon EquippedWeapon { get; set; }
            public Hero(string name)
            {
                Name = name;
            }
            public void EquipWeapon(IWeapon weapon)
            {
                EquippedWeapon = weapon;
                Console.WriteLine($"{Name} equipped the {weapon.Name}.");
            }
            public void Attack(Villain villain)
            {
                if (EquippedWeapon == null)
                {
                    Console.WriteLine("No weapon equipped!");
                    return;
                }
                EquippedWeapon.Use(this, villain);
            }
        }
        public class Villain
        {
            public string Name { get; set; }
            public int Health { get; set; } = 50;
            public int AttackPower { get; set; } = 10;
            public Villain(string name)
            {
                Name = name;
            }
            public void Attack(Hero hero)
            {
                hero.Health -= AttackPower;
                Console.WriteLine($"{Name} attacks {hero.Name} for {AttackPower} damage!");
            }
        }

        static void Main(string[] args)
        {
        }
    }
}