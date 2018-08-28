using System;

namespace SpaceTradingGame
{
    class UserInterface
    {
        public  UserInterface()
        {
            //create and display story
            new Story();

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
            do
            {
                var goodsQuantity = GetCurrentInventoryQuantities(player);
                var choice = -2;
                Console.Clear();
                player.CalculateYears();
                //if (player.GetUserTimeInYears() >= 40 ||fuel==0 ||(player.GetCredits()==0&&player.GetCurrentCargo().Count ==0))
                //{
                //    exit = true;
                //}

                if (hasTravelled == true)
                {
                    
                        //player.SetCurrentPlanet(earth);
                        goods[1].SetPriceOfGood(rand.Next(1, 4500));
                        goods[2].SetPriceOfGood(rand.Next(1, 1500));
                        goods[3].SetPriceOfGood(rand.Next(1, 200));
                        goods[4].SetPriceOfGood(rand.Next(1, 500));
                        goods[5].SetPriceOfGood(rand.Next(1, 250));
                        goods[6].SetPriceOfGood(rand.Next(1, 15));
                        goods[7].SetPriceOfGood(rand.Next(100000, 400000));
                }

                hasTravelled = false;
                do
                {
                    if (player.GetUserTimeInYears() >= 40)
                    {
                        break;
                    }

                    Console.Clear();
                    Console.WriteLine(
                        $"You have {player.GetCredits()} and have travelled for {player.GetUserTimeInYears()} years and {player.GetUserDays()} days");
                    Console.WriteLine($"You are currently on {player.GetCurrentLocation()}");
                    Console.WriteLine("What would you like to do? \n Enter the corresponding number to decide. \n" +
                                      "1. Buy \n2. Sell\n3. Travel\n4. Buy new ship\n-1. Quit");
                    choice = GetInput();
                } while (choice < -1 || choice > 4 || choice == 0);

                switch (choice)
                {
                    case -1:
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
                            Console.WriteLine(
                                $"You currently have {goodsQuantity[choice - 1]} peices of {goods[i].GetNameOfGood()}.How many would you like to sell? ");
                            int quantity = GetInput();
                            goods[i].SellGood(player, quantity, choice, goodsQuantity);
                            break;
                        }

                        
                        break;
                    case 3:
                        Console.Clear();
                        travelMenu.DisplayTravelMenu(player, planets);
                        choice = GetInput();

                        break;
                    case 4:
                        Console.Clear();
                        buyShipMenu.DisplayBuyShipMenu(player, ships, currentShip);
                        choice = GetInput();
                        for (int i = choice;;)
                        {
                            if (player.GetCredits() + currentShip.GetShipCost() >= ships[i].GetShipCost())
                            {
                                player.AddCredits(currentShip.GetShipCost());
                                player.AddCredits(-ships[i].GetShipCost());
                                currentShip = ships[i];
                            }
                            else
                            {
                                Console.WriteLine("You do not have enough credits to buy that ship.");
                            }
                            break;
                        }
                        break;

                }
            } while (exit == false);

