using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day14
{
    class Program
    {
        static string sequence = null;
        static readonly Dictionary<string, string> polymerTemplate = new Dictionary<string, string>();
        static Dictionary<string, long> currentPolymers = new Dictionary<string, long>();
        static Dictionary<string, long> newPolymers;
        static readonly Dictionary<string, long> elementCount = new Dictionary<string, long>();

        static void Main()
        {
            foreach (var line in File.ReadLines("input"))
            {
                if (line.Contains("->"))
                {
                    var x = line.Split(" -> ");
                    polymerTemplate.Add(x[0], x[1]);
                }
                else if (!string.IsNullOrEmpty(line))
                {
                    sequence = line;
                }
            }

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                var polymer = sequence.Substring(i, 2);
                AddPolymer(polymer, currentPolymers);
            }

            for (var step = 0; step < 40; step++)
            {
                newPolymers = new Dictionary<string, long>();
                foreach (var item in currentPolymers)
                {
                    AddPolymer(item.Key[0] + polymerTemplate[item.Key], newPolymers, item.Value);
                    AddPolymer(polymerTemplate[item.Key] + item.Key[1], newPolymers, item.Value);
                }
                currentPolymers = newPolymers;
            }

            foreach (var item in currentPolymers)
            {
                AddPolymer($"{item.Key[0]}", elementCount, item.Value);
                AddPolymer($"{item.Key[1]}", elementCount, item.Value);
            }
            var result = elementCount.OrderBy(e => e.Value).Last().Value - elementCount.OrderBy(e => e.Value).First().Value;
            Console.WriteLine($"{result / 2}");
        }

        private static void AddPolymer(string polymer, Dictionary<string, long> polymerDict, long count = 1)
        {
            if (!polymerDict.ContainsKey(polymer))
            {
                polymerDict.Add(polymer, 0);
            }
            polymerDict[polymer] += count;
        }
    }
}
