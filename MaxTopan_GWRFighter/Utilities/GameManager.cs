using MaxTopan_GWRFighter.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Utilities
{
    /// <summary>
    /// Contains methods for the running of the game logic
    /// </summary>
    internal class GameManager
    {
        public Hero hero;
        public Villain villain;

        /// <summary>
        /// Opens a menu and awaits a choice to execute
        /// </summary>
        /// <param name="subMenu">The menu to be opened</param>
        public void OpenSubMenu(Menu subMenu)
        {
            subMenu.DisplayChoices();
            int choice = subMenu.GetChoice();
            subMenu.InvokeResult(choice);
        }

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

        public Villain CreateVillain()
        {
            throw new NotImplementedException();
        }

        internal void InitialiseGame()
        {
            CreateHero();
            CreateVillain();
        }

        internal void Options()
        {
            // TODO: implement persistant text vs clean text
            throw new NotImplementedException();
        }

        internal void CloseGame()
        {
            Console.WriteLine("Exiting Application. Press Enter to close...");
            Console.ReadLine();
            Environment.Exit(0);
        }

        internal void Attack()
        {
            throw new NotImplementedException();
        }

        internal void EquipWeapon()
        {
            throw new NotImplementedException();
        }

        internal void CheckWeaponDetails()
        {
            throw new NotImplementedException();
        }
    }
}
