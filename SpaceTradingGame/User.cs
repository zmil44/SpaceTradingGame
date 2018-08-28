using System.Collections.Generic;

namespace SpaceTradingGame
{
    internal class User
    {
         readonly string name;
         int credits=25000;
         int timeInYears=0;
         int timeInDays=0;
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


        public int GetCredits()
        {
            return credits;
        }

        public void AddCredits(int credit)
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


    }
}
