using MaxTopan_GWRFighter.Characters;
using MaxTopan_GWRFighter.Characters.Villains;
using MaxTopan_GWRFighter.Models;
using MaxTopan_GWRFighter.Utilities.Menus;

namespace MaxTopan_GWRFighter.Utilities
{
    /// <summary>
    /// Contains methods for the running of the game logic
    /// </summary>
    internal class GameManager
    {
        public Hero hero { get; private set; }
        public Villain villain { get; private set; }
        public List<IWeapon> Weapons { get; private set; }
        public List<Type> Villains { get; private set; }

        public GameManager()
        {
            WeaponHelper weaponHelper = new WeaponHelper();
            Weapons = weaponHelper.InstantiateAllWeapons();

            VillainHelper villainHelper = new VillainHelper();
            Villains = villainHelper.GetAllVillains();
        }

        /// <summary>
        /// Opens a menu and awaits a choice to execute
        /// </summary>
        /// <param name="menu">The menu to be opened</param>
        public void OpenMenu(Menu menu)
        {
            DisplayStats();
            IsGameOver();
            
            menu.DisplayChoices();
            int choice = menu.GetChoice();
            menu.InvokeResult(choice);
        }

        public void DisplayStats()
        {
            if (hero != null && villain != null)
            {
                Console.WriteLine();
                hero.DisplayStats();
                villain.DisplayStats();
                Console.WriteLine();
            }
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
            hero = new Hero(name);
            return hero;
        }

        /// <summary>
        /// Create an instance of a random Villain
        /// </summary>
        /// <returns>The created Villain</returns>
        public Villain CreateVillain()
        {
            Random r = new Random();
            int index = r.Next(0, Villains.Count);
            villain = (Villain)Activator.CreateInstance(Villains[index])!;
            return villain;
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

        internal void EquipWeapon()
        {
            throw new NotImplementedException();
        }

        internal void TakeTurn()
        {
            hero.Attack(villain);
            villain.TakeTurn(hero);
        }

        internal bool IsGameOver()
        {
            // shouldn't be possible with current villains, but worth having as an edge case
            if (hero?.Health <= 0 && villain?.Health <= 0)
            {
                DrawGame();
                return true;
            }
            else if (hero?.Health <= 0)
            {
                LoseGame();
                return true;
            }
            else if (villain?.Health <= 0)
            {
                WinGame();
                return true;
            }
            return false;
        }

        private void DrawGame()
        {
            Console.WriteLine("Well it's not great news.");
            Console.WriteLine($"{hero.Name} and {villain.Name} took each other out in a blaze of glory!");
            Console.WriteLine("Decide whether you consider this a victory.");

        }

        private void WinGame()
        {
            Console.WriteLine("Congratulations!!");
            Console.WriteLine($"{hero.Name} slayed the {villain.Name} with {hero.Health} health left!");
            Console.WriteLine("Press enter to close the game...");
            Console.ReadLine();
        }

        private void LoseGame()
        {
            Console.WriteLine("Tough luck!");
            Console.WriteLine($"{hero.Name} was slain by the {villain.Name} with {villain.Health} damage left to go!");
            Console.WriteLine("Press enter to close the game...");
            Console.ReadLine();
        }
    }
}
