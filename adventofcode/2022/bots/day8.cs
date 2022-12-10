using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode._2022.bots
{
    public class BotDay8:IBot
    {
        
        public void LoadData()
        {
            string path = @"./2022/inputs/day8tst.txt";
            int maxLeft = 0;
            Dictionary<int, int> maxTop = new Dictionary<int, int>() ;
            Dictionary<int,Dictionary<int,node>> MapXY = new Dictionary<int,Dictionary< int,node >> ();
            Dictionary<int, Dictionary<int, node>> MapYX = new Dictionary<int, Dictionary<int, node>>();

            int i = 0;
            foreach (string line in System.IO.File.ReadLines(path))
            {
                maxLeft = -1;
                maxTop[i] = -1;
                int j = 0;
                foreach (var c in line)
                {
                    var h = int.Parse(c.ToString());
                    var node = new node
                    {
                        height = int.Parse(c.ToString()),
                        isVisible = maxLeft < h || maxTop[i] < h
                    };
                    MapXY[j][i] = node;
                    MapYX[i][j] = node;
                    if (maxLeft < h) maxLeft = h;
                    if (maxTop[i] < h) maxTop[i] = h;
                    j++;
                }
                i++;
            }
        }

        public void Excute()
        {
        }

    }

    public class node
    {
        public int height { get; set; }
        public bool isVisible { get; set; }
    }
}
