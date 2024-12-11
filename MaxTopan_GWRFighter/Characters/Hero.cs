using MaxTopan_GWRFighter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MaxTopan_GWRFighter.Program;

namespace MaxTopan_GWRFighter.Characters
{
    public class Hero : ICharacter
    {
        public string Name { get; }
        public int Health { get; private set; } = 100;
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

        public void Attack(ICharacter villain)
        {
            if (EquippedWeapon == null)
            {
                Console.WriteLine("No weapon equipped!");
                return;
            }
            EquippedWeapon.Use(this, villain);
        }

        /// <summary>
        /// Add health to the Hero
        /// </summary>
        public void Heal(int value)
        {
            Health += value;
        }

        /// <summary>
        /// Remove health from the Hero
        /// </summary>
        public void Damage(int value)
        {
            Health -= value;
        }
    }
}
