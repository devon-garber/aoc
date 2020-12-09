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

            string[] lines = input.ToArray();
            int accumulator = 0;
            int currentLine = 0;
            int totalLines = lines.Length;
            List<int> linesVisited = new List<int>();
            bool changeUsed = false;
            while (currentLine < totalLines)
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
                    // Check if changing to a NOP would NOT cause a program loop
                    if (!changeUsed && !DoesProgramLoop(currentLine + 1, lines, linesVisited))
                    {
                        // We found a way to terminate, pretend to be a NOP
                        changeUsed = true;
                        currentLine++;
                    }
                    else
                    {
                        currentLine += offset;
                    }
                }
                else if (instruction == "nop")
                {
                    // Check if changing to a JMP would NOT cause a program loop
                    if (!changeUsed && !DoesProgramLoop(currentLine + offset, lines, linesVisited))
                    {
                        // We found a way to terminate, pretend to be a jmp;
                        changeUsed = true;
                        currentLine += offset;
                    }
                    else
                    {
                        // Just move to next line
                        currentLine++;
                    }
                }
            }

            Console.WriteLine(accumulator);
        }

        private static bool DoesProgramLoop(int currentLine, string[] lines, List<int> linesVisited)
        {
            bool loopDetected = false;
            while (!loopDetected)
            {
                if (currentLine >= lines.Length)
                {
                    // We are attemping to execute a line outside the program, that is successful termination
                    return false;
                }
                if (linesVisited.Contains(currentLine))
                {
                    loopDetected = true;
                }
                else
                {
                    linesVisited.Add(currentLine);
                    string instruction = lines[currentLine].Substring(0, 3);
                    int offset = Int32.Parse(lines[currentLine].Substring(4));
                    if (instruction == "acc" || instruction == "nop")
                    {
                        currentLine++;
                    }
                    else if (instruction == "jmp")
                    {
                        currentLine += offset;
                    }
                }
            }
            return loopDetected;
        }
    }
}
