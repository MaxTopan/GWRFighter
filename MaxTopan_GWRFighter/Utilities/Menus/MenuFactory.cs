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

        public Menu CreateMainMenu()
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
                @"What will you do?",
                new string[] { "Attack", "Equip Weapon", "Check Weapon Details", "Exit Game" },
                new Dictionary<int, Action>
                {
                    { 1, () => _gameManager.Attack() },
                    { 2, () => _gameManager.EquipWeapon() },
                    { 3, () => _gameManager.CheckWeaponDetails()},
                    { 4, () => _gameManager.CloseGame() }
                }
            );
        }

        //public Menu CreateEquipMenu()
        //{
        //    // show a list of items to equip
        //}

        //public Menu CreateWeaponDetailsMenu()
        //{
        //    // show weapons + descriptions
        //}
    }
}
