using MaxTopan_GWRFighter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Utilities
{
    public class WeaponHelper
    {
        private List<IWeapon>? weapons;
        public List<IWeapon> GetAllWeapons()
        {
            if (weapons == null)
            {
                weapons = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => typeof(IWeapon).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                    .Select(t => Activator.CreateInstance(t) as IWeapon)
                    .ToList();
            }
            return weapons;
        }
    }
}
