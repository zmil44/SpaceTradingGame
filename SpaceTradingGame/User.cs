using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace SpaceTradingGame
{
    class User
    {
        private string _name;
        private string _shipType;
        private decimal _credits=0;
        private double _time=0;
        private decimal _totalCreditsEarned=0;
        private string _currentLocation = "Earth";
        private List<string> cargo = new List<string>();

        public void CreateUser(string userName, string userShipType, decimal userCredits, double userTime, decimal userTotalCreditsEarned)
        {
            _name = userName;
            _shipType = userShipType;
            _credits = userCredits;
            _time = userTime;
            _totalCreditsEarned = userTotalCreditsEarned;
        }

        public string GetUserName()
        {
            return _name;
        }

        public string GetShipType()
        {
            return _shipType;
        }

        public void SetShipType(string shipType)
        {
            _shipType = shipType;
        }

        public decimal GetCredits()
        {
            return _credits;
        }

        public void SetCredits(decimal credits)
        {
            _credits += credits;
        }

        public double GetUserTime()
        {
            return _time;
        }

        public void SetUserTime(double userTime)
        {
            _time = userTime;
        }

        public decimal GetTotalCreditsEarned()
        {
            return _totalCreditsEarned;
        }

        public void SetTotalCreditsEarned(decimal creditsEarned)
        {
            _totalCreditsEarned += creditsEarned;
        }

        public string GetCurrentLocation()
        {
            return _currentLocation;
        }

        public void SetCurrentLocation(string planet)
        {
            _currentLocation = planet;
        }

        public List<string> GetCurrentCargo()
        {
            return cargo;
        }

        public void AddCargo(string good, int cargoSpace)
        {
            if (cargo.Count < cargoSpace)
            {
                cargo.Add(good);
            }
        }
    }
}
