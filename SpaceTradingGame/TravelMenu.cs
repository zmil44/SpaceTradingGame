using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class TravelMenu
    {
        public void DisplayTravelMenu(User player, Planet[] planets)
        {
            Console.WriteLine($"You are currently on {player.GetCurrentLocation()}");
            for (int i = 0; i < planets.Length; i++)
            {
                if(planets[i].GetDistanceToPlanet()[i]<10)
                {
                    Console.WriteLine(
                        $"{i}. {planets[i].GetPlanetName()}\t distance: {planets[i].GetDistanceToPlanet()[i]}");
                }
            }
        }

        public void CalculateDistanceBetweenPlanets(Planet[] planets)
        {
            for (int i = 0; i < planets.Length; i++)
            {
                for (int j = 1; j < planets.Length; j++)
                {
                    double xDifference = Math.Pow(planets[j].GetXCord()-planets[i].GetXCord(),2);
                    double yDifference = Math.Pow(planets[j].GetYCord() - planets[i].GetYCord(), 2);
                    double distance = Math.Sqrt(xDifference + yDifference);
                    planets[j - 1].SetDistanceToPlanet(distance);
                }
            }
        }
    }
}
