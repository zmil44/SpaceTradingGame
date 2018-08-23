using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class Planet
    {
        private double _distanceToEarth;
        private double _distanceToAlphaCentauri;
        private double _distanceToGliese;
        private string _planetName;
        private string _traderName;


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
