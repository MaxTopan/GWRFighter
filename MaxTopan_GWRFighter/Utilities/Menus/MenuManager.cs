using MaxTopan_GWRFighter.Models;

namespace MaxTopan_GWRFighter.Utilities.Menus
{
    /// <summary>
    /// Manages behaviour related to displaying and navigating menus and selecting choices
    /// </summary>
    internal class MenuManager
    {
        private readonly GameManager _gameManager;
        private List<Weapon> _weapons;

        public MenuManager(GameManager gameManager)
        {
            _gameManager = gameManager;
            _weapons = _gameManager.Weapons.OrderBy(x => x.Name).ToList();

        }

        /// <summary>
        /// Displays relevent information, opens a menu and awaits a choice to execute
        /// </summary>
        /// <param name="menu">The menu to be opened</param>
        public int RunMenu(Menu menu)
        {
            DisplayStats();
            _gameManager.IsGameOver();

            menu.DisplayChoices();
            return menu.GetChoice();
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
                new string[] { "Start Game", "Exit Game" }
            );
        }

        public void RunMainMenu()
        {
            Menu menu = MainMenu();
            int choice = RunMenu(menu);

            switch (choice)
            {
                case 1:
                    _gameManager.InitialiseGame();
                    RunGameplayMenu();
                    break;
                case 2:
                    _gameManager.CloseGame();
                    break;
                default:
                    throw new ArgumentException($"Invalid choice {choice} called");
            }
        }

        public Menu GameplayMenu()
        {
            return new Menu
            (
                "What will you do?",
                new string[] { "Attack", "Equip Weapon", "Exit Game" }
            );
        }

        public void RunGameplayMenu()
        {
            Menu menu = GameplayMenu();
            int choice = RunMenu(menu);

            switch (choice)
            {
                case 1:
                    _gameManager.TakeTurn();
                    RunGameplayMenu();
                    break;
                case 2:
                    RunEquipmentMenu();
                    break;
                case 3:
                    Console.WriteLine("Quitting to main menu.\r\nPress enter to continue...");
                    Console.ReadLine();
                    _gameManager.ClearGame();
                    RunMainMenu();
                    break;
                default:
                    throw new ArgumentException($"Invalid choice {choice} called");
            }
        }

        /// <summary>
        /// Dynamically generate Menu wih a list of all weapon names
        /// </summary>
        /// <returns>Menu with an option for each weapon</returns>
        public Menu EquipmentMenu()
        {
            string[] weaponNames = _weapons.OrderBy(w => w.Name).Select(w => w.Name).ToArray();

            return new Menu
            (
                "Which item would you like to equip?",
                weaponNames
            );
        }

        public void RunEquipmentMenu()
        {
            Menu menu = EquipmentMenu();
            int choice = RunMenu(menu);
            _gameManager.Hero.EquipWeapon(_weapons[choice - 1]);
            
            RunGameplayMenu();
        }
    }
}
