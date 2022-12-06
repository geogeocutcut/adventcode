using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode._2022.bots
{
    public class BotDay1:IBot
    {
        List<int> elvesCal = new List<int>();
        int maxtmp = 0;
        public void LoadData()
        {
            string path = @"./2022/inputs/day1.txt";
            foreach (string line in System.IO.File.ReadLines(path))
            {
                if (string.IsNullOrEmpty(line))
                {
                    elvesCal.Add(maxtmp);
                    maxtmp = 0;
                }
                else
                {
                    maxtmp+=int.Parse(line);
                }

            }
        }

        public void Excute()
        {
            Console.WriteLine(elvesCal.OrderByDescending(x=>x).Take(3).Sum());
        }

    }
}
