using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Aoc
{
    public class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> input = System.IO.File.ReadLines("input3.1.txt");

            int treeHits = 0;
            int positionInLine = 0;
            foreach (string row in input.Skip(1))
            {
                positionInLine += 3;
                if (positionInLine >= row.Length)
                {
                    positionInLine = positionInLine % row.Length;
                }

                if (row[positionInLine] == '#')
                {
                    ++treeHits;
                }
            }

            Console.WriteLine(treeHits);
        }
    }
}
