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
            int allYesAnswers = 0;

            StringBuilder fullGroup = new StringBuilder();
            int groupSize = 0;
            foreach (string line in input)
            {
                if (line == string.Empty)
                {
                    // Solve
                    string groupAnswers = fullGroup.ToString();
                    allYesAnswers += AllYes(groupAnswers, groupSize);
                    groupSize = 0;
                    fullGroup.Clear();
                }
                else
                {
                    groupSize++;
                    fullGroup.Append(line);
                }
            }

            allYesAnswers += AllYes(fullGroup.ToString(), groupSize); // Also the last group

            Console.WriteLine(allYesAnswers);
        }

        private static int AllYes(string groupAnswers, int groupSize)
        {
            int allYes = 0;
            foreach (char c in groupAnswers.Distinct())
            {
                if (groupAnswers.Count(x => x == c) == groupSize)
                {
                    allYes++;
                }
            }
            return allYes;
        }
    }
}
