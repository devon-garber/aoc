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
            string[] input = System.IO.File.ReadLines("input9.1.txt").ToArray();

            // Populate initial list of 25 with our 25 first entries
            int preambleLength = 25;
            List<int> usableNumbers = new List<int>(preambleLength);
            for (int i = 0; i < preambleLength; ++i)
            {
                usableNumbers.Add(Int32.Parse(input[i]));
            }

            int failureNumber = 0;
            foreach (string line in input.Skip(preambleLength))
            {
                int newNumber = Int32.Parse(line);
                if (!IsNumberValid(newNumber, usableNumbers))
                {
                    // We found our failure guy
                    failureNumber = newNumber;
                    break;
                }
                else
                {
                    // Otherwise we update our list and move on
                    usableNumbers.RemoveAt(0);
                    usableNumbers.Add(newNumber);
                }
            }

            Console.WriteLine(failureNumber);
        }

        private static bool IsNumberValid(int number, List<int> usableNumbers)
        {
            for (int i = 0; i <= usableNumbers.Count; ++i)
            {
                for (int j = i + 1; j < usableNumbers.Count; ++j)
                {
                    if (usableNumbers[i] + usableNumbers[j] == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}