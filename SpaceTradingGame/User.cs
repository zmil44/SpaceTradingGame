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
        private decimal _credits=25000;
        private int _timeInYears=0;
        private int _timeInDays=0;
        private decimal _totalCreditsEarned=0;
        private string _currentLocation = "Earth";
        private List<string> _cargo = new List<string>();
        private int _maxCargoSpace = 50;
        private Planet currentPlanet = new Planet();

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
            if (_timeInDays > 365)
            {
                int years = _timeInDays/365;
                _timeInYears += years;
                _timeInDays -= 365*years;
            }
        }

        public User(string userName)
        {
            _name = userName;

        }

        public string GetUserName()
        {
            return _name;
        }


        public decimal GetCredits()
        {
            return _credits;
        }

        public void SetCredits(decimal credits)
        {
            _credits += credits;
        }

        public int GetUserDays()
        {
            return _timeInDays;
        }

        public void SetUserTime(int userTime)
        {
            _timeInDays += userTime;
        }

        public int GetUserTimeInYears()
        {
            return _timeInYears;
        }
        public decimal GetTotalCreditsEarned()
        {
            return _totalCreditsEarned;
        }

        public void SetTotalCreditsEarned(decimal creditsEarned)
        {
            _totalCreditsEarned += creditsEarned;
        }

        public int GetMaxCargo()
        {
            return _maxCargoSpace;
        }

        public void SetMaxCargo(int maxCargo)
        {
            _maxCargoSpace = maxCargo;
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
            return _cargo;
        }

        public void AddCargo(string good)
        {
                _cargo.Add(good);
        }

        public void RemoveCargo(string good)
        {
            _cargo.Remove(good);
        }


    }
}
