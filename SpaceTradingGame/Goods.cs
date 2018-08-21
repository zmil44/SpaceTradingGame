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
        

        public void CreateGood(string name, decimal price)
        {
            _nameOfGood = name;
            _priceOfGood = price;
            
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

    }
}
