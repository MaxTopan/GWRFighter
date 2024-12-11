using MaxTopan_GWRFighter.Characters;
using MaxTopan_GWRFighter.Utilities;
using MaxTopan_GWRFighter.Utilities.Menus;

namespace MaxTopan_GWRFighter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            MenuFactory menuFactory = new MenuFactory(gameManager);

            Menu mainMenu = menuFactory.MainMenu();

            mainMenu.Use();

            Hero hero = gameManager.CreateHero();

            Console.ReadLine();
        }
    }
}