using System;
namespace SpaceTradingGame
{
    class Goods
    {
        readonly string nameOfGood;
        int priceOfGood;

        public Goods(string name, int price)
        {
            nameOfGood = name;
            priceOfGood = price;
        }

        public string GetNameOfGood()
        {
            return nameOfGood;
        }

        public int GetPriceOfGood()
        {
            return priceOfGood;
        }

        public void SetPriceOfGood(int price)
        {
            priceOfGood = price;
        }

        public void BuyGood(User player, int quantity)
        {
            int totalPrice = priceOfGood * quantity;
            if (player.GetCredits() >= totalPrice && quantity <= player.GetMaxCargo()-player.GetCurrentCargo().Count)
            {
                for (int i = 0; i < quantity; i++)
                {
                    player.AddCargo(nameOfGood);
                }

                player.AddCredits(-(totalPrice));
                Console.WriteLine("Purchase Successful");
                Console.Read();
            }
            else if(player.GetCredits()<totalPrice)
            {
                Console.WriteLine("You did not have enough credits to complete your purchase. Press enter 0 to continue.");
                Console.Read();
            }
            else
            {
                Console.WriteLine(
                    "You do not have enough cargo space to complete your purchase. Press enter 0 to continue");
                Console.Read();
            }
        }

        public void SellGood(User player, int quantity, int choice,int[] currentInventory)
        {
            int totalPrice = priceOfGood * quantity;
            if (currentInventory[choice] <= quantity)
            {
                for (int i = 0; i < quantity; i++)
                {
                    player.RemoveCargo(nameOfGood);
                }

                player.AddCredits(totalPrice);
                Console.WriteLine("Sale Successful. Press enter to continue");
                Console.Read();
            }
            else
            {
                Console.WriteLine($"You did not have enough {nameOfGood} to sell that many. Press enter 0 to continue.");
                Console.Read();
            }
        }

    }
}
