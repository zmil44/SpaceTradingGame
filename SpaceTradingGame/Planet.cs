
using System.Collections.Generic;

namespace SpaceTradingGame
{
    class Planet
    {

        readonly string planetName;
        readonly string traderName;
        readonly double xCord;
        readonly double yCord;
        public List<double> distanceBetweenPlanets = new List<double>();


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

        public double GetYCord()
        {
            return yCord;
        }

        public void SetDistanceToPlanet(double distance)
        {
            distanceBetweenPlanets.Add(distance);
        }

        public List<double> GetDistanceToPlanet()
        {
            return distanceBetweenPlanets;
        }

    }
}
