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
        private decimal _credits;
        private double _time;
        private decimal _totalCreditsEarned;


        private void SetUser(string userName, string userShipType, decimal userCredits, double userTime, decimal userTotalCreditsEarned)
        {
            _name = userName;
            _shipType = userShipType;
            _credits = userCredits;
            _time = userTime;
            _totalCreditsEarned = userTotalCreditsEarned;
        }
    }
}
