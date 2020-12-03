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
            int[] input= System.IO.File.ReadLines("input1.2.txt").Select(x => Int32.Parse(x)).ToArray();

            for (int i = 0; i < input.Length - 2; ++i)
            {
                for (int j = i + 1; j < input.Length - 1; ++j)
                {
                    for (int k = j + 1; k < input.Length; ++k)
                    if (input[i] + input[j] + input[k] == 2020)
                    {
                        Console.WriteLine(input[i] * input[j] * input[k]);
                    }
                }
            }
        }
    }
}
