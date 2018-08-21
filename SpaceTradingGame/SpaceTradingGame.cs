using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class SpaceTradingGame
    {
        static void Main(string[] args)
        {
            Console.WindowHeight=Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;
            UserInterface playerInterface = new UserInterface();
            playerInterface.RunUserInterface();
        }
    }
}
