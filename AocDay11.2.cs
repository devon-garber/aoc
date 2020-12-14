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
                if (nearbyOccupied >= 5)
                {
                    return 'L';
                }
            }

            return currentState;
        }

        private static int GetNearbyOccupiedCount(string[] orig, int yPos, int xPos)
        {
            int nearbyOccupiedCount = 0;
            if (GetNextVisibleSeat(orig, yPos, xPos, -1, -1) == '#') // Up left
            {
                nearbyOccupiedCount++;
            }
            if (GetNextVisibleSeat(orig, yPos, xPos, -1, 0) == '#') // Up
            {
                nearbyOccupiedCount++;
            }
            if (GetNextVisibleSeat(orig, yPos, xPos, -1, 1) == '#') // Up right
            {
                nearbyOccupiedCount++;
            }
            if (GetNextVisibleSeat(orig, yPos, xPos, 0, -1) == '#') // Left
            {
                nearbyOccupiedCount++;
            }
            if (GetNextVisibleSeat(orig, yPos, xPos, 0, 1) == '#') // Right
            {
                nearbyOccupiedCount++;
            }
            if (GetNextVisibleSeat(orig, yPos, xPos, 1, -1) == '#') // Down left
            {
                nearbyOccupiedCount++;
            }
            if (GetNextVisibleSeat(orig, yPos, xPos, 1, 0) == '#') // Down
            {
                nearbyOccupiedCount++;
            }
            if (GetNextVisibleSeat(orig, yPos, xPos, 1, 1) == '#') // Down Right
            {
                nearbyOccupiedCount++;
            }

            return nearbyOccupiedCount;
        }

        private static char GetNextVisibleSeat(string[] orig, int origY, int origX, int yMove, int xMove)
        {
            int maxX = orig[0].Length - 1;
            int maxY = orig.Length - 1;

            // Some bounds checking first
            if (origY >= maxY && yMove > 0)
            {
                return '.'; // We are on the bottom trying to move out
            }
            if (origY == 0 && yMove < 0)
            {
                return '.'; // We are on the top trying to move out
            }
            if (origX >= maxX && xMove > 0)
            {
                return '.'; // We are on the right trying to move out
            }
            if (origX == 0 && xMove < 0)
            {
                return '.'; // We are on the left trying to mvoe out
            }

            char newSeat = orig[origY + yMove][origX + xMove];
            if (newSeat == '.')
            {
                return GetNextVisibleSeat(orig, origY + yMove, origX + xMove, yMove, xMove);
            }
            else
            {
                return newSeat;
            }
        }
    }
}