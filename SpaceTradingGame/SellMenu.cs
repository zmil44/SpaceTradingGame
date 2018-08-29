using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class SellMenu
    {
        public void DisplaySellMenu(User player, Goods[] goods)
        {


            Console.WriteLine(
                $"{player.GetCurrentPlanet().GetTraderName()} says  \"Greetings, {player.GetUserName()}. What goods would you like to sell to me?\" " +
                "\nEnter the corresponding number to decide: ");
            for (int i = 1; i < goods.Length; i++)
            {
                Console.WriteLine($"{i}. {goods[i].GetNameOfGood()} \tPrice: {goods[i].GetPriceOfGood()}");
            }

            Console.WriteLine("8. Get Current Inventory\n0. Return to previous Menu");
        }

        internal static string CheckSell(User player, Goods[] goods, int[] goodsQuantity)
        {
            int choice = UserInterface.GetInput();
            if (choice == 0)
            {
                return null;
            }
            else if (choice == 8)
            {
                UserInterface.DisplayInventory(player,goodsQuantity);
                return null;
            }
            else
            {
                Console.WriteLine(
                    $"You currently have {goodsQuantity[choice - 1]} peices of {goods[i].GetNameOfGood()}. How many would you like to sell? ");
                int quantity = UserInterface.GetInput();
                string message = goods[choice-1].SellGood(player, quantity, choice, goodsQuantity);
                return message;
            }
        }
    }
}
