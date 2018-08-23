
namespace SpaceTradingGame
{
    class Planet
    {
        private readonly double _distanceToEarth;
        private readonly double _distanceToAlphaCentauri;
        private readonly double _distanceToGliese;
        private readonly string _planetName;
        private readonly string _traderName;


        public Planet(string name, string trader, double distanceEarth, double distanceAlphaCentauri,
            double distanceGliese)
        {
            _planetName = name;
            _traderName = trader;
            _distanceToEarth = distanceEarth;
            _distanceToAlphaCentauri = distanceAlphaCentauri;
            _distanceToGliese = distanceGliese;
        }

        public string GetPlanetName()
        {
            return _planetName;
        }

        public string GetTraderName()
        {
            return _traderName;
        }

        public double GetDistanceToEarth()
        {
            return _distanceToEarth;
        }

        public double GetDistanceToAlphaCentauri()
        {
            return _distanceToAlphaCentauri;
        }

        public double GetDistanceToGliese()
        {
            return _distanceToGliese;
        }
    }
}
