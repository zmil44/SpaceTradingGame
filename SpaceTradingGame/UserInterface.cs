//finsih coding logic for menu where when i select something i can actually do something
//fix issue where -1 wont let me exit game
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
                                          "1. Buy \n2. Sell\n3. Travel\n4. Buy new ship\n-1. Quit");
                        choice = GetInput();

                } while ( choice<-1 || choice > 4|| choice==0  );

                switch (choice)
                {
                    case -1:
                        break;
                    case 1:
                        choice = DisplayBuyMenu(player, gold, uranium, diamond, oil, wood, copper, darkMatter);
                        break;
                    case 2:
                        choice = DisplaySellMenu(player, gold, uranium, diamond, oil, wood, copper, darkMatter);
                        break;
                    case 3:
                        choice = DisplayTravelMenu(player, earth, alphaCentauri, gliese);
                        break;
                    case 4:
                        choice = DisplayShipBuyMenu(player,simiyarLightFreighter,tradeFederationCruiser,cr90Corvette,milleniumFalcon,imperialStarDestroyer);
                        break;
                    default:
                        choice = 0;
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
            bool badInput=false;
            do
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    badInput = false;

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
            int choice = -2;
            int quantity = 0;
            int [] goodsQuantity = new int[7] {0,0,0,0,0,0,0};
            do
            {
                GetCurrentInventoryQuantities(goodsQuantity,player);
                ClearScreen();
                Console.WriteLine("What goods would you like to buy? " +
                                  "\nEnter the corresponding number to decide: " +
                                  $"\n You currently have {player.GetCredits()} credits" +
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
                    choice = DisplayInventory(player, goodsQuantity);

                }
                else if (choice == 1)
                {
                    do
                    {
                        Console.WriteLine("You have selected to buy gold. How much gold would you like to buy? " +
                                          " Enter 0 to not buy anything. (Note: each unit will take up 1 cargo space)");
                        quantity = GetInput();
                    } while (quantity < 0 || quantity + player.GetCurrentCargo().Count > player.GetMaxCargo()
                                          ||gold.GetPriceOfGood()*quantity>player.GetCredits());

                    if (quantity > 0)
                    {
                        for (int i = 0; i < quantity; i++)
                        {
                            player.AddCargo(gold.GetNameOfGood());
                        }

                        player.SetCredits(-(gold.GetPriceOfGood() * quantity));
                    }
                }
                else if (choice == 2)
                {
                    do
                    {
                        Console.WriteLine("You have selected to buy diamonds. How much diamonds would you like to buy? " +
                                          " Enter 0 to not buy anything. (Note: each unit will take up 1 cargo space)");
                        quantity = GetInput();
                    } while (quantity < 0 || quantity + player.GetCurrentCargo().Count > player.GetMaxCargo()
                                          || diamond.GetPriceOfGood() * quantity > player.GetCredits());

                    if (quantity > 0)
                    {
                        for (int i = 0; i < quantity; i++)
                        {
                            player.AddCargo(diamond.GetNameOfGood());
                        }

                        player.SetCredits(-(diamond.GetPriceOfGood() * quantity));
                    }
                }
                else if (choice == 3)
                {
                    do
                    {
                        Console.WriteLine("You have selected to buy uranium. How much uranium would you like to buy? " +
                                          " Enter 0 to not buy anything. (Note: each unit will take up 1 cargo space)");
                        quantity = GetInput();
                    } while (quantity < 0 || quantity + player.GetCurrentCargo().Count > player.GetMaxCargo()
                                          || uranium.GetPriceOfGood() * quantity > player.GetCredits());

                    if (quantity > 0)
                    {
                        for (int i = 0; i < quantity; i++)
                        {
                            player.AddCargo(uranium.GetNameOfGood());
                        }

                        player.SetCredits(-(uranium.GetPriceOfGood() * quantity));
                    }
                }
                else if (choice == 4)
                {
                    do
                    {
                        Console.WriteLine("You have selected to buy oil. How much oil would you like to buy? " +
                                          " Enter 0 to not buy anything. (Note: each unit will take up 1 cargo space)");
                        quantity = GetInput();
                    } while (quantity < 0 || quantity + player.GetCurrentCargo().Count > player.GetMaxCargo()
                                          || oil.GetPriceOfGood() * quantity > player.GetCredits());

                    if (quantity > 0)
                    {
                        for (int i = 0; i < quantity; i++)
                        {
                            player.AddCargo(oil.GetNameOfGood());
                        }

                        player.SetCredits(-(oil.GetPriceOfGood() * quantity));
                    }
                }
                else if (choice == 5)
                {
                    do
                    {
                        Console.WriteLine("You have selected to buy wood. How much wood would you like to buy? " +
                                          " Enter 0 to not buy anything. (Note: each unit will take up 1 cargo space)");
                        quantity = GetInput();
                    } while (quantity < 0 || quantity + player.GetCurrentCargo().Count > player.GetMaxCargo()
                                          || wood.GetPriceOfGood() * quantity > player.GetCredits());

                    if (quantity > 0)
                    {
                        for (int i = 0; i < quantity; i++)
                        {
                            player.AddCargo(wood.GetNameOfGood());
                        }

                        player.SetCredits(-(wood.GetPriceOfGood() * quantity));
                    }
                }
                else if (choice == 6)
                {
                    do
                    {
                        Console.WriteLine("You have selected to buy copper. How much copper would you like to buy? " +
                                          " Enter 0 to not buy anything. (Note: each unit will take up 1 cargo space)");
                        quantity = GetInput();
                    } while (quantity < 0 || quantity + player.GetCurrentCargo().Count > player.GetMaxCargo()
                                          || copper.GetPriceOfGood() * quantity > player.GetCredits());

                    if (quantity > 0)
                    {
                        for (int i = 0; i < quantity; i++)
                        {
                            player.AddCargo(copper.GetNameOfGood());
                        }

                        player.SetCredits(-(copper.GetPriceOfGood() * quantity));
                    }
                }
                else if (choice == 7)
                {
                    do
                    {
                        Console.WriteLine("You have selected to buy dark matter. How much dark matter would you like to buy? " +
                                          " Enter 0 to not buy anything. (Note: each unit will take up 1 cargo space)");
                        quantity = GetInput();
                    } while (quantity < 0 || quantity + player.GetCurrentCargo().Count > player.GetMaxCargo()
                                          || darkMatter.GetPriceOfGood() * quantity > player.GetCredits());

                    if (quantity > 0)
                    {
                        for (int i = 0; i < quantity; i++)
                        {
                            player.AddCargo(darkMatter.GetNameOfGood());
                        }

                        player.SetCredits(-(darkMatter.GetPriceOfGood() * quantity));
                    }
                }
            } while (choice < 0 || choice > 8);
            

            return choice;
        }

        private void GetCurrentInventoryQuantities(int[] goodsQuantity, User player)
        {
            for (int i = 0; i < player.GetCurrentCargo().Count; i++)
            {
                switch (player.GetCurrentCargo()[i])
                {
                    case "Gold":
                        goodsQuantity[0] += 1;
                        break;
                    case "Diamond":
                        goodsQuantity[1] += 1;
                        break;
                    case "Uranium":
                        goodsQuantity[2] += 1;
                        break;
                    case "Oil":
                        goodsQuantity[3] += 1;
                        break;
                    case "Wood":
                        goodsQuantity[4] += 1;
                        break;
                    case "Copper":
                        goodsQuantity[5] += 1;
                        break;
                    case "Dark Matter":
                        goodsQuantity[6] += 1;
                        break;
                }
            }
            
        }

        private int DisplaySellMenu(User player, Goods gold, Goods diamond, Goods uranium, Goods oil, Goods wood, Goods copper,
            Goods darkMatter)
        {
            int choice = -1;
            int quantity = 0;
            int [] goodsQuantity = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            do
            {
                GetCurrentInventoryQuantities(goodsQuantity,player);
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
                switch (choice)
                {
                    
                    case 1:
                        do
                        {
                            Console.WriteLine(
                                $"You have selected to sell Gold. You currently have {goodsQuantity[0]} peices of gold" +
                                $"\n How many would you like to sell?");
                            quantity = GetInput();
                        } while (quantity < 0 || quantity > goodsQuantity[0]);

                        if (quantity > 0)
                        {
                            for (int i = 0; i < quantity; i++)
                            {
                                player.RemoveCargo(gold.GetNameOfGood());
                            }
                            player.SetCredits(gold.GetPriceOfGood() * quantity);
                        }

                        break;
                    case 2:
                        do
                        {
                            Console.WriteLine(
                                $"You have selected to sell Diamonds. You currently have {goodsQuantity[1]} peices of diamond" +
                                $"\n How many would you like to sell?");
                            quantity = GetInput();
                        } while (quantity < 0 || quantity > goodsQuantity[1]);

                        if (quantity > 0)
                        {
                            for (int i = 0; i < quantity; i++)
                            {
                                player.RemoveCargo(diamond.GetNameOfGood());
                            }
                            player.SetCredits(diamond.GetPriceOfGood() * quantity);
                        }

                        break;
                    case 3:
                        do
                        {
                            Console.WriteLine(
                                $"You have selected to sell Uranium. You currently have {goodsQuantity[2]} peices of uranium" +
                                $"\n How many would you like to sell?");
                            quantity = GetInput();
                        } while (quantity < 0 || quantity > goodsQuantity[2]);

                        if (quantity > 0)
                        {
                            for (int i = 0; i < quantity; i++)
                            {
                                player.RemoveCargo(uranium.GetNameOfGood());
                            }
                            player.SetCredits(uranium.GetPriceOfGood() * quantity);
                        }

                        break;
                    case 4:
                        do
                        {
                            Console.WriteLine(
                                $"You have selected to sell Oil. You currently have {goodsQuantity[3]} peices of oil" +
                                $"\n How many would you like to sell?");
                            quantity = GetInput();
                        } while (quantity < 0 || quantity > goodsQuantity[3]);

                        if (quantity > 0)
                        {
                            for (int i = 0; i < quantity; i++)
                            {
                                player.RemoveCargo(oil.GetNameOfGood());
                            }
                            player.SetCredits(oil.GetPriceOfGood() * quantity);
                        }

                        break;
                    case 5:
                        do
                        {
                            Console.WriteLine(
                                $"You have selected to sell wood. You currently have {goodsQuantity[4]} peices of wood" +
                                $"\n How many would you like to sell?");
                            quantity = GetInput();
                        } while (quantity < 0 || quantity > goodsQuantity[4]);

                        if (quantity > 0)
                        {
                            for (int i = 0; i < quantity; i++)
                            {
                                player.RemoveCargo(wood.GetNameOfGood());
                            }
                            player.SetCredits(wood.GetPriceOfGood() * quantity);
                        }

                        break;
                    case 6:
                        do
                        {
                            Console.WriteLine(
                                $"You have selected to sell Copper. You currently have {goodsQuantity[5]} peices of copper" +
                                $"\n How many would you like to sell?");
                            quantity = GetInput();
                        } while (quantity < 0 || quantity > goodsQuantity[5]);

                        if (quantity > 0)
                        {
                            for (int i = 0; i < quantity; i++)
                            {
                                player.RemoveCargo(copper.GetNameOfGood());
                            }
                            player.SetCredits(copper.GetPriceOfGood() * quantity);
                        }

                        break;
                    case 7:
                        do
                        {
                            Console.WriteLine(
                                $"You have selected to sell Dark Matter. You currently have {goodsQuantity[6]} peices of dark matter" +
                                $"\n How many would you like to sell?");
                            quantity = GetInput();
                        } while (quantity < 0 || quantity > goodsQuantity[6]);

                        if (quantity > 0)
                        {
                            for (int i = 0; i < quantity; i++)
                            {
                                player.RemoveCargo(darkMatter.GetNameOfGood());
                            }
                            player.SetCredits(darkMatter.GetPriceOfGood() * quantity);
                        }

                        break;
                    case 8:
                        choice = DisplayInventory(player,goodsQuantity);
                        break;
                    default:
                        choice = 0;
                        break;
                }
                
            } while (choice < 0 || choice > 8);

            return choice;
        }

        private int DisplayTravelMenu(User player, Planet earth, Planet alphaCentauri, Planet gliese)
        {
            int choice = -2;
            do
            {
                ClearScreen();
                Console.WriteLine($"You are currently on {player.GetCurrentLocation()}");
                if (player.GetCurrentLocation() == earth.GetPlanetName())
                {
                    Console.WriteLine(
                        $"You can travel to \n1. {alphaCentauri.GetPlanetName()}\t Distance from {player.GetCurrentLocation()}: {alphaCentauri.GetDistanceToEarth()}" +
                        $"\n2. {gliese.GetPlanetName()}\t Distance from {player.GetCurrentLocation()}: {gliese.GetDistanceToEarth()}" +
                        $"\n0. return to previous menu");
                }
                else if (player.GetCurrentLocation() == alphaCentauri.GetPlanetName())
                {
                    Console.WriteLine(
                        $"You can travel to \n1. {earth.GetPlanetName()}\t Distance from {player.GetCurrentLocation()}: {earth.GetDistanceToAlphaCentauri()}" +
                        $"\n2. {gliese.GetPlanetName()}\t Distance from {player.GetCurrentLocation()}: {gliese.GetDistanceToAlphaCentauri()}" +
                        $"\n0. Return to previous menu");
                }
                else
                {
                    Console.WriteLine(
                        $"You can travel to \n1. {earth.GetPlanetName()}\t Distance from {player.GetCurrentLocation()}: {gliese.GetDistanceToEarth()}" +
                        $"\n2. {alphaCentauri.GetPlanetName()}\t Distance from {player.GetCurrentLocation()}: {alphaCentauri.GetDistanceToGliese()}" +
                        $"\n0. return to previous menu");
                }

                choice = GetInput();
            }while(choice<0||choice>2);

            return choice;
        }

        private int DisplayShipBuyMenu(User player, Ship simiyarShip, Ship tradeFederationCruiser,Ship cr90Corvette, Ship milleniumFalcon, Ship
            imperialStarDestroyer)
        {
            int choice = -2;
            do
            {
                ClearScreen();
                Console.WriteLine(
                    "Welcome to the Joe's Ship Dealership. Here you are able to purchase a new ship while selling your current one." +
                    $"\nYou currently have {player.GetCredits()} credits and the ship you currently own is {player.GetShipType()}\n Ships we currently have in stock are as follows: " +
                    $"\n1. Simiyar-Class Light Freighter \tPrice: {simiyarShip.GetShipCost()} credits\t Cargo Space: " +
                    $"{simiyarShip.GetCargoSpace()}\tMax warp speed: {simiyarShip.GetMaxWarpSpeed()}" +
                    $"\n2. Trade Federation Cruiser \t Price: {tradeFederationCruiser.GetShipCost()} credits\t Cargo Space: " +
                    $"{tradeFederationCruiser.GetCargoSpace()}\tMax warp speed: {tradeFederationCruiser.GetMaxWarpSpeed()}" +
                    $"\n3. CR90 Corvette \t\t Price {cr90Corvette.GetShipCost()} credits\t Cargo Space: {cr90Corvette.GetCargoSpace()}" +
                    $"\tMax warp speed: {cr90Corvette.GetMaxWarpSpeed()}" +
                    $"\n4. Millenuim Falcon \t Price: {milleniumFalcon.GetShipCost()}\t Cargo Space: {milleniumFalcon.GetCargoSpace()}" +
                    $"\tMax warp Speed: {milleniumFalcon.GetMaxWarpSpeed()}" +
                    "\n0. Return to previous menu");
                choice = GetInput();
            } while (choice < 0 || choice > 4);

            return choice;
        }

        private int DisplayInventory(User player,int[] goodsQuantity)
        {
            ClearScreen();
            Console.WriteLine("Here is your current inventory. Press enter to continue");
            for (int i = 0; i < 7; i++)
            {
                switch (i)
                {
                    case 0:
                        Console.WriteLine($"Quantity of Gold: {goodsQuantity[i]}");
                        break;
                    case 1:
                        Console.WriteLine($"Quantity of Diamond: {goodsQuantity[i]}");
                        break;
                    case 2:
                        Console.WriteLine($"Quantity of Uranium: {goodsQuantity[i]}");
                        break;
                    case 3:
                        Console.WriteLine($"Quantity of Oil: {goodsQuantity[i]}");
                        break;
                    case 4:
                        Console.WriteLine($"Quantity of Wood: {goodsQuantity[i]}");
                        break;
                    case 5:
                        Console.WriteLine($"Quantity of Copper: {goodsQuantity[i]}");
                        break;
                    case 6:
                        Console.WriteLine($"Quantity of Dark Matter: {goodsQuantity[i]}");
                        break;
                }
            }

            Console.Read();
            return (0);
        }
    }
}
