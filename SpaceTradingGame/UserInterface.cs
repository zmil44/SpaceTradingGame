using System;

namespace SpaceTradingGame
{
    class UserInterface
    {
        public  UserInterface()
        {
            //create and display story
            var story = new Story();

            //create goods
            var goods = CreateGoods();

            //Create ships
            var ships = CreateShips();

            //Create Planets
            var planets = CreatePlanets();

            BuyMenu buyMenu = new BuyMenu();
            SellMenu sellMenu = new SellMenu();
            BuyShipMenu buyShipMenu = new BuyShipMenu();
            TravelMenu travelMenu = new TravelMenu();
            travelMenu.CalculateDistanceBetweenPlanets(planets);
            
            //Create user
            Console.Write("\nPlease enter your name: ");
            var player = new User(Console.ReadLine());

            //create warpSpeed
            var travel = new WarpSpeed();
            
            var currentShip= ships[1];
            var exit = false;
            var hasTravelled = false;
            Random rand = new Random();
            player.SetCurrentPlanet(planets[0]);
            string exitMessage="";
            do
            {
                var goodsQuantity = player.GetCurrentInventoryQuantities();
                var choice = -2;
                Console.Clear();
                player.CalculateYears();
                if (player.GetUserTimeInYears() >= 40 ||currentShip.currentFuelLevel==0.00 ||(player.GetCredits()==0&&player.GetCurrentCargo().Count ==0))
                {
                    Console.Clear();
                    if (player.GetUserTimeInYears() >= 40)
                    {
                        exitMessage=("You have travelled for over 40 years");
                    }
                    else if (currentShip.currentFuelLevel== 0.00)
                    {
                        exitMessage=("You ran out of fuel");
                    }
                    else
                    {
                        exitMessage=("You ran out of credits and goods to sell");
                    }
                    exit = true;
                }

                if (hasTravelled == true)
                {
                        goods[1].SetPriceOfGood(rand.Next(1, 4500));
                        goods[2].SetPriceOfGood(rand.Next(1, 1500));
                        goods[3].SetPriceOfGood(rand.Next(1, 200));
                        goods[4].SetPriceOfGood(rand.Next(1, 500));
                        goods[5].SetPriceOfGood(rand.Next(1, 250));
                        goods[6].SetPriceOfGood(rand.Next(1, 15));
                        goods[7].SetPriceOfGood(rand.Next(100000, 400000));
                        hasTravelled = false;
                }
                
                do
                {
                    if (player.GetUserTimeInYears() >= 40)
                    {
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine(
                        $"You have {player.GetCredits()} and have travelled for {player.GetUserTimeInYears()} years and {player.GetUserDays()} days");
                    Console.WriteLine($"You are currently on {player.GetCurrentPlanet().GetPlanetName()} and have {currentShip.currentFuelLevel} units of fuel");
                    Console.WriteLine("What would you like to do? \n Enter the corresponding number to decide. \n" +
                                      "1. Buy \n2. Sell\n3. Travel\n4. Buy new ship\n5. Refuel Ship\n-1. Quit");
                    choice = GetInput();
                } while (choice < -1 || choice > 5 || choice == 0);

                switch (choice)
                {
                    case -1:
                        exitMessage = "You have decided to retire.";
                        exit = true;
                        break;
                    case 1:
                        Console.Clear();
                        buyMenu.DisplayBuyMenu(player, goods, player.GetCurrentPlanet());
                        choice = GetInput();
                        if (choice == 8)
                        {
                            DisplayInventory(player, goodsQuantity);
                        } 
                        else if (choice>=1||choice<=7)
                        {
                            for (int i = choice;;)
                            {
                                if (choice == 0)
                                {
                                    break;
                                }
                                Console.WriteLine(
                                    $"How many {goods[i].GetNameOfGood()} would you like to buy? " +
                                    $"(note each item will take up 1 cargo space");
                                int quantity = GetInput();
                                goods[i].BuyGood(player, quantity);
                                break;
                            }
                        }
   
                        break;
                    case 2:
                        Console.Clear();
                        sellMenu.DisplaySellMenu(player, goods, player.GetCurrentPlanet());
                        choice = GetInput();
                        for (int i = choice;;)
                        {
                            if (choice == 0)
                            {
                                
                            }
                            else if (choice == 8)
                            {
                                DisplayInventory(player,goodsQuantity);
                            }
                            else
                            {
                                Console.WriteLine(
                                    $"You currently have {goodsQuantity[choice - 1]} peices of {goods[i].GetNameOfGood()}. How many would you like to sell? ");
                                int quantity = GetInput();
                                goods[i].SellGood(player, quantity, choice, goodsQuantity);
                            }


                            break;
                        }

                        
                        break;
                    case 3:
                        Console.Clear();
                        var options = travelMenu.DisplayTravelMenu(player, planets,currentShip);
                        var badInput = false;
                        
                        do
                        {
                            Console.WriteLine("Please enter the number of the planet you would like to travel to. Press enter to return to main menu.");
                            choice = GetInput();
                            for (int i = 0; i < options.Count; i++)
                            {
                                if (choice == 0)
                                {
                                    Console.WriteLine("You have decided not to travel.");
                                    badInput = false;
                                    break;
                                }
                                if (choice == options[i])
                                {
                                    int warpSpeed = 0;
                                    do
                                    {
                                        Console.WriteLine($"Please enter your warp speed (Your ship has a max warp speed of {currentShip.GetMaxWarpSpeed()}");
                                        warpSpeed = GetInput();
                                    } while (warpSpeed > currentShip.GetMaxWarpSpeed());

                                    if (warpSpeed == 0)
                                    {
                                        Console.WriteLine("You have decided not to travel.");
                                    }
                                    else
                                    {

                                        player.SetUserTime(travel.GetTimeTravelled(
                                                player.GetCurrentPlanet().distanceBetweenPlanets[choice],
                                                warpSpeed));
                                            
                                        double fuelUsed = (player.GetCurrentPlanet().distanceBetweenPlanets[choice]);
                                        currentShip.currentFuelLevel += -fuelUsed;
                                        player.SetCurrentPlanet(planets[choice]);
                                        hasTravelled = true;
                                        badInput = false;
                                        break;
                                    }
                                }
                                
                                   badInput = true; 
                            }
                            
                        } while (badInput);

                        break;
                    case 4:
                        Console.Clear();
                        buyShipMenu.DisplayBuyShipMenu(player, ships, currentShip);
                        choice = GetInput();
                        for (int i = choice;;)
                        {
                            if (choice == 0)
                            {
                                Console.WriteLine("You have decided not to buy a ship. Press enter to continue");
                                Console.ReadLine();
                            }
                            else if (player.GetCredits() + currentShip.GetShipCost() >= ships[i].GetShipCost())
                            {
                                player.AddCredits(currentShip.GetShipCost());
                                player.AddCredits(-ships[i].GetShipCost());
                                currentShip = ships[i];
                                player.SetMaxCargo(currentShip.GetCargoSpace());
                                Console.WriteLine(
                                    "You have successfully purchased a new ship. Press enter to continue");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("You do not have enough credits to buy that ship. Press enter to continue");
                                Console.ReadLine();
                            }
                            break;
                        }
                        break;
                    case 5:
                        Console.Clear();
                        decimal refuelCost = Convert.ToDecimal((100 * (currentShip.maxFuelLevel - currentShip.currentFuelLevel)));
                        if (player.GetCredits() - refuelCost < 0)
                        {
                            Console.WriteLine("You do not have enough credits to refuel your ship");
                        }
                        else
                        {
                            Console.WriteLine($"You have refueled your ship for {refuelCost} credits");
                            player.AddCredits(-refuelCost);
                            currentShip.currentFuelLevel = currentShip.maxFuelLevel;
                        }

                        Console.WriteLine("Press Enter to continue");
                        Console.ReadLine();
                        break;
                }
            } while (exit == false);

            story.DisplayEnd(player,exitMessage);
        }

        static Goods[] CreateGoods()
        {
            Goods[] goods = new Goods[8];
            goods[1] = new Goods("Gold", 12000);
            goods[2] = new Goods("Diamond", 1400);
            goods[3]= new Goods("Uranium", 70);
            goods[4]= new Goods("Oil", 66);
            goods[5]= new Goods("Wood", 10);
            goods[6] = new Goods("Copper", 2);
            goods[7]= new Goods("Dark Matter", 450000);
            return goods;
        }

        static Ship[] CreateShips()
        {
            Ship[] ships = new Ship[6];
            ships[1]= new Ship("Simiyar-Class Light Freighter", 50, 3, 25000, 10);
            ships[2] = new Ship("Trade Federation Cruiser", 300, 4, 75000, 20);
            ships[3] = new Ship("CR90 Corvette", 750, 7, 125000, 30);
            ships[4] = new Ship("Millenuim Falcon", 50, 9, 400000, 40);
            ships[5] = new Ship("Imperial-Class Star Destroyer", 1000, 7, 500000, 50);
            return ships;
        }

        static Planet[] CreatePlanets()
        {
            Random rand = new Random();
            Planet[] planet = new Planet[rand.Next(100, 250)];
            planet[0] = new Planet("Earth", "Mace Windu", 0, 0);
            for (int i = 1; i < planet.Length; i++)
            {
                int planetNumber = rand.Next(1, 500);
                planet[i] = new Planet($"Planet{planetNumber}", $"Trader{planetNumber}",
                    Convert.ToDouble(rand.Next(-50, 50)),
                    Convert.ToDouble(rand.Next(-50, 50)));
            }
            return planet;
        }


        private static int GetInput()
        {
            var choice=-2;
            bool badInput;
            do
            {
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    badInput = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Im sorry you did not enter a valid input. Please try again.");
                    badInput = true;
                }
            } while (badInput);
            return choice;
        }
        


        private static void DisplayInventory(User player,int[] goodsQuantity)
        {
            Console.Clear();
            Console.WriteLine("Here is your current inventory. Press enter to continue");
            for (var i = 0; i < 7; i++)
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
            Console.WriteLine("Enter 0 to close inventory");
            Console.ReadLine();
        }
    }
}