            DisplayEnd(player);
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
        private static void DisplayEnd(User player)
        {
            var netIncome =  player.GetCredits()-25000;

            Console.WriteLine($"You have decided to retire. Over the course of your career, you have travelled for {player.GetUserTimeInYears()}" +
                              $" years and {player.GetUserDays()} days. \nYou started with 25,000 credits and you ended with {player.GetCredits()}" +
                              $" credits with a net income of {netIncome} credits.");
            Console.Read();
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



        private static int[] GetCurrentInventoryQuantities(User player)
        {
            int[] goodsQuantity = new int[7];
            for (var i = 0; i < player.GetCurrentCargo().Count; i++)
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

            return goodsQuantity;
        }

        //private static bool DisplayTravelMenu(User player, Planet earth, Planet alphaCentauri, Planet gliese, WarpSpeed travel,Ship currentShip)
        //{
        //    var choice=0;
        //    var travelled = false;
        //    do
        //    {
        //        var warpSpeed = 0;
        //        Console.Clear();
        //        Console.WriteLine($"You are currently on {player.GetCurrentLocation()}");
        //        if (player.GetCurrentLocation() == earth.GetPlanetName())
        //        {
        //            Console.WriteLine(
        //                $"You can travel to \n1. {alphaCentauri.GetPlanetName()}\t Distance from {player.GetCurrentLocation()}: {alphaCentauri.GetDistanceToEarth()}" +
        //                $"\n2. {gliese.GetPlanetName()}\t\t Distance from {player.GetCurrentLocation()}: {gliese.GetDistanceToEarth()}" +
        //                $"\n0. return to previous menu");
        //            choice = GetInput();
        //            Console.Write("You have selected to travel to ");
        //            switch (choice)
        //            {
        //                case 1:
        //                    Console.WriteLine(alphaCentauri.GetPlanetName());
        //                    do
        //                    {
        //                        Console.Write(
        //                            ("Please enter your warp speed. Your ship can travel at a max warp speed of " +
        //                             $"{currentShip.GetMaxWarpSpeed()}: "));
        //                        warpSpeed = GetInput();
        //                    } while (warpSpeed < 0 || warpSpeed > currentShip.GetMaxWarpSpeed());

        //                    if (warpSpeed != 0)
        //                    {
        //                        player.SetUserTime(travel.GetTimeTravelled(alphaCentauri.GetDistanceToEarth(), warpSpeed));
        //                        player.SetCurrentLocation(alphaCentauri.GetPlanetName());
        //                        travelled = true;
        //                    }
        //                    break;
        //                case 2:
        //                    Console.WriteLine(gliese.GetPlanetName());
        //                    do
        //                    {
        //                        Console.Write(
        //                            ("Please enter your warp speed. Your ship can travel at a max warp speed of " +
        //                             $"{currentShip.GetMaxWarpSpeed()}: "));
        //                        warpSpeed = GetInput();
        //                    } while (warpSpeed < 0 || warpSpeed > currentShip.GetMaxWarpSpeed());

        //                    if (warpSpeed != 0)
        //                    {
        //                        player.SetUserTime(travel.GetTimeTravelled(gliese.GetDistanceToEarth(), warpSpeed));
        //                        player.SetCurrentLocation(gliese.GetPlanetName());
        //                        travelled = true;
        //                    }
        //                    break;
        //            }
        //        }
        //        else if (player.GetCurrentLocation() == alphaCentauri.GetPlanetName())
        //        {
        //            Console.WriteLine(
        //                $"You can travel to \n1. {earth.GetPlanetName()}\t Distance from {player.GetCurrentLocation()}: {earth.GetDistanceToAlphaCentauri()}" +
        //                $"\n2. {gliese.GetPlanetName()}\t Distance from {player.GetCurrentLocation()}: {gliese.GetDistanceToAlphaCentauri()}" +
        //                $"\n0. Return to previous menu");
        //            choice = GetInput();
        //            Console.WriteLine("You have selected to travel to ");
        //            switch (choice)
        //            {
        //                case 1:
        //                    Console.WriteLine(earth.GetPlanetName());
        //                    do
        //                    {
        //                        Console.Write(
        //                            ("Please enter your warp speed. Your ship can travel at a max warp speed of " +
        //                             $"{currentShip.GetMaxWarpSpeed()}: "));
        //                        warpSpeed = GetInput();
        //                    } while (warpSpeed < 0 || warpSpeed > currentShip.GetMaxWarpSpeed());

        //                    if (warpSpeed != 0)
        //                    {
        //                        player.SetUserTime(travel.GetTimeTravelled(alphaCentauri.GetDistanceToEarth(), warpSpeed));
        //                        player.SetCurrentLocation(earth.GetPlanetName());
        //                        travelled = true;
        //                    }
        //                    break;
        //                case 2:
        //                    Console.WriteLine(gliese.GetPlanetName());
        //                    do
        //                    {
        //                        Console.Write(
        //                            ("Please enter your warp speed. Your ship can travel at a max warp speed of " +
        //                             $"{currentShip.GetMaxWarpSpeed()}: "));
        //                        warpSpeed = GetInput();
        //                    } while (warpSpeed < 0 || warpSpeed > currentShip.GetMaxWarpSpeed());

        //                    if (warpSpeed != 0)
        //                    {
        //                        player.SetUserTime(travel.GetTimeTravelled(alphaCentauri.GetDistanceToGliese(),
        //                            warpSpeed));
        //                        player.SetCurrentLocation(gliese.GetPlanetName());
        //                        travelled = true;
        //                    }

        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine(
        //                $"You can travel to \n1. {alphaCentauri.GetPlanetName()}\t Distance from {player.GetCurrentLocation()}: {gliese.GetDistanceToAlphaCentauri()}" +
        //                $"\n2. {earth.GetPlanetName()}\t\t Distance from {player.GetCurrentLocation()}: {gliese.GetDistanceToEarth()}" +
        //                $"\n0. return to previous menu");
        //            choice = GetInput();
        //            Console.WriteLine("You have selected to travel to ");
        //             switch (choice)
        //            {
        //                case 1:
        //                    Console.WriteLine(alphaCentauri.GetPlanetName());
        //                    do
        //                    {
        //                        Console.Write(
        //                            ("Please enter your warp speed. Your ship can travel at a max warp speed of " +
        //                             $"{currentShip.GetMaxWarpSpeed()}: "));
        //                        warpSpeed = GetInput();
        //                    } while (warpSpeed < 0 || warpSpeed > currentShip.GetMaxWarpSpeed());

        //                    if (warpSpeed != 0)
        //                    {
        //                        player.SetUserTime(travel.GetTimeTravelled(gliese.GetDistanceToAlphaCentauri(),
        //                            warpSpeed));
        //                        player.SetCurrentLocation(alphaCentauri.GetPlanetName());
        //                        travelled = true;
        //                    }

        //                    break;
        //                case 2:
        //                    Console.WriteLine(earth.GetPlanetName());
        //                    do
        //                    {
        //                        Console.Write(
        //                            ("Please enter your warp speed. Your ship can travel at a max warp speed of " +
        //                             $"{currentShip.GetMaxWarpSpeed()}: "));
        //                        warpSpeed = GetInput();
        //                    } while (warpSpeed < 0 || warpSpeed > currentShip.GetMaxWarpSpeed());

        //                    if (warpSpeed != 0)
        //                    {
        //                        player.SetUserTime(travel.GetTimeTravelled(gliese.GetDistanceToEarth(), warpSpeed));
        //                        player.SetCurrentLocation(earth.GetPlanetName());
        //                        travelled = true;
        //                    }

        //                    break;
        //            }
        //        }
        //    }while(choice<0||choice>2);

        //    return travelled;
        //}

      
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
