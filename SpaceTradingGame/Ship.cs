
namespace SpaceTradingGame
{
    class Ship
    {
        private readonly string _shipName;
        private readonly int _shipCargoSpace;
        private readonly int _shipMaxWarpSpeed;
        private readonly int _shipCost;

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
