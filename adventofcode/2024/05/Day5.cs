using adventofcode._2022.bots;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace adventofcode._2024._05
{
    public class Day5a: IBot
    {
        List<(int,int)> _rules = new List<(int, int)>();

        List<List<int>> _factories = new List< List<int>>();
        public void LoadData()
        {
            string path = @"./2024/05/Day5a.txt";
            foreach (string line in System.IO.File.ReadLines(path))
            {
                if (string.IsNullOrEmpty(line)) continue;
                if(line.Contains('|'))
                {
                    var number = line.Split('|').Select(int.Parse).ToArray();
                    _rules.Add((number[0], number[1]));
                }
                else
                {
                    var fact = line.Split(',').Select(int.Parse).ToList();
                    _factories.Add(fact);
                }
            }
        }
        public void Excute()
        {
            var goodFactory = 0;
            foreach(var fact in _factories)
            {
                if(IsValidUpdate(fact))
                {
                    goodFactory+= FindMiddlePage(fact);
                }
            }
            Console.WriteLine(goodFactory);
        }
        private bool IsValidUpdate(List<int> pages)
        {
            var pageIndex = pages.Select((page, index) => (page, index)).ToDictionary(p => p.page, p => p.index);

            foreach (var (X, Y) in _rules)
            {
                if (pageIndex.ContainsKey(X) && pageIndex.ContainsKey(Y))
                {
                    if (pageIndex[X] >= pageIndex[Y])
                        return false;
                }
            }

            return true;
        }

        private int FindMiddlePage(List<int> pages)
        {
            int middleIndex = pages.Count / 2;
            return pages[middleIndex];
        }
    }


    
}
