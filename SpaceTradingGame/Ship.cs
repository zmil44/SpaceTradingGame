using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class Ship
    {
        private string _shipName;
        private int _shipCargoSpace;
        private int _shipMaxWarpSpeed;
        private int _shipCost;
        private void CreateShip(string name, int cargoSpace, int maxWarpSpeed, int cost)
        {
            _shipName = name;
            _shipCargoSpace = cargoSpace;
            _shipMaxWarpSpeed = maxWarpSpeed;
            _shipCost = cost;
        }
    }
}
