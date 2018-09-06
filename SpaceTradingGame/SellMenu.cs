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
            int choice;
            do
            {
                choice = UserInterface.GetInput();
            } while (choice < 0 || choice > 8);

            if (choice == 0)
            {
                return "You have decided not to sell anything.";
            }
            if (choice == 8)
            {
                UserInterface.DisplayInventory(player,goodsQuantity);
                return null;
            }
                Console.WriteLine(
                    $"You currently have {goodsQuantity[choice]} pieces of {goods[choice].GetNameOfGood()}. How many would you like to sell? ");
                int quantity = UserInterface.GetInput();
            if(quantity==0)
            {
                return "You have selected not to sell anything.";
            }
                string message = goods[choice].SellGood(player, quantity, choice, goodsQuantity);
                return message;
        }
    }
}
