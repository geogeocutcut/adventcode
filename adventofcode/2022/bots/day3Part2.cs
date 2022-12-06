using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace adventofcode._2022.bots
{
    public class BotDay3Part2:IBot
    {
        int score;
        public void LoadData()
        {
            string path = @"./2022/inputs/day3.txt";
            var comp = new List<char>[3];
            int k = 1;
            foreach (string line in System.IO.File.ReadLines(path))
            {
                int i = (k - 1) % 3;
                comp[i] = line.OrderBy(x => x).ToList(); ;
                if (k % 3 == 0)
                {
                    var kcontinue = true;
                    foreach (var c0 in comp[0])
                    {
                        foreach (var c1 in comp[1])
                        {
                            foreach (var c2 in comp[2])
                            {
                                if (c0 == c1 && c1 == c2)
                                {
                                    score += getScore(c0);
                                    kcontinue = false;
                                }
                                if (!kcontinue) break;
                            }
                            if (!kcontinue) break;
                        }
                        if (!kcontinue) break;
                    }
                }
                k++;
            }
        }

        private int getScore(char v)
        {
            var init = v == char.ToUpper(v) ? 27 : 1;
            return init+ char.ToUpper(v) - 'A';
        }

        public void Excute()
        {
            Console.WriteLine(score);
        }

    }
}
