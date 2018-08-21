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

        private string GetShipName()
        {
            return _shipName;
        }

        private int GetCargoSpace()
        {
            return _shipCargoSpace;
        }

        private int GetMaxWarpSpeed()
        {
            return _shipMaxWarpSpeed;
        }

        private int GetShipCost()
        {
            return _shipCost;
        }

        private string BuyShip()
        {
            return _shipName;
        }
    }
}
