using System;


namespace SpaceTradingGame
{
    class SpaceTradingGame
    {
        private static void Main(string[] args)
        {
            Console.WindowHeight=Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.ForegroundColor = ConsoleColor.Red;
            var playerInterface = new UserInterface();
        }
    }
}
