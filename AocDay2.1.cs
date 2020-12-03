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
            IEnumerable<string> input = System.IO.File.ReadLines("input2.1.txt");

            int validPasswords = 0;
            foreach (string passwordPolicy in input)
            {
                Match match = Regex.Match(passwordPolicy, "([0-9]+)-([0-9]+) ([a-z]): (.*)");

                int minCount = Int32.Parse(match.Groups[1].Value);
                int maxCount = Int32.Parse(match.Groups[2].Value);
                char letter = Char.Parse(match.Groups[3].Value);
                string password = match.Groups[4].Value;

                int letterInPasswordCount = password.Where(x => x.Equals(letter)).Count();
                if (letterInPasswordCount >= minCount && letterInPasswordCount <= maxCount)
                {
                    validPasswords++;
                }
            }

            Console.WriteLine(validPasswords);
        }
    }
}
