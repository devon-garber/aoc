using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Aoc
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> input = System.IO.File.ReadLines("input7.1.txt");

            int goldBagTotalHold = FindInnerHeldCount("shiny gold bag", input.ToList());

            Console.WriteLine(goldBagTotalHold);
        }

        private static string FindLine(string lineStart, List<string> input)
        {
            foreach (string line in input)
            {
                if (line.StartsWith(lineStart))
                {
                    return line;
                }
            }
            return ""; // Won't happen
        }

        private static int FindInnerHeldCount(string bagType, List<string> input)
        {
            string line = FindLine(bagType, input);
            if (line.Contains("no other"))
            {
                return 0;
            }

            int innerBagCount = 0;
            string innerBagLine = line.Split("contain").Skip(1).First().Trim();
            foreach (string bagDesc in innerBagLine.Split(','))
            {
                int bagCount = Int32.Parse(bagDesc.Substring(0, 2));
                innerBagCount += bagCount;
                string bag = bagDesc.Substring(2).Replace('.', ' ').Trim();
                innerBagCount += bagCount * FindInnerHeldCount(bag, input.ToList());
            }
            return innerBagCount;
        }
    }
}