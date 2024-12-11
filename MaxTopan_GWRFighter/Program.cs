using MaxTopan_GWRFighter.Characters;
using MaxTopan_GWRFighter.Services;

namespace MaxTopan_GWRFighter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameService gs = new GameService();

            Console.WriteLine(
                @"========================================
WELCOME TO GUINNESS WORLD RECORD FIGHTER
========================================
");
            
            Hero hero = gs.CreateHero();
            
            Console.WriteLine($"Okay, {hero.Name}. What do you want to do?");

            Console.ReadLine();
        }
    }
}