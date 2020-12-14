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
            List<int> allNumbers = System.IO.File.ReadLines("input10.1.txt").Select(x => Int32.Parse(x)).ToList();
            allNumbers.Sort();

            int oneJump = 1;
            int twoJump = 1;
            int threeJump = 1;
            int lastNumber = 0;
            foreach (int i in allNumbers)
            {
                if (lastNumber == 0)
                {
                    lastNumber = i;
                }
                else
                {
                    if (lastNumber + 1 == i)
                    {
                        oneJump++;
                    }
                    else if (lastNumber + 2 == i)
                    {
                        twoJump++;
                    }
                    else if (lastNumber + 3 == i)
                    {
                        threeJump++;
                    }
                    else
                    {
                        // Invalid data
                    }
                    lastNumber = i;
                }
            }

            Console.WriteLine(oneJump * threeJump);
        }
    }
}