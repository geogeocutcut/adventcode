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
        List<char> window = new List<char>(14);
        HashSet<char> check = new HashSet<char>();
        int count = 14;
        public void LoadData()
        {
            string path = @"./2022/inputs/day6.txt";
            foreach (string line in System.IO.File.ReadLines(path))
            {
                var length = line.Length;
                var marker = line.Substring(0, 14);
                window=marker.ToList();
                for (int i=14; i<length; i++)
                {
                    check = new HashSet<char>(window);
                    Console.Write(check.Count);
                    if (check.Count == 14)
                        break;
                    window.RemoveAt(0);
                    window.Add(line[i]);
                    count += 1;
                }
            }
        }

        public void Excute()
        {

        }
    }
}
