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

        public string BuyGood(User player, int quantity)
        {
            int totalPrice = priceOfGood * quantity;
            if (player.GetCredits() >= totalPrice && quantity <= player.GetMaxCargo()-player.GetCurrentCargo().Count)
            {
                for (int i = 0; i < quantity; i++)
                {
                    player.AddCargo(nameOfGood);
                }

                player.AddCredits(-(totalPrice));
                return "Purchase Successful. Press enter to continue.";
            }

            if (player.GetCredits() < totalPrice)
            {
                return "You did not have enough credits to complete your purchase. Press enter to continue.";
            }

            return "You do not have enough cargo space to complete your purchase. Press enter to continue";
            
        }

        public string SellGood(User player, int quantity, int choice,int[] currentInventory)
        {
            
            if (currentInventory[choice-1] >= quantity)
            {
                var totalPrice = priceOfGood * quantity;
                for (var i = 0; i < quantity; i++)
                {
                    player.RemoveCargo(nameOfGood);
                }

                player.AddCredits(totalPrice);
                return ("Sale Successful. Press enter to continue");
            }
                return $"You did not have enough {nameOfGood} to sell that many. Press enter to continue.";
            
        }

    }
}
