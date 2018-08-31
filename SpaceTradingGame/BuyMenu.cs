using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class BuyMenu
    {
        public void DisplayBuyMenu(User player, Goods[] goods)
        {
            
            Console.WriteLine(
                $"{player.GetCurrentPlanet().GetTraderName()} says \"Greetings {player.GetUserName()}. What goods would you like to buy from me?\" " +
                "\nEnter the corresponding number to decide: " +
                $"\n You currently have {player.GetCredits()} credits and have {player.GetMaxCargo()-player.GetCurrentCargo().Count} " +
                $"spaces of cargo available");
            for (int i = 1; i < goods.Length; i++)
            {
                Console.WriteLine($"{i}. {goods[i].GetNameOfGood()} \tPrice: {goods[i].GetPriceOfGood()}");
            }

            Console.WriteLine("8. Get Current Inventory\n0. Return to previous Menu");
        }

        internal string CheckBuy(User player, Goods[] goods)
        {
            int choice;
            do
            {
                choice = UserInterface.GetInput();
            } while (choice < 0 || choice > 8);
            
            if (choice == 8)
            {
                UserInterface.DisplayInventory(player, player.GetCurrentInventoryQuantities());
                return null;
            }

            if (choice == 0)
            {
                return "You have chosen not to buy anything.";
            }

            if (choice >= 1 || choice <= 7)
            {
               
                    
                    Console.WriteLine(
                        $"How many {goods[choice].GetNameOfGood()} would you like to buy? " +
                        $"(note each item will take up 1 cargo space");
                    int quantity = UserInterface.GetInput();
                    string message = goods[choice].BuyGood(player, quantity);
                    return message;
                
            }

            return "Invalid choice";
        }
    }
}
