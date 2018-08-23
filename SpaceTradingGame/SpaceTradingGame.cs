using System;


namespace SpaceTradingGame
{
    class SpaceTradingGame
    {
        static void Main(string[] args)
        {
            Console.WindowHeight=Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.ForegroundColor = ConsoleColor.Green;
            UserInterface playerInterface = new UserInterface();
            playerInterface.RunUserInterface();
        }
    }
}
