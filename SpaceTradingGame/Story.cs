using System;
using System.IO;


namespace SpaceTradingGame
{
    internal class Story
    {
        
        public Story()
        {
            var story = File.ReadAllLines("SpaceTradingGameStory.txt");
            foreach (var word in story)
            {
                Console.WriteLine(word);
            }
        }

    }
}
