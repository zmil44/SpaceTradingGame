
namespace SpaceTradingGame
{
    class Goods
    {
        private readonly string _nameOfGood;
        private decimal _priceOfGood;

        public Goods(string name, decimal price)
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
