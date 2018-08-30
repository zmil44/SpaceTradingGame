using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class TravelMenu
    {
        public bool hasTravelled = false;
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

        public int GetPlanetChoice(List<int> options)
        {
            int choice;
            bool goodInput=false;
            do
            {
                Console.WriteLine(
                    "Please enter the number of the planet you would like to travel to. Enter -1 to return to main menu.");
                choice = UserInterface.GetInput();
                for (int i = 0; i < options.Count; i++)
                {
                    if (choice == -1)
                    {
                        return choice;
                    }
                    if (choice == options[i])
                    {
                        goodInput = true;
                        break;
                    }
                }
            } while (!goodInput);
            return choice;
        }

        private static int GetWarpSpeed(Ship currentShip)
        {

            int warpSpeed;
            do
            {
                Console.WriteLine(
                    $"Please enter your warp speed (Your ship has a max warp speed of {currentShip.GetMaxWarpSpeed()}");
                warpSpeed = UserInterface.GetInput();
            } while (warpSpeed > currentShip.GetMaxWarpSpeed());
            return warpSpeed;
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

        public string TryTravel(int choice, Ship currentShip,User player, Planet[] planets, WarpSpeed travel)
        {
            if (choice == -1)
            {
                return "You have decided not to travel.";
            }

                int warpSpeed = GetWarpSpeed(currentShip);

            if (warpSpeed == 0)
            {
                return "You have decided not to travel.";
            }

            TravelSuccessful(player, currentShip, choice,
                        warpSpeed, planets, travel);
            return $"You have successfully travelled to {planets[choice].GetPlanetName()}";
                
            
        }

        private void TravelSuccessful(User player, Ship currentShip, int choice, int warpSpeed, Planet[] planets, WarpSpeed travel)
        {
            
            player.SetUserTime(travel.GetTimeTravelled(
            player.GetCurrentPlanet().distanceBetweenPlanets[choice],
            warpSpeed));
            var fuelUsed = (player.GetCurrentPlanet().distanceBetweenPlanets[choice]);
            currentShip.currentFuelLevel += -fuelUsed;
            player.SetCurrentPlanet(planets[choice]);
            hasTravelled = true;
            
        }
    }
}