﻿using System;
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
        private void setStory()
        {
            _story = File.ReadAllLines("SpaceTradingGameStory.txt");
        }

        private void DisplayStory()
        {
            foreach (var word in _story)
            {
                Console.Write(word);
            }
        }
    }
}
