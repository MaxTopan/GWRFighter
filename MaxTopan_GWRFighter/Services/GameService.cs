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

        public int GetMenuChoice(int maxChoice)
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
