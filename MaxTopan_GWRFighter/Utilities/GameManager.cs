using MaxTopan_GWRFighter.Characters;
using MaxTopan_GWRFighter.Characters.Villains;
using MaxTopan_GWRFighter.Models;
using MaxTopan_GWRFighter.Utilities.Menus;

namespace MaxTopan_GWRFighter.Utilities
{
    /// <summary>
    /// Manages behaviour for the running of the game logic
    /// </summary>
    internal class GameManager
    {
        /// <summary>
        /// The active instance of the player character
        /// </summary>
        public Hero Hero { get; private set; }

        /// <summary>
        /// The active instance of the current Villain
        /// </summary>
        public Villain Villain { get; private set; }

        /// <summary>
        /// List of instances of the games Weapons
        /// </summary>
        public List<IWeapon> Weapons { get; private set; }

        /// <summary>
        /// List of the classes of Villain
        /// </summary>
        public List<Type> Villains { get; private set; }

        public GameManager()
        {
            WeaponHelper weaponHelper = new WeaponHelper();
            Weapons = weaponHelper.InstantiateAllWeapons();

            VillainHelper villainHelper = new VillainHelper();
            Villains = villainHelper.GetAllVillainClasses();
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
            Hero = new Hero(name);
            return Hero;
        }

        /// <summary>
        /// Create an instance of a random Villain
        /// </summary>
        /// <returns>The created Villain</returns>
        public Villain CreateVillain()
        {
            Random r = new Random();
            int index = r.Next(0, Villains.Count);
            Villain = (Villain)Activator.CreateInstance(Villains[index])!;
            return Villain;
        }

        /// <summary>
        /// Set up the Hero and Villain instances for this game
        /// </summary>
        internal void InitialiseGame()
        {
            CreateHero();
            CreateVillain();
        }

        /// <summary>
        /// Remove the active Hero and Villain instances, and clear the display
        /// </summary>
        internal void ClearGame()
        {
            Hero = null;
            Villain = null;
            Console.Clear();
        }

        /// <summary>
        /// Close the application
        /// </summary>
        internal void CloseGame()
        {
            Console.WriteLine("Exiting Application. Press Enter to close...");
            Console.ReadLine();
            Environment.Exit(0);
        }

        /// <summary>
        /// Make the hero attack, then make the current Villain take its turn
        /// </summary>
        internal void TakeTurn()
        {
            Hero.Attack(Villain);
            Villain.TakeTurn(Hero);
        }

        /// <summary>
        /// Check whether either Character has hit 0 Health
        /// </summary>
        /// <returns></returns>
        internal void IsGameOver()
        {
            if (Hero?.Health <= 0 && Villain?.Health <= 0)
            {
                DrawGame();
            }
            else if (Hero?.Health <= 0)
            {
                LoseGame();
            }
            else if (Villain?.Health <= 0)
            {
                WinGame();
            }
        }

        /// <summary>
        /// Display draw message, and close the game
        /// </summary>
        private void DrawGame()
        {
            Console.WriteLine("Well it's not great news.");
            Console.WriteLine($"{Hero.Name} and {Villain.Name} took each other out in a blaze of glory!");
            Console.WriteLine("Decide whether you consider this a victory.");
            Console.ReadLine();
            CloseGame();
        }

        /// <summary>
        /// Display win message, and close the game
        /// </summary>
        private void WinGame()
        {
            Console.WriteLine("Congratulations!!");
            Console.WriteLine($"{Hero.Name} slayed the {Villain.Name} with {Hero.Health} health left!");
            Console.ReadLine();
            CloseGame();
        }

        /// <summary>
        /// Display lose message, and close the game
        /// </summary>
        private void LoseGame()
        {
            Console.WriteLine("Tough luck!");
            Console.WriteLine($"{Hero.Name} was slain by the {Villain.Name} with {Villain.Health} damage left to go!");
            Console.ReadLine();
            CloseGame();
        }
    }
}
