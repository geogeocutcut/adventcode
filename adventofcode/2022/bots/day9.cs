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
    public class BotDay9:IBot
    {
        public List<position> positions = new List<position>();
        Dictionary<string, position> map = new Dictionary<string, position>();
        const int size = 10;
        public position[] serpent = new position[size];
        public void LoadData()
        {
            string path = @"./2022/inputs/day9.txt";
            var newpos = new position
            {
                x = 0,
                y = 0,
                isVisited = true
            };
            positions.Add(newpos);
            map.Add(newpos.ToString(), newpos);
            for(int l = 0; l<size;l++)
            {
                serpent[l] = newpos;
            }
            foreach (string line in System.IO.File.ReadLines(path))
            {
                var move = line.Split(' ');
                var dist = int.Parse(move[1]);
                for(int i = 0; i < dist;i++)
                {
                    for (int s= 0; s<size;s++)
                    {
                        if (s == 0) serpent[s] = ComputeNext(serpent[0], move[0]);
                        else
                        {
                            if(serpent[s].distance(serpent[s - 1])>=2)
                            {
                                serpent[s] = FollowHead(serpent[s], serpent[s - 1]);
                                if (s == size - 1) serpent[s].isVisited = true;
                            }
                        }
                    }
                }
            }
        }

        private position FollowHead(position posInit,position posHead)
        {
            var pos = new position
            {
                x = posInit.x == posHead.x ? posInit.x: posInit.x+(posHead.x - posInit.x) / Math.Abs(posHead.x - posInit.x),
                y = posInit.y == posHead.y ? posInit.y: posInit.y+(posHead.y - posInit.y) / Math.Abs(posHead.y - posInit.y)
            };
            if (!map.ContainsKey(pos.ToString()))
            {
                map[pos.ToString()] = pos;
                positions.Add(pos);
            }
            return map[pos.ToString()];
        }

        private position ComputeNext(position pos, string v)
        {
            int x = pos.x;
            int y = pos.y;
            switch(v)
            {
                case "L":
                    x -= 1;
                    break;

                case "R":
                    x += 1;
                    break;

                case "U":
                    y -= 1;
                    break;

                case "D":
                    y += 1;
                    break;
            }
            var postmp = new position
            {
                x = x,
                y = y
            };
            if (!map.ContainsKey(postmp.ToString()))
            {
                map[postmp.ToString()]=postmp;
                positions.Add(postmp);
            }
            return map[postmp.ToString()];
        }

        public void Excute()
        {
            Console.WriteLine(positions.Count(p => p.isVisited));
        }

    }


    public class position
    {
        public int x { get; set; }
        public int y { get; set; }
        public bool isVisited { get; set; }
        public double distance(position pos)
        {
            return Math.Sqrt((x - pos.x) * (x - pos.x) + (y - pos.y) * (y - pos.y));
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(this, obj)) return true;
            var pos = obj as position;
            if (pos == null) return false;
            if (pos.x == this.x && pos.y == this.y) return true;
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public override string ToString()
        {
            return x+"_"+y;
        }
    }
}
