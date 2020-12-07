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
            IEnumerable<string> input = System.IO.File.ReadLines("input6.1.txt");
            int totalUniqueAnswers = 0;

            StringBuilder fullGroup = new StringBuilder();
            foreach (string line in input)
            {
                if (line == string.Empty)
                {
                    // Solve
                    string groupAnswers = fullGroup.ToString();
                    totalUniqueAnswers += groupAnswers.Distinct().Count();
                    fullGroup.Clear();
                }
                fullGroup.Append(line);
            }

            totalUniqueAnswers += fullGroup.ToString().Distinct().Count(); // Also the last group

            Console.WriteLine(totalUniqueAnswers);
        }
    }
}
