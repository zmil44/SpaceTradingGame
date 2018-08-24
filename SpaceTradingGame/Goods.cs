
namespace SpaceTradingGame
{
    class Goods
    {
        private readonly string _nameOfGood;
        private int _priceOfGood;

        public Goods(string name, int price)
        {
            _nameOfGood = name;
            _priceOfGood = price;
        }

        public string GetNameOfGood()
        {
            return _nameOfGood;
        }

        public int GetPriceOfGood()
        {
            return _priceOfGood;
        }

        public void SetPriceOfGood(int price)
        {
            _priceOfGood = price;
        }

    }
}
