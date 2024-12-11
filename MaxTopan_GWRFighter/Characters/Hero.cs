﻿using MaxTopan_GWRFighter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MaxTopan_GWRFighter.Program;

namespace MaxTopan_GWRFighter.Characters
{
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
}