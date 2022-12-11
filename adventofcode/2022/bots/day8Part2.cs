using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace adventofcode._2022.bots
{
    public class BotDay8Part2:IBot
    {

        List<node3> nodes = new List<node3>();
        public void LoadData()
        {
            string path = @"./2022/inputs/day8.txt";
            int i = 0;
            int j = 0;
            Dictionary<int, Dictionary<int, node3>> MapXY = new Dictionary<int, Dictionary<int, node3>>();
            foreach (string line in System.IO.File.ReadLines(path))
            {
                j = 0;
                foreach (var c in line)
                {
                    
                    var h = int.Parse(c.ToString());
                    var node = new node3
                    {
                        height = int.Parse(c.ToString()),
                        score = 0
                    };
                    if (!MapXY.ContainsKey(j)) MapXY[j] = new Dictionary<int, node3>();
                    MapXY[j][i] = node;
                    nodes.Add(node);

                    node.neighbour[0] = MapXY.ContainsKey(j - 1) ? MapXY[j - 1][i] : null;
                    if (node.neighbour[0] != null) node.neighbour[0].neighbour[2] = node;
                    node.neighbour[1] = MapXY[j].ContainsKey(i - 1) ? MapXY[j][i - 1] : null;
                    if (node.neighbour[1] != null) node.neighbour[1].neighbour[3] = node;
                    j++;
                }
                i++;
            }
        }

        public void Excute()
        {
            Console.WriteLine(nodes.OrderByDescending(x=>x.getScore()).FirstOrDefault().score);
        }

    }

    public class node3
    {
        public int height { get; set; }
        public int score { get; set; }

        public int getScore()
        {
            score = getScoreLeft(height) * getScoreTop(height) * getScoreRight(height) * getScoreBottom(height);
            return score;
        }

        public int getScoreBottom(int h)
        {
            var score = 0;
            if (neighbour[3] != null)
            {
                score++;
                if (neighbour[3].height < h)
                {
                    score += neighbour[3].getScoreBottom(h);
                }
            }
            return score;
        }

        public int getScoreRight(int h)
        {
            var score = 0;
            if (neighbour[2] != null)
            {
                score++;
                if (neighbour[2].height < h)
                {
                    score += neighbour[2].getScoreRight(h);
                }
            }
            return score;
        }

        public int getScoreTop(int h)
        {
            var score = 0;
            if (neighbour[1] != null)
            {
                score++;
                if (neighbour[1].height < h)
                {
                    score += neighbour[1].getScoreTop(h);
                }
            }
            return score;
        }

        public int getScoreLeft(int h)
        {
            var score = 0;
            if (neighbour[0] != null) 
            {
                score++;
                if (neighbour[0].height<h)
                {
                    score += neighbour[0].getScoreLeft(h);
                }
            }
            return score;
        }

        public node3[] neighbour = new node3[4]; 
    }
}
