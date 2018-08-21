using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class UserInterface
    {
        public void CreateObjects(string name)
        {
            //create and display story
            Story userStory = new Story();
            userStory.SetStory();
            userStory.DisplayStory();

            //create goods
            Goods gold = new Goods();
            gold.CreateGood("Gold", 12000m);
            Goods diamond = new Goods();
            diamond.CreateGood("Diamond", 1400m);
            Goods uranium = new Goods();
            uranium.CreateGood("Uranium", 70m);
            Goods oil = new Goods();
            oil.CreateGood("Oil", 66.30m);
            Goods wood = new Goods();
            wood.CreateGood("Wood", 10m);
            Goods copper = new Goods();
            copper.CreateGood("Copper", 2.50m);
            Goods darkMatter = new Goods();
            darkMatter.CreateGood("Dark Matter", 450000m);

            //Create ships
            Ship simiyarLightFreighter = new Ship();
            simiyarLightFreighter.CreateShip("Simiyar-Class Light Freighter", 50, 3, 25000);
            Ship tradeFederationCruiser = new Ship();
            tradeFederationCruiser.CreateShip("Trade Federation Cruiser", 300, 4, 75000);
            Ship cr90Corvette = new Ship();
            cr90Corvette.CreateShip("CR90 Corvette",750 , 7, 125000);
            Ship milleniumFalcon = new Ship();
            milleniumFalcon.CreateShip("Simiyar-Class Light Freighter", 50, 3, 400000);
            Ship imperialStarDestroyer = new Ship();
            imperialStarDestroyer.CreateShip("Imperial-Class Star Destroyer", 1000, 7, 500000);

            //Create Planets
            Planet earth = new Planet();
            earth.CreatePlanet("Earth", "Adam Thielen", 0, 4.367, 23.62);
            Planet alphaCentauri = new Planet();
            alphaCentauri.CreatePlanet("Aplha Centauri"," ",4.367, 0, 24.02);
            Planet gliese = new Planet();
            gliese.CreatePlanet("Gliese", "Orgrim Doomhammer", 23.62,24.02,0);

            //Create user
            User player = new User();
            player.CreateUser(name,"Simiyar-Class Light Freighter",25000,0,0);

        }

        public void RunUserInterface()
        {
            Console.Write("\nPlease enter your name: ");
            string name = Console.ReadLine();
            CreateObjects(name);
           
        }


    }
}
