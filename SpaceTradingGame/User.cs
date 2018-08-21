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


        private void SetUser(string userName, string userShipType, decimal userCredits, double userTime, decimal userTotalCreditsEarned)
        {
            _name = userName;
            _shipType = userShipType;
            _credits = userCredits;
            _time = userTime;
            _totalCreditsEarned = userTotalCreditsEarned;
        }

        private string GetUserName()
        {
            return _name;
        }

        private string GetShipType()
        {
            return _shipType;
        }

        private void SetShipType(string shipType)
        {
            _shipType = shipType;
        }

        private decimal GetCredits()
        {
            return _credits;
        }

        private void SetCredits(decimal credits)
        {
            _credits += credits;
        }

        private double GetUserTime()
        {
            return _time;
        }

        private void SetUserTime(double userTime)
        {
            _time = userTime;
        }

        private decimal GetTotalCreditsEarned()
        {
            return _totalCreditsEarned;
        }

        private void SetTotalCreditsEarned(decimal creditsEarned)
        {
            _totalCreditsEarned += creditsEarned;
        }

        private string GetCurrentLocation()
        {
            return _currentLocation;
        }

        private void SetCurrentLocation(string planet)
        {
            _currentLocation = planet;
        }
    }
}
