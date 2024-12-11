using MaxTopan_GWRFighter.Characters;
using MaxTopan_GWRFighter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTopan_GWRFighter.Utilities.Menus
{
    internal class MenuFactory
    {
        private readonly GameManager _gameManager;

        public MenuFactory(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public Menu MainMenu()
        {
            return new Menu
            (
                @"======================
WELCOME TO GWR FIGHTER
======================",
                new string[] { "Start Game", "Exit Game" },
                new Dictionary<int, Action>
                {
                    { 1, () => { _gameManager.InitialiseGame(); _gameManager.OpenSubMenu(GameplayMenu()); } },
                    { 2, () => _gameManager.CloseGame() }
                }
            );
        }

        public Menu GameplayMenu()
        {
            return new Menu
            (
                "What will you do?",
                new string[] { "Attack", "Equip Weapon", "Exit Game" },
                new Dictionary<int, Action>
                {
                    { 1, () => _gameManager.Attack() },
                    { 2, () => _gameManager.EquipWeapon() },
                    { 3, () => { Console.WriteLine("Quitting to main menu.\r\nPress enter to continue..."); Console.ReadLine(); _gameManager.CloseGame(); } }
                }
            );
        }

        /// <summary>
        /// Dynamically generates a list of all weapons, allowing the user to select and equip one
        /// </summary>
        /// <returns></returns>
        public Menu EquipmentMenu()
        {
            List<IWeapon> weapons = _gameManager.Weapons;

            string[] weaponNames = weapons.Select(w => w.Name).ToArray();
            Dictionary<int, Action> choices = new Dictionary<int, Action>();

            for (int i = 0; i < weapons.Count; i++)
            {
                choices.Add(i + 1, () => _gameManager.hero.EquipWeapon(weapons[i]));
            }

            return new Menu
            (
                "Which item would you like to equip?",
                weaponNames,
                choices
            );
        }
    }
}
