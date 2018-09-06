using System;
using System.IO;


namespace SpaceTradingGame
{
    internal class Story
    {
        
        public Story()
        {
            Console.WriteLine("It is the year 2518 and you have just turned 24 years old. After graduating from the Space Pilot Academy, " +
                              "\nyou have decided to travel the stars and trade with people from different planets. Your parents have been " +
                              "\nsupportive of your decision and have given you a ship and 25,000 credits to start your journey. " +
                              "\nYour ship is a Simiyar - Class Light Frieghter, has a maximum storage of 50 goods, and has a max warp speed of 3. " +
                              "\nYour goal is to earn as many credits as possible after travelling for 40 years. Good luck, and may the force be with you!");
        }

        public void DisplayEnd(User player, string exitMessage)
        {
            var netIncome = player.GetCredits() - 25000;
            Console.WriteLine(exitMessage);
            Console.WriteLine($"Over the course of your career, you have travelled for {player.GetUserTimeInYears()}" +
                              $" years and {player.GetUserDays()} days. \nYou started with 25,000 credits and you ended with {player.GetCredits()}" +
                              $" credits with a net income of {netIncome} credits.");
            Console.Read();
        }

    }
}
