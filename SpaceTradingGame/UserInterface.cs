using System;

namespace SpaceTradingGame
{
    class UserInterface
    {
        public  UserInterface()
        {
            Random rand = new Random();
            //create and display story
            var story = new Story();

            //create goods
            var goods = CreateGoods();

            //Create ships
            var ships = CreateShips();

            //Create Planets
            var planets = CreatePlanets(rand);

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
            bool exit;
            player.SetCurrentPlanet(planets[0]);
            string exitMessage="";
            do
            {
                var goodsQuantity = player.GetCurrentInventoryQuantities();
                int choice;
                Console.Clear();
                player.CalculateYears();
                exit = CheckExitCondition(player);
                if (exit)
                {
                    exitMessage = GetExitMessage(player);
                    break;
                }
                if (travelMenu.hasTravelled)
                {
                    SetRandomGoodsPrice(goods, rand, travelMenu);
                }
                
                do
                {

                    Console.Clear();
                    choice = DisplayMainMenu(player, currentShip);
                } while (choice < -1 || choice > 5 || choice == 0);

                switch (choice)
                {
                    case -1:
                        exitMessage = "You have decided to retire.";
                        exit = true;
                        break;
                    case 1:
                        Console.Clear();
                        buyMenu.DisplayBuyMenu(player, goods);
                        Console.WriteLine(buyMenu.CheckBuy(player, goods));
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        sellMenu.DisplaySellMenu(player, goods);
                        Console.WriteLine(SellMenu.CheckSell(player, goods,goodsQuantity));
                        Console.ReadLine();
                        break;
                    case 3:
                        Console.Clear();
                        var options = travelMenu.DisplayTravelMenu(player, planets,currentShip);
                        choice = travelMenu.GetPlanetChoice(options);
                        Console.WriteLine(travelMenu.TryTravel(choice,currentShip,player,planets, travel));
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        buyShipMenu.DisplayBuyShipMenu(player, ships, currentShip);
                        Console.WriteLine(BuyShipMenu.TryBuyShip(player,currentShip,ships));
                        Console.ReadLine();
                        break;
                    case 5:
                        Console.Clear();
                        currentShip.RefuelShip(player, currentShip);
                        break;
                }
            } while (exit == false);
            story.DisplayEnd(player,exitMessage);
        }

        static int DisplayMainMenu(User player, Ship currentShip)
        {
            Console.WriteLine(
                $"You have {player.GetCredits()} and have travelled for {player.GetUserTimeInYears()} years and {player.GetUserDays()} days");
            Console.WriteLine($"You are currently on {player.GetCurrentPlanet().GetPlanetName()} and have {currentShip.currentFuelLevel} units of fuel");
            Console.WriteLine("What would you like to do? \n Enter the corresponding number to decide. \n" +
                              "1. Buy \n2. Sell\n3. Travel\n4. Buy new ship\n5. Refuel Ship\n-1. Quit");
            return GetInput();
        }
        private void SetRandomGoodsPrice(Goods[] goods, Random rand,TravelMenu travelMenu)
        {
            goods[1].SetPriceOfGood(rand.Next(1, 4500));
            goods[2].SetPriceOfGood(rand.Next(1, 3000));
            goods[3].SetPriceOfGood(rand.Next(1, 200));
            goods[4].SetPriceOfGood(rand.Next(1, 500));
            goods[5].SetPriceOfGood(rand.Next(1, 250));
            goods[6].SetPriceOfGood(rand.Next(1, 100));
            goods[7].SetPriceOfGood(rand.Next(100000, 400000));
            travelMenu.hasTravelled = false;
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

        static Planet[] CreatePlanets(Random rand)
        {
            Planet[] planet = new Planet[rand.Next(100, 250)];
            planet[0] = new Planet("Earth", "Mace Windu", 0, 0);
            for (int i = 1; i < planet.Length; i++)
            {
                int planetNumber = rand.Next(1, 500);
                planet[i] = new Planet($"Planet{planetNumber}", $"Trader{planetNumber}",
                    (rand.Next(-50, 50)+rand.NextDouble()),
                    (rand.Next(-50, 50)+rand.NextDouble()));
            }
            return planet;
        }

        static bool CheckExitCondition(User player)
        {
            if (player.GetUserTimeInYears() >= 40 || (player.GetCredits() == 0 && player.GetCurrentCargo().Count == 0))
            {
                Console.Clear();

                return true;
            }
            return false;
        }

        static string GetExitMessage(User player)
        {
            string exitMessage;
            if (player.GetUserTimeInYears() >= 40)
            {
                exitMessage = ("You have travelled for over 40 years");
            }
            else
            {
                exitMessage = ("You ran out of credits and goods to sell");
            }
            return exitMessage;
        }
        public static int GetInput()
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
                catch (OverflowException)
                {
                    Console.WriteLine("You entered an incorrect number. Please try again.");
                    badInput = true;
                }
            } while (badInput);
            return choice;
        }

        public static void DisplayInventory(User player,int[] goodsQuantity)
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
