using adventofcode._2022.bots;
using System;

namespace adventofcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IBot bot = new BotDay8();
            bot.LoadData();
            bot.Excute();
        }
    }
}
