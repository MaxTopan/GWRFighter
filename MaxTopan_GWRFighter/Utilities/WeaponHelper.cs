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
        public static List<Type> GetAllWeapons()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(IWeapon).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                .ToList();
        }
    }
}
