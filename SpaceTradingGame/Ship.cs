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

        public Ship(string name, int cargoSpace, int maxWarpSpeed, int cost)
        {
            _shipName = name;
            _shipCargoSpace = cargoSpace;
            _shipMaxWarpSpeed = maxWarpSpeed;
            _shipCost = cost;
        }

        public string GetShipName()
        {
            return _shipName;
        }

        public int GetCargoSpace()
        {
            return _shipCargoSpace;
        }

        public int GetMaxWarpSpeed()
        {
            return _shipMaxWarpSpeed;
        }

        public int GetShipCost()
        {
            return _shipCost;
        }

    }
}
