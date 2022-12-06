using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode._2022.bots
{
    public class BotDay5Part2:IBot
    {
        int length = 0;
        int nbrang = 0;
        Stack<char>[] caisses;
        Stack<char>[] caissesTmp;
        public void LoadData()
        {
            string path = @"./2022/inputs/day5.txt";
            var mode = 1;
            foreach (string line in System.IO.File.ReadLines(path))
            {
                if(length==0)
                {
                    length = line.Length;
                    nbrang = (length + 1) / 4;
                    caisses = new Stack<char>[nbrang];
                    caissesTmp = new Stack<char>[nbrang];
                    for (int i = 0; i < nbrang; i++)
                    {
                        caissesTmp[i] = new Stack<char>();
                        caisses[i] = new Stack<char>();
                    }
                }
                if (mode == 1)
                {
                    if (line[1] == '1')
                    {
                        mode = 2;
                        for(int i = 0; i < nbrang; i++)
                        {
                            while (caissesTmp[i].Count != 0)
                            {
                                caisses[i].Push(caissesTmp[i].Pop());
                            }
                        }
                    }
                    else
                    {
                        int rang = 0;
                        for (int i = 1; i < length; i += 4)
                        {
                            if (line[i] != ' ')
                                caissesTmp[rang].Push(line[i]);
                            rang++;
                        }
                    }
                }
                else
                {
                    if(!string.IsNullOrWhiteSpace(line))
                    {
                        var move = line.Split(' ');
                        var nb = int.Parse(move[1]);
                        var from = int.Parse(move[3])-1;
                        var to = int.Parse(move[5])-1;
                        var tampon = new Stack<char>();
                        for (int m=0;m<nb;m++)
                        {
                            tampon.Push(caisses[from].Pop());
                        }
                        for (int m = 0; m < nb; m++)
                        {
                            caisses[to].Push(tampon.Pop());
                        }
                    }
                }
            }
        }

        public void Excute()
        {
            foreach(var c in caisses)
            {
                Console.Write(c.Pop());
            }
        }

    }
}
