using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode._2022.bots
{
    public class BotDay8:IBot
    {

        List<node2> nodes = new List<node2>();
        public void LoadData()
        {
            string path = @"./2022/inputs/day8.txt";
            int maxLeft = 0;
            Dictionary<int, int> maxTop = new Dictionary<int, int>() ;
            Dictionary<int,Dictionary<int, node2>> MapXY = new Dictionary<int,Dictionary< int, node2>> ();
            Dictionary<int, Dictionary<int, node2>> MapYX = new Dictionary<int, Dictionary<int, node2>>();
            int i = 0;
            int j = 0;

            foreach (string line in System.IO.File.ReadLines(path))
            {
                maxLeft = -1;
                j = 0;
                foreach (var c in line)
                {
                    if(i==0)
                    {
                        maxTop[j] = -1;
                    }
                    var h = int.Parse(c.ToString());
                    var node = new node2
                    {
                        height = int.Parse(c.ToString()),
                        isVisible = maxLeft < h || maxTop[j] < h
                    };
                    if (!MapXY.ContainsKey(j)) MapXY[j] = new Dictionary<int, node2>();
                    MapXY[j][i] = node;
                    if (!MapYX.ContainsKey(i)) MapYX[i] = new Dictionary<int, node2>();
                    MapYX[i][j] = node;
                    nodes.Add(node);
                    if (maxLeft < h) maxLeft = h;
                    if (maxTop[j] < h) maxTop[j] = h;
                    j++;
                }
                i++;
            }

            int maxRight = 0;
            Dictionary<int, int> maxBottom = new Dictionary<int, int>();
            for (int k=i-1;k>=0;k--)
            {
                maxRight = -1;
                for (int l=j-1;l>=0;l--)
                {
                    if(k== i - 1)
                    {
                        maxBottom[l] = -1;
                    }
                    MapXY[l][k].isVisible = MapXY[l][k].isVisible || maxRight < MapXY[l][k].height || maxBottom[l] < MapXY[l][k].height;

                    if (maxRight < MapXY[l][k].height) maxRight = MapXY[l][k].height;
                    if (maxBottom[l] < MapXY[l][k].height) maxBottom[l] = MapXY[l][k].height;
                }
            }
        }

        public void Excute()
        {
            Console.WriteLine(nodes.Count(n => n.isVisible));
        }

    }

    public class node2
    {
        public int height { get; set; }
        public bool isVisible { get; set; }
    }
}
