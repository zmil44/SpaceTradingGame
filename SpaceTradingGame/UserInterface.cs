using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SpaceTradingGame
{
    class UserInterface
    {
        public void RunUserInterface()
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
            cr90Corvette.CreateShip("CR90 Corvette", 750, 7, 125000);
            Ship milleniumFalcon = new Ship();
            milleniumFalcon.CreateShip("Simiyar-Class Light Freighter", 50, 9, 400000);
            Ship imperialStarDestroyer = new Ship();
            imperialStarDestroyer.CreateShip("Imperial-Class Star Destroyer", 1000, 7, 500000);

            //Create Planets
            Planet earth = new Planet();
            earth.CreatePlanet("Earth", "Mace Windu", 0, 4.367, 23.62);
            Planet alphaCentauri = new Planet();
            alphaCentauri.CreatePlanet("Aplha Centauri", "Yoda", 4.367, 0, 24.02);
            Planet gliese = new Planet();
            gliese.CreatePlanet("Gliese", "Plo Koon", 23.62, 24.02, 0);

            //create trade 
            Trade userTrade = new Trade();

            //Create user
            Console.Write("\nPlease enter your name: ");
            string name = Console.ReadLine();
            User player = new User();
            player.CreateUser(name);

            //create warpSpeed
            WarpSpeed travel = new WarpSpeed();
            int choice = -2;

            do
            {
                if (player.GetCurrentLocation() == "Earth")
                {
                    gold.SetPriceOfGood(12000m);
                    diamond.SetPriceOfGood(1400m);
                    uranium.SetPriceOfGood(70m);
                    oil.SetPriceOfGood(66.30m);
                    wood.SetPriceOfGood(10m);
                    copper.SetPriceOfGood(2.50m);
                    darkMatter.SetPriceOfGood(450000m);
                }
                else if (player.GetCurrentLocation() == "Gliese")
                {
                    gold.SetPriceOfGood(3585m);
                    diamond.SetPriceOfGood(600m);
                    uranium.SetPriceOfGood(200m);
                    oil.SetPriceOfGood(10.18m);
                    wood.SetPriceOfGood(10.98m);
                    copper.SetPriceOfGood(17.25m);
                    darkMatter.SetPriceOfGood(300000m);
                }
                else
                {
                    gold.SetPriceOfGood(12000m);
                    diamond.SetPriceOfGood(3000m);
                    uranium.SetPriceOfGood(70m);
                    oil.SetPriceOfGood(50.25m);
                    wood.SetPriceOfGood(65.30m);
                    copper.SetPriceOfGood(1.50m);
                    darkMatter.SetPriceOfGood(100000m);
                }

                do
                {
                        ClearScreen();
                        Console.WriteLine("What would you like to do? \n Enter the corresponding number to decide. \n" +
                                          "1. Buy \n2. Sell\n3. Travel\n-1. Quit");
                        choice = GetInput();

                } while ( choice<-1 || choice > 3|| choice==0  );

                switch (choice)
                {
                    case 1:
                        choice = DisplayBuyMenu(player, gold, uranium, diamond, oil, wood, copper, darkMatter);
                        break;
                    case 2:
                        choice = DisplaySellMenu(player, gold, uranium, diamond, oil, wood, copper, darkMatter);
                        break;
                }


            } while (choice != -1 || player.GetUserTime() < 40 ||
                     (player.GetCredits() == 0 && player.GetCurrentCargo().Count == 0));

        }

        private void ClearScreen()
        {
            for (int i = 0; i < Console.LargestWindowHeight; i++)
            {
                Console.WriteLine();
            }
        }

        private int GetInput()
        {
            int choice=-2;
            bool badInput;
            do
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    if (choice == -2)
                    {
                        badInput = true;
                    }
                    else
                    {
                        badInput = false;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Im sorry you did not enter a valid input. Please try again.");
                    badInput = true;
                }
            } while (badInput);

            return choice;
        }

        private int DisplayBuyMenu(User player,Goods gold, Goods diamond, Goods uranium, Goods oil, Goods wood, Goods copper, Goods darkMatter)
        {
            int choice = -1;
            do
            {
                ClearScreen();
                Console.WriteLine("What goods would you like to buy? " +
                                  "\nEnter the corresponding number to decide: " +
                                  $"\n 1. {gold.GetNameOfGood()}\tprice: {gold.GetPriceOfGood()}" +
                                  $"\n 2. {diamond.GetNameOfGood()}\tprice: {diamond.GetPriceOfGood()}" +
                                  $"\n 3. {uranium.GetNameOfGood()}\tprice: {uranium.GetPriceOfGood()}" +
                                  $"\n 4. {oil.GetNameOfGood()}\t\tprice: {oil.GetPriceOfGood()}" +
                                  $"\n 5. {wood.GetNameOfGood()}\tprice: {wood.GetPriceOfGood()}" +
                                  $"\n 6. {copper.GetNameOfGood()}\tprice: {copper.GetPriceOfGood()}" +
                                  $"\n 7. {darkMatter.GetNameOfGood()}\tprice: {darkMatter.GetPriceOfGood()}" +
                                  $"\n 8. Display current inventory" +
                                  "\n 0 to return to original screen");
                choice = GetInput();
                if (choice == 8)
                {
                    DisplayInventory(player);

                }
            } while (choice < 0 || choice > 7);

            return choice;
        }

        private int DisplaySellMenu(User player, Goods gold, Goods diamond, Goods uranium, Goods oil, Goods wood, Goods copper,
            Goods darkMatter)
        {
            int choice = -1;
            do
            {
                ClearScreen();
                Console.WriteLine("What goods would you like to sell? " +
                                  "\nEnter the corresponding number to decide: " +
                                  $"\n 1. {gold.GetNameOfGood()}\tprice: {gold.GetPriceOfGood()}" +
                                  $"\n 2. {diamond.GetNameOfGood()}\tprice: {diamond.GetPriceOfGood()}" +
                                  $"\n 3. {uranium.GetNameOfGood()}\tprice: {uranium.GetPriceOfGood()}" +
                                  $"\n 4. {oil.GetNameOfGood()}\t\tprice: {oil.GetPriceOfGood()}" +
                                  $"\n 5. {wood.GetNameOfGood()}\tprice: {wood.GetPriceOfGood()}" +
                                  $"\n 6. {copper.GetNameOfGood()}\tprice: {copper.GetPriceOfGood()}" +
                                  $"\n 7. {darkMatter.GetNameOfGood()}\tprice: {darkMatter.GetPriceOfGood()}" +
                                  $"\n8. Display current inventory" +
                                  "\n 0 to return to original screen");
                choice = GetInput();
                if (choice == 8)
                {
                    DisplayInventory(player);
                    
                }
            } while (choice < 0 || choice > 7);

            return choice;
        }

        private void DisplayInventory(User player)
        {
            ClearScreen();
            Console.WriteLine("Here is your current inventory. Press enter to continue");
            foreach (var item in player.GetCurrentCargo())
            {
                Console.WriteLine(item);
            }

            Console.Read();
        }
    }
}
