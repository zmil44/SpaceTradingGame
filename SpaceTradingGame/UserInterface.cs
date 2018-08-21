﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class UserInterface
    {
        public void CreateObjects()
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
        }

        public void RunUserInterface()
        {
            CreateObjects();
           
        }


    }
}
