﻿using MaxTopan_GWRFighter.Characters;
using MaxTopan_GWRFighter.Characters.Villains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Utilities.Menus
{
    /// <summary>
    /// Contains methods for UI displays
    /// </summary>
    public class MenuService
    {
        public void DisplayHeroStats(Hero hero)
        {
            Console.WriteLine($"{hero.Name} [Health: {hero.Health}, Equipped: {(hero.EquippedWeapon == null ? "Nothing" : hero.EquippedWeapon.Name)}]");
        }

        public void DisplayVillainStats(Villain villain)
        {
            Console.WriteLine($"{villain.Name} [Health: {villain.Health}, Attack Power: {villain.AttackPower}]\r\nDescription: {villain.Description}");
        }
    }
}
