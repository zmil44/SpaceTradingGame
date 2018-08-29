using System;
namespace SpaceTradingGame
{
    class Ship
    {
        public readonly string shipName;
        public readonly int shipCargoSpace;
        public readonly int shipMaxWarpSpeed;
        public readonly int shipCost;
        public readonly int maxFuelLevel;
        public double currentFuelLevel;

        public Ship(string name, int cargoSpace, int maxWarpSpeed, int cost,int maxFuel)
        {
            shipName = name;
            shipCargoSpace = cargoSpace;
            shipMaxWarpSpeed = maxWarpSpeed;
            shipCost = cost;
            maxFuelLevel = maxFuel;
            currentFuelLevel = maxFuel;
        }

        public string GetShipName()
        {
            return shipName;
        }

        public int GetCargoSpace()
        {
            return shipCargoSpace;
        }

        public int GetMaxWarpSpeed()
        {
            return shipMaxWarpSpeed;
        }

        public int GetShipCost()
        {
            return shipCost;
        }

        public int GetMaxFuel()
        {
            return maxFuelLevel;
        }

        public void SetCurrentFuel(double fuel)
        {
            currentFuelLevel += fuel;
        }

        public double GetCurrentFuelLevel()
        {
            return currentFuelLevel;
        }

        public void RefuelShip(User player, Ship currentShip)
        {
            decimal refuelCost = Convert.ToDecimal((100 * (currentShip.maxFuelLevel - currentShip.currentFuelLevel)));
            if (player.GetCredits() - refuelCost < 0)
            {
                Console.WriteLine("You do not have enough credits to refuel your ship");
            }
            else
            {
                Console.WriteLine($"You have refueled your ship for {refuelCost} credits");
                player.AddCredits(-refuelCost);
                currentShip.currentFuelLevel = currentShip.maxFuelLevel;
            }

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }

    }
}
