﻿using MaxTopan_GWRFighter.Characters;
using MaxTopan_GWRFighter.Utilities;
using MaxTopan_GWRFighter.Utilities.Menus;

namespace MaxTopan_GWRFighter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            MenuManager menuManager = new MenuManager(gameManager);
            menuManager.RunMainMenu();
        }
    }
}