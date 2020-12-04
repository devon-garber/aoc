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

            long rightOneDownOne = CountTreeHits(input, 1, 1);
            long rightThreeDownOne = CountTreeHits(input, 3, 1);
            long rightFiveDownOne = CountTreeHits(input, 5, 1);
            long rightSevenDownOne = CountTreeHits(input, 7, 1);
            long rightOneDownTwo = CountTreeHits(input, 1, 2);

            Console.WriteLine(rightOneDownOne * rightThreeDownOne * rightFiveDownOne * rightSevenDownOne * rightOneDownTwo);
        }

        private static int CountTreeHits(IEnumerable<string> input, int right, int downRow)
        {
            int treeHits = 0;
            int positionInLine = 0;
            IEnumerable<string> trimmedInput = GetTrimmedInput(input.ToArray(), downRow); // Get rid of any useless lines

            foreach (string row in trimmedInput.Skip(1)) // Ignore first row
            {
                positionInLine += right;
                if (positionInLine >= row.Length)
                {
                    positionInLine = positionInLine % row.Length;
                }

                if (row[positionInLine] == '#')
                {
                    ++treeHits;
                }
            }

            return treeHits;
        }

        private static IEnumerable<string> GetTrimmedInput(string[] input, int downRow)
        {
            int rowCount = 0;
            List<string> trimmedInput = new List<string>();
            while (rowCount < input.Count())
            {
                trimmedInput.Add(input[rowCount]);
                rowCount += downRow;
            }

            return trimmedInput;
        }
    }
}
