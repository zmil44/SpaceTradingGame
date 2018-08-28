
namespace SpaceTradingGame
{
    class Planet
    {
        readonly double distanceToEarth;
        readonly double distanceToAlphaCentauri;
        readonly double distanceToGliese;
        readonly string planetName;
        readonly string traderName;
        readonly double xCord;
        readonly double yCord;
        


        public Planet(string name, string trader, double xCordinate,double ycordinate)
        {
            planetName = name;
            traderName = trader;
            xCord = xCordinate;
            yCord = ycordinate;
        }

        public string GetPlanetName()
        {
            return planetName;
        }

        public string GetTraderName()
        {
            return traderName;
        }

        public double GetXCord()
        {
            return xCord;
        }

        public double GetyCord()
        {
            return yCord;
        }


    }
}
