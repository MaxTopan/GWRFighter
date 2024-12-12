using MaxTopan_GWRFighter.Characters.Villains;
using MaxTopan_GWRFighter.Characters;
using MaxTopan_GWRFighter.Models;
using System.Linq;

namespace MaxTopan_GWRFighter.Utilities.Menus
{
    /// <summary>
    /// Manages behaviour related to displaying and navigating menus and selecting choices
    /// </summary>
    internal class MenuManager
    {
        private readonly GameManager _gameManager;

        public MenuManager(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        /// <summary>
        /// Displays relevent information, opens a menu and awaits a choice to execute
        /// </summary>
        /// <param name="menu">The menu to be opened</param>
        public void OpenMenu(Menu menu)
        {
            DisplayStats();
            _gameManager.IsGameOver();

            menu.DisplayChoices();
            int choice = menu.GetChoice();
            menu.InvokeResult(choice);
        }

        public void DisplayStats()
        {
            if (_gameManager.Hero != null && _gameManager.Villain != null)
            {
                Console.WriteLine();
                Console.WriteLine("==============================================================================");
                _gameManager.Hero.DisplayStats();
                Console.WriteLine();
                _gameManager.Villain.DisplayStats();
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
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
                    { 1, () =>
                        {
                            _gameManager.InitialiseGame();
                            OpenMenu(GameplayMenu());
                        }
                    },
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
                    { 1, () =>
                        {
                            _gameManager.TakeTurn();
                            OpenMenu(GameplayMenu());
                        }
                    },
                    { 2, () => OpenMenu(EquipmentMenu()) },
                    { 3, () =>
                        {
                            Console.WriteLine("Quitting to main menu.\r\nPress enter to continue...");
                            Console.ReadLine();
                            _gameManager.ClearGame();
                            OpenMenu(MainMenu());
                        }
                    }
                }
            );
        }

        /// <summary>
        /// Dynamically generate a list of all weapons
        /// </summary>
        /// <returns>Menu with an option to equip each weapon</returns>
        public Menu EquipmentMenu()
        {
            // TODO: Move this out of menumanager - not SOLID?
            List<IWeapon> weapons = _gameManager.Weapons;
            
            string[] weaponNames = weapons.OrderBy(w => w.Name).Select(w => w.Name).ToArray();
            Dictionary<int, Action> weaponChoices = weapons
                .Select((weapon, index) => new
                {
                    Key = index + 1,
                    Action = (Action)(() =>
                    {
                        _gameManager.Hero.EquipWeapon(weapon);
                        OpenMenu(GameplayMenu());
                    })
                })
                .ToDictionary(x => x.Key, x => x.Action);


            return new Menu
            (
                "Which item would you like to equip?",
                weaponNames,
                weaponChoices
            );
        }
    }
}
