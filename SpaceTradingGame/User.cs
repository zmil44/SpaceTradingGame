using System.Collections.Generic;

namespace SpaceTradingGame
{
    internal class User
    {
         readonly string name;
         decimal credits=25000;
         public int timeInYears=0;
         public int timeInDays=0;
         string currentLocation = "Earth";
         readonly List<string> cargo = new List<string>();
         int maxCargoSpace = 50;
         Planet currentPlanet;

        public void SetCurrentPlanet(Planet current)
        {
            currentPlanet = current;
        }

        public Planet GetCurrentPlanet()
        {
            return currentPlanet;
        }
        public void CalculateYears()
        {
            if (timeInDays > 365)
            {
                int years = timeInDays/365;
                timeInYears += years;
                timeInDays -= 365*years;
            }
        }

        public User(string userName)
        {
            name = userName;

        }

        public string GetUserName()
        {
            return name;
        }


        public decimal GetCredits()
        {
            return credits;
        }

        public void AddCredits(decimal credit)
        {
            credits += credit;
        }

        public int GetUserDays()
        {
            return timeInDays;
        }

        public void SetUserTime(int userTime)
        {
            timeInDays += userTime;
        }

        public int GetUserTimeInYears()
        {
            return timeInYears;
        }

        public int GetMaxCargo()
        {
            return maxCargoSpace;
        }

        public void SetMaxCargo(int maxCargo)
        {
            maxCargoSpace = maxCargo;
        }

        public string GetCurrentLocation()
        {
            return currentLocation;
        }

        public void SetCurrentLocation(string planet)
        {
            currentLocation = planet;
        }
        public List<string> GetCurrentCargo()
        {
            return cargo;
        }

        public void AddCargo(string good)
        {
                cargo.Add(good);
        }

        public void RemoveCargo(string good)
        {
            cargo.Remove(good);
        }

        public int[] GetCurrentInventoryQuantities()
        {
            int[] goodsQuantity = new int[7];
            for (var i = 0; i < cargo.Count; i++)
            {
                switch (cargo[i])
                {
                    case "Gold":
                        goodsQuantity[0] += 1;
                        break;
                    case "Diamond":
                        goodsQuantity[1] += 1;
                        break;
                    case "Uranium":
                        goodsQuantity[2] += 1;
                        break;
                    case "Oil":
                        goodsQuantity[3] += 1;
                        break;
                    case "Wood":
                        goodsQuantity[4] += 1;
                        break;
                    case "Copper":
                        goodsQuantity[5] += 1;
                        break;
                    case "Dark Matter":
                        goodsQuantity[6] += 1;
                        break;
                }
            }

            return goodsQuantity;
        }


    }
}
