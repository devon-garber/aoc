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
            IEnumerable<string> input = System.IO.File.ReadLines("input8.1.txt");

            int accumulator = 0;
            int currentLine = 0;
            string[] lines = input.ToArray();
            List<int> linesVisited = new List<int>();
            while (!linesVisited.Contains(currentLine))
            {
                linesVisited.Add(currentLine);
                string instruction = lines[currentLine].Substring(0, 3);
                int offset = Int32.Parse(lines[currentLine].Substring(4));
                if (instruction == "acc")
                {
                    accumulator += offset;
                    currentLine++;
                }
                else if (instruction == "jmp")
                {
                    currentLine += offset;
                }
                else if (instruction == "nop")
                {
                    // Just move to next line
                    currentLine++;
                }
            }

            Console.WriteLine(accumulator);
        }
    }
}
