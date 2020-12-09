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

        //private static bool NopWouldEndIt(int currentLine, string[] lines)
        //{
        //    List<int> visitedLines = new List<int>();
        //    visitedLines.Add(currentLine);
        //    for (int line = currentLine + 1; line < lines.Length; ++line)
        //    {
        //        string instruction = lines[line].Substring(0, 3);
        //        int offset = Int32.Parse(lines[line].Substring(4));
        //        visitedLines.Add(line);
        //        if (instruction == "jmp")
        //        {
        //            if (!JmpWouldEndIt(line, lines, offset, visitedLines))
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        //private static bool JmpWouldEndIt(int currentLine, string[] lines, int offset, List<int> visitedLines)
        //{
        //    if (JumpedToSafeArea(currentLine, lines, offset, visitedLines))
        //    {
        //        return true;
        //    }

        //    for (int line = currentLine + offset; line < lines.Length; ++line)
        //    {
        //        string instruction = lines[line].Substring(0, 3);
        //        int newOffset = Int32.Parse(lines[line].Substring(4));
        //        visitedLines.Add(line);
        //        if (instruction == "jmp")
        //        {
        //            if (!JmpWouldEndIt(line, lines, newOffset, visitedLines))
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;        
        //}

        //private static bool JumpedToSafeArea(int currentLine, string[] lines, int offset, List<int> visitedLines)
        //{
        //    // If we are in a loop, AKA visitedLines contains our new line we need to bail as this won't work out.
        //    if (visitedLines.Contains(currentLine + offset))
        //    {
        //        return false;
        //    }

        //    // This is the end of the line if we reached an area with only NOP, ACC, and positive jumps. 
        //    // Or we are just trying to execute something past EOF 
        //    if (currentLine + offset >= lines.Length)
        //    {
        //        return true;
        //    }

        //    for (int line = currentLine + offset; line < lines.Length; ++line)
        //    {
        //        string instruction = lines[line].Substring(0, 3);
        //        int newOffset = Int32.Parse(lines[line].Substring(4));
        //        visitedLines.Add(line);
        //        visitedLines.Sort();
        //        if (instruction == "jmp")
        //        {
        //            if (!JmpWouldEndIt(line, lines, newOffset, visitedLines))
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}
    }
}
