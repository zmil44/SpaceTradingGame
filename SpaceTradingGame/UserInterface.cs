using System;
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
        }


    }
}
