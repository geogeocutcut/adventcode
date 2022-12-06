using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode._2022.bots
{
    public class BotDay3:IBot
    {
        int score;
        public void LoadData()
        {
            string path = @"./2022/inputs/day3.txt";
            foreach (string line in System.IO.File.ReadLines(path))
            {
                var demilength = line.Length / 2;
                var comp1 = line.Substring(0, demilength).OrderBy(x=>x).ToList();
                var comp2 = line.Substring(demilength).OrderBy(x => x).ToList();
                var comp2length = demilength - 1;
                var kcontinue = true;
                for (int i= demilength-1; i>=0;i--)
                {
                    for (int j = comp2length; j >= 0; j--)
                    {
                        if (comp1[i] == comp2[j])
                        {
                            score += getScore(comp1[i]);
                            comp2.RemoveAt(j);
                            comp2length-=1;
                            kcontinue = false;
                        }
                        if (!kcontinue) break;
                    }
                    if (!kcontinue) break;
                }

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
