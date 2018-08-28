using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class TravelMenu
    {
        public List<int> DisplayTravelMenu(User player, Planet[] planets,Ship currentShip)
        {
            Console.WriteLine($"You are currently on {player.GetCurrentPlanet().GetPlanetName()}");
            var currentOptions = new List<int>();
            for (int i = 0; i < planets.Length; i++)
            {
                
                if(player.GetCurrentPlanet().GetDistanceToPlanet()[i]<(1*currentShip.GetCurrentFuelLevel()) && planets[i].GetPlanetName()!=player.GetCurrentPlanet().GetPlanetName())
                {
                    Console.WriteLine(
                        $"{i}. {planets[i].GetPlanetName()}\t distance: {(player.GetCurrentPlanet().GetDistanceToPlanet())[i]}");
                    currentOptions.Add(i);
                }
            }
            return currentOptions;
        }

        public void CalculateDistanceBetweenPlanets(Planet[] planets)
        {
            for (int i = 0; i < planets.Length; i++)
            {
                for (int j = 0; j < planets.Length; j++)
                {
                    double xDifference = Math.Pow(planets[j].GetXCord()-planets[i].GetXCord(),2);
                    double yDifference = Math.Pow(planets[j].GetYCord() - planets[i].GetYCord(), 2);
                    double distance = Math.Round(Math.Sqrt(xDifference + yDifference),3);
                    planets[j].SetDistanceToPlanet(distance);
                }
            }
        }
    }
}