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

        public static void BuyShipSuccessful(User player, Ship currentShip, Ship[] ships, int choice)
        {
            player.AddCredits(currentShip.GetShipCost());
            player.AddCredits(-ships[choice].GetShipCost());
            currentShip = ships[choice];
            player.SetMaxCargo(currentShip.GetCargoSpace());
        }

        internal static string TryBuyShip(User player, Ship currentShip, Ship[] ships)
        {
            int choice;
            do
            {
                choice = UserInterface.GetInput();
            } while (choice < 0 || choice > 5);
            if (choice == 0)
            {
                return "You have decided not to buy a ship. Press enter to continue";
            }
            if (player.GetCredits() + currentShip.GetShipCost() >= ships[choice].GetShipCost())
            {
                BuyShipSuccessful(player, currentShip, ships, choice);
                return "You successfully purchased a new ship.";
            }
                return "You do not have enough credits to buy that ship. Press enter to continue";
        }
    }
}
