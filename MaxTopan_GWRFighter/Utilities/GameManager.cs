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

        internal void Attack()
        {
            hero.Attack(villain);
            villain.TakeTurn(hero);
        }
    }
}
