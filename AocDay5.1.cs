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
            IEnumerable<string> input = System.IO.File.ReadLines("input5.1.txt");

            int highestBoardingId = 0;
            foreach (string line in input)
            {
                string rowString = line.Substring(0, 7);
                string columnString = line.Substring(7, 3);

                int row = FindBinaryRepresentation(rowString);
                int column = FindBinaryRepresentation(columnString);
                int boardingId = (row * 8) + column;

                if (boardingId > highestBoardingId)
                {
                    highestBoardingId = boardingId;
                }
            }

            Console.WriteLine(highestBoardingId);
        }

        private static int FindBinaryRepresentation(string binaryString)
        {
            int row = 0;

            for (int i = 0; i < binaryString.Length; ++i)
            {
                if (binaryString[i] == 'B' || binaryString[i] == 'R')
                {
                    row += (int)Math.Pow(2, (binaryString.Length - 1 - i));
                }
            }

            return row;
        }
    }
}
