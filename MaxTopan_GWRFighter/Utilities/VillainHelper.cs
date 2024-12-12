using MaxTopan_GWRFighter.Characters.Villains;
using System.Reflection;

namespace MaxTopan_GWRFighter.Utilities
{
    internal class VillainHelper
    {
        private List<Type>? villains;
        /// <summary>
        /// Get all subclasses of Villain
        /// </summary>
        /// <returns>A list of all Villain subclasses</returns>
        public List<Type> GetAllVillainClasses()
        {
            // only go though the reflection the first time this runs
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
