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
            string[] input = System.IO.File.ReadLines("input11.1.txt").ToArray();
            string[] first = RunIteration(input);

            while (DoesStateChange(first))
            {
                first = RunIteration(first);
            }

            int occupiedCount = 0;
            foreach (string line in first)
            {
                occupiedCount += line.Count(x => x == '#');
            }
            Console.WriteLine(occupiedCount);
        }

        private static bool DoesStateChange(string[] first)
        {
            bool change = false;
            string[] nextState = RunIteration(first);
            for (int i = 0; i < first.Length; ++i)
            {
                if (first[i] != nextState[i])
                {
                    return true;
                }
            }
            return change;
        }

        private static string[] RunIteration(string[] orig)
        {
            string[] newState = new string[orig.Length];
            for (int i = 0; i < orig.Length; ++i)
            {
                string line = "";
                for (int j = 0; j < orig[i].Length; ++j)
                {
                    line += GetNewStateForSpot(orig, i, j);
                }
                newState[i] = line;
            }
            return newState;
        }

        private static char GetNewStateForSpot(string[] orig, int yPos, int xPos)
        {
            char currentState = orig[yPos][xPos];
            int nearbyOccupied = GetNearbyOccupiedCount(orig, yPos, xPos);
            if (currentState == 'L')
            {
                if (nearbyOccupied == 0)
                {
                    return '#';
                }
            }
            else if (currentState == '#')
            {
                if (nearbyOccupied >= 4)
                {
                    return 'L';
                }
            }

            return currentState;
        }

        private static int GetNearbyOccupiedCount(string[] orig, int yPos, int xPos)
        {
            int maxX = orig[0].Length - 1;
            int maxY = orig.Length - 1;
            int nearbyOccupiedCount = 0;
            if (yPos != 0 && xPos != 0) // Up left
            {
                if (orig[yPos - 1][xPos - 1] == '#')
                {
                    nearbyOccupiedCount++;
                }
            }
            if (yPos != 0) // Up
            {
                if (orig[yPos - 1][xPos] == '#')
                {
                    nearbyOccupiedCount++;
                }
            }
            if (yPos != 0 && xPos != maxX) // Up right
            {
                if (orig[yPos - 1][xPos + 1] == '#')
                {
                    nearbyOccupiedCount++;
                }
            }
            if (xPos != 0) // Left
            {
                if (orig[yPos][xPos - 1] == '#')
                {
                    nearbyOccupiedCount++;
                }
            }
            if (xPos != maxX) // Right
            {
                if (orig[yPos][xPos + 1] == '#')
                {
                    nearbyOccupiedCount++;
                }
            }
            if (yPos != maxY && xPos != 0) // Down left
            {
                if (orig[yPos + 1][xPos - 1] == '#')
                {
                    nearbyOccupiedCount++;
                }
            }
            if (yPos != maxY) // Down
            {
                if (orig[yPos + 1][xPos] == '#')
                {
                    nearbyOccupiedCount++;
                }
            }
            if (yPos != maxY && xPos != maxX) // Down Right
            {
                if (orig[yPos + 1][xPos + 1] == '#')
                {
                    nearbyOccupiedCount++;
                }
            }

            return nearbyOccupiedCount;
        }
    }
}