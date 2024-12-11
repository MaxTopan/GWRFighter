using MaxTopan_GWRFighter.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Services
{
    internal class GameService
    {
        /// <summary>
        /// Gets a name from the user and creates a hero with that name
        /// </summary>
        /// <returns>A Hero object with the given name</returns>
        public Hero CreateHero()
        {
            string? name = null;
            while (String.IsNullOrWhiteSpace(name) || String.IsNullOrEmpty(name))
            {
                Console.Write("Please enter a name for your hero: ");
                name = Console.ReadLine();
            }

            return new Hero(name);
        }

        /// <summary>
        /// Gets and validates an int from the user
        /// </summary>
        /// <param name="maxChoice">The highest int in the choice range, inclusive</param>
        /// <returns>The validated chosen int</returns>
        public int GetChoice(int maxChoice)
        {
            int choice;
            do
            {
                Console.Write($"Please choose (1 - {maxChoice}): ");
            } while (int.TryParse(Console.ReadLine(), out choice) && 1 > choice || choice > maxChoice);
            
            return choice;
        }
    }
}
