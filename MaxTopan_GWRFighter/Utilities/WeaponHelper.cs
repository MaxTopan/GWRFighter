using MaxTopan_GWRFighter.Models;
using System.Reflection;

namespace MaxTopan_GWRFighter.Utilities
{
    public class WeaponHelper
    {
        private List<Weapon>? weapons;
        /// <summary>
        /// Gets all subclasses of IWeapon, instantiates an instance of each, and stores them in a list
        /// </summary>
        /// <returns>The list of weapon instances</returns>
        public List<Weapon> InstantiateAllWeapons()
        {
            // only go through the reflection the first time this runs
            if (weapons == null)
            {
                weapons = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => typeof(Weapon).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                    .Select(t => Activator.CreateInstance(t) as Weapon)
                    .ToList()!;
            }
            return weapons;
        }
    }
}
