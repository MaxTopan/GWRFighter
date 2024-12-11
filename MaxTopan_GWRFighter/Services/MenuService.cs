using MaxTopan_GWRFighter.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Services
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
            Console.WriteLine($"{villain.Name} [Health: {villain.Health}, Attack Power: {villain.AttackPower}]");
        }
    }
}
