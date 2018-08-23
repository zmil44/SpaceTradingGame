using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaceTradingGame
{
    class Story
    {
        private string[] _story;

        public Story()
        {
            _story = File.ReadAllLines("SpaceTradingGameStory.txt");
            foreach (var word in _story)
            {
                Console.WriteLine(word);
            }
        }

    }
}
