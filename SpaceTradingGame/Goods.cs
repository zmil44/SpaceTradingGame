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

        private void CreateGood(string name, decimal price, double weight)
        {
            _nameOfGood = name;
            _priceOfGood = price;
            _weightOfGoodInPounds = weight;
        }

        private string GetNameOfGood()
        {
            return _nameOfGood;
        }

        private decimal GetPriceOfGood()
        {
            return _priceOfGood;
        }

        private void SetPriceOfGood(decimal price)
        {
            _priceOfGood = price;
        }

        private double GetWeightOfGood()
        {
            return _weightOfGoodInPounds;
        }
    }
}
