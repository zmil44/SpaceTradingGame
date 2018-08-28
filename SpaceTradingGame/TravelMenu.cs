using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class TravelMenu
    {
        public void DisplayTravelMenu(User player, Planet[] planets)
        {
            Console.WriteLine($"You are currently on {player.GetCurrentLocation()}");
        }
    }
}
