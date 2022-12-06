using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode._2022.bots
{
    public class BotDay4 : IBot
    {
        int countContains = 0;
        int countOverlap = 0;
        public void LoadData()
        {
            string path = @"./2022/inputs/day4.txt";
            foreach (string line in System.IO.File.ReadLines(path))
            {
                //26 - 94,26 - 94
                var inter1 = line.Split(',')[0];
                var inter2 = line.Split(',')[1];

                var borneInfInter1 = int.Parse(inter1.Split('-')[0]);
                var borneSupInter1 = int.Parse(inter1.Split('-')[1]);
                var borneInfInter2 = int.Parse(inter2.Split('-')[0]);
                var borneSupInter2 = int.Parse(inter2.Split('-')[1]);
                if (borneInfInter1 <= borneInfInter2 && borneSupInter2 <= borneSupInter1)
                    countContains += 1;
                else if(borneInfInter2 <= borneInfInter1 && borneSupInter1 <= borneSupInter2)
                    countContains += 1;
                if (borneInfInter1 <= borneInfInter2 && borneSupInter1 >= borneInfInter2)
                    countOverlap += 1;
                else if (borneInfInter2 <= borneInfInter1 && borneSupInter2 >= borneInfInter1)
                    countOverlap += 1;

            }
        }

        public void Excute()
        {
            Console.WriteLine(countContains);
            Console.WriteLine(countOverlap);
        }

    }
}
