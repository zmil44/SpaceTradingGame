using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class SellMenu
    {
        public void DisplaySellMenu(User player, Goods[] goods, Planet currentPlanet)
        {


            Console.WriteLine(
                $"{currentPlanet.GetTraderName()} says  \"Greetings, {player.GetUserName()}. What goods would you like to sell to me?\" " +
                "\nEnter the corresponding number to decide: ");
            for (int i = 1; i <= goods.Length; i++)
            {
                Console.WriteLine($"{i}. {goods[i].GetNameOfGood()} \tPrice: {goods[i].GetPriceOfGood()}");
            }

            Console.WriteLine("8. Get Current Inventory\n0. Return to previous Menu");
        }
    }
}
