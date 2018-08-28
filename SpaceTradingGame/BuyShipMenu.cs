using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class BuyShipMenu
    {
        public void DisplayBuyShipMenu(User player, Ship[] ships, Ship currentShip)
        {
            Console.WriteLine($"Welcome, {player.GetUserName()} to Joe's Spaceship Dealership. Here you are able to purchase a new ship " +
                $"while selling your current one." +
                $"\nYou currently have {player.GetCredits()} credits and the ship you currently own is {currentShip.GetShipName()}" +
                $"\n Ships we currently have in stock are as follows: ");
            for (int i = 1; i < ships.Length; i++)
            {
                Console.WriteLine(
                    $"{i}. {ships[i].GetShipName()}\t\t\tPrice: {ships[i].GetShipCost()} credits\t Cargo Space: " +
                    $"{ships[i].GetCargoSpace()}\tMax warp speed: {ships[i].GetMaxWarpSpeed()}\t\t Max Fuel: " +
                    $"{ships[i].GetMaxFuel()}");
            }

            Console.WriteLine("0. Return to previous screen");
        }
    }
}
