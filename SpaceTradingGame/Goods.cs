using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class Goods
    {
        private string _nameOfGood;
        private decimal _priceOfGood;
        private double _weightOfGoodInPounds;

        public void CreateGood(string name, decimal price, double weight)
        {
            _nameOfGood = name;
            _priceOfGood = price;
            _weightOfGoodInPounds = weight;
        }

        public string GetNameOfGood()
        {
            return _nameOfGood;
        }

        public decimal GetPriceOfGood()
        {
            return _priceOfGood;
        }

        public void SetPriceOfGood(decimal price)
        {
            _priceOfGood = price;
        }

        public double GetWeightOfGood()
        {
            return _weightOfGoodInPounds;
        }
    }
}
