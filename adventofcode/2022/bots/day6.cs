using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode._2022.bots
{
    public class BotDay6:IBot
    {
        HashSet<char> window = new HashSet<char>(4);
        int maxtmp = 0;
        public void LoadData()
        {
            string path = @"./2022/inputs/day1.txt";
            foreach (string line in System.IO.File.ReadLines(path))
            {
                var length = line.Length;
                var marker = line.Substring(0, 4);
                window=marker.ToHashSet();
                for (int i=4; i<length; i++)
                {
                    if(window.Count<4)
                    {
                        window.Add()
                    }
                }
            }
        }

        public void Excute()
        {
            Console.WriteLine(elvesCal.OrderByDescending(x=>x).Take(3).Sum());
        }

    }
}
