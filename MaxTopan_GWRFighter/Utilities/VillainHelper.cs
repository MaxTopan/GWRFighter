﻿using MaxTopan_GWRFighter.Characters.Villains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Utilities
{
    internal class VillainHelper
    {
        private List<Type>? villains;
        /// <summary>
        /// Get all subclasses of Villain
        /// </summary>
        /// <returns>A list of all Villain subclasses</returns>
        public List<Type> GetAllVillains()
        {
            if (villains == null)
            {
                villains = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .Where(t => typeof(Villain).IsAssignableFrom(t) && t.IsClass && !t.IsAbstract)
                    .ToList();
            }
            return villains;
        }
    }
}
