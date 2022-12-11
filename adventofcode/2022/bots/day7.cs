using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode._2022.bots
{
    public class BotDay7:IBot
    {
        node rootNode = new node()
        {
            name="root",
            typeNode='R'
        };
        List<node> nodes = new List<node>();
        
        public void LoadData()
        {
            string path = @"./2022/inputs/day7.txt";
            nodes.Add(rootNode);
            node currentNode = rootNode;
            foreach (string line in System.IO.File.ReadLines(path))
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    // action
                    if (line[0] == '$')
                    {
                        var cmd = line.Substring(2).Split(' ');
                        if (cmd[0] == "cd")
                        {
                            if(cmd[1] == "/")
                            {
                                currentNode = rootNode;
                            }
                            else if(cmd[1] == "..")
                            {
                                if(currentNode.parent != null)
                                    currentNode = currentNode.parent;
                            }
                            else
                            {
                                if(currentNode.children.TryGetValue(cmd[1],out node tmp))
                                {
                                    currentNode = tmp;
                                }
                            }
                        }
                    }
                    else 
                    {
                        var infos = line.Split(' ');
                        if (infos[0]=="dir")
                        {
                            var newNode = new node
                            {
                                name = infos[1],
                                parent = currentNode,
                                typeNode = 'R',
                            };
                            nodes.Add(newNode);
                            currentNode.children[newNode.name]=newNode;
                        }
                        else if (int.TryParse(infos[0], out int w))
                        {
                            var newNode = new node
                            {

                                name = infos[1],
                                parent = currentNode,
                                typeNode = 'F',
                            };
                            nodes.Add(newNode);
                            currentNode.children[newNode.name] = newNode;
                            newNode.weight = w;
                        }
                    }
                }

            }
        }

        public void Excute()
        {
            var sizeToFound = rootNode.weight - 40000000;
            Console.WriteLine(nodes.Where(n=> n.typeNode=='R' && n.weight<100000).Sum(n=>n.weight));
            Console.WriteLine(nodes.Where(n => n.typeNode == 'R' && n.weight > sizeToFound).OrderBy(n => n.weight).FirstOrDefault().weight);
        }
    }

    public class node
    {
        public string name { get; set; }
        public char typeNode { get; set; } // R | F
        public node parent { get; set; }
        public Dictionary<string,node> children = new Dictionary<string, node>();
        public long _weight;
        public long weight {
            get
            {
                return _weight;
            } 
            set
            {
                _weight += value;
                if(parent != null)
                    parent.addWeight(value);
            } 
        }

        private void addWeight(long value)
        {
            _weight += value;
            if (parent != null)
                parent.addWeight(value);
        }

    }
}
