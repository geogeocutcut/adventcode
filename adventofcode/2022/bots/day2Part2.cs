using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode._2022.bots
{
    public class BotDay2Part2:IBot
    {
       
        int score = 0;
        public void LoadData()
        {
            string path = @"./2022/inputs/day2.txt";
            foreach (string line in System.IO.File.ReadLines(path))
            {

                score += Evaluate(line[0], line[2]);

            }
        }

        private int Evaluate(char op, char str)
        {
            char my='X';
            switch(str)
            {
                case 'X': // loose
                    my = op == 'A' ? 'Z' : op == 'B' ? 'X' : 'Y';
                    break; 
                case 'Y': // draw
                    my = op == 'A' ? 'X' : op == 'B' ? 'Y' : 'Z';
                    break;
                case 'Z': // win
                    my = op == 'A' ? 'Y' : op == 'B' ? 'Z' : 'X';
                    break;
            }



            var score = my == 'X' ? 1 : my == 'Y' ? 2 : 3;
            if ((op == 'A' && my == 'X') || (op == 'B' && my == 'Y')  || (op == 'C' && my == 'Z'))
                score += 3;
            else if ((op == 'A' && my == 'Y') || (op == 'B' && my == 'Z') || (op == 'C' && my == 'X'))
                score += 6;

            return score;
        }

        public void Excute()
        {
            Console.WriteLine(score);
        }

    }
}
