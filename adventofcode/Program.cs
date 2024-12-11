using adventofcode._2022.bots;
using adventofcode._2024._05;
using System;

namespace adventofcode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IBot bot = new Day5a();
            bot.LoadData();
            bot.Excute();
        }
    }
}
