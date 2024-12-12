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
        public Hero Hero { get; private set; }
        public Villain Villain { get; private set; }
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
            Hero.Attack(Villain);
            Villain.TakeTurn(Hero);
        }

        internal bool IsGameOver()
        {
            // shouldn't be possible with current villains, but worth having as an edge case
            if (Hero?.Health <= 0 && Villain?.Health <= 0)
            {
                DrawGame();
                return true;
            }
            else if (Hero?.Health <= 0)
            {
                LoseGame();
                return true;
            }
            else if (Villain?.Health <= 0)
            {
                WinGame();
                return true;
            }
            return false;
        }

        private void DrawGame()
        {
            Console.WriteLine("Well it's not great news.");
            Console.WriteLine($"{Hero.Name} and {Villain.Name} took each other out in a blaze of glory!");
            Console.WriteLine("Decide whether you consider this a victory.");

        }

        private void WinGame()
        {
            Console.WriteLine("Congratulations!!");
            Console.WriteLine($"{Hero.Name} slayed the {Villain.Name} with {Hero.Health} health left!");
            Console.ReadLine();
            CloseGame();
        }

        private void LoseGame()
        {
            Console.WriteLine("Tough luck!");
            Console.WriteLine($"{Hero.Name} was slain by the {Villain.Name} with {Villain.Health} damage left to go!");
            Console.ReadLine();
            CloseGame();
        }

        internal void ClearGame()
        {
            Hero = null;
            Villain = null;
            Console.Clear();
        }
    }
}
