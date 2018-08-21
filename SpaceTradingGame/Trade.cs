using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceTradingGame
{
    class Trade
    {
        public string[] buy(string goodName, int quantity)
        {
            string[] bought = new string[quantity];

            for (int i = 0; i < quantity; i++)
            {
                bought[i] = goodName;
            }

            return bought;
        }

        public string[] sell(string goodName, int quantity)
        {
            string[] sold = new string[quantity];
            for (int i = 0; i < quantity; i++)
            {
                sold[i] = goodName;
            }

            return sold;
        }
    }
}
