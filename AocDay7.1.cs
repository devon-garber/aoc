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
            IEnumerable<string> input = System.IO.File.ReadLines("input7.1.txt");

            List<Bag> bags = new List<Bag>();
            foreach (string line in input)
            {
                string[] temp = line.Split("contain");
                Bag bag = new Bag();
                bag.BagName = temp[0].Trim();
                bag.ContainableBagTypes = GetHoldableBags(temp[1].Trim());
                bags.Add(bag);
            }

            int answer = FindGoldContainers(bags);

            Console.WriteLine(answer);
        }

        private static List<string> GetHoldableBags(string innerBagDesc)
        {
            if (innerBagDesc.StartsWith("no"))
            {
                return new List<string>(); // Can't hold anything
            }
            else
            {
                List<string> holdableBags = new List<string>();
                foreach (string bagDesc in innerBagDesc.Split(','))
                {
                    string bag = bagDesc.Substring(2).Replace('.', ' ').Trim();
                    if (Int32.Parse(bagDesc.Substring(0, 2)) == 1)
                    {
                        // Freaking lack of s at the of 1 bag, just going ghetto and adding it back on.
                        bag += 's';
                    }
                    holdableBags.Add(bag);
                }
                return holdableBags;
            }
        }

        private static int FindGoldContainers(IEnumerable<Bag> bags)
        {
            int goldCount = 0;
            foreach (Bag bag in bags)
            {
                if (CanContainGold(bags, bag))
                {
                    goldCount++;
                }
            }
            return goldCount;
        }

        private static bool CanContainGold(IEnumerable<Bag> allBags, Bag currentBag)
        {
            if (currentBag.ContainableBagTypes.Count() != 0)
            {
                if (currentBag.ContainableBagTypes.Any(x => x.Contains("shiny gold bag")))
                {
                    return true;
                }
                foreach (string bagName in currentBag.ContainableBagTypes)
                {
                    var temp = allBags.First(x => x.BagName == bagName);
                    if (CanContainGold(allBags, allBags.Where(x => x.BagName == bagName).First()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    public class Bag
    { 
        public String BagName { get; set; }
        public List<string> ContainableBagTypes { get; set; }

        public Bag()
        {
            this.BagName = "";
            this.ContainableBagTypes = new List<string>();
        }
    }
}
