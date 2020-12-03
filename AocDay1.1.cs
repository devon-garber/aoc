using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AocDay1._1
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] input= System.IO.File.ReadLines("input1.1.txt").Select(x => Int32.Parse(x)).ToArray();

            for (int i = 0; i < input.Length; ++i)
            {
                for (int j = i; j < input.Length; ++j)
                {
                    if (input[i] + input[j] == 2020)
                    {
                        Console.WriteLine(input[i] * input[j]);
                    }
                }
            }
        }
    }
}
