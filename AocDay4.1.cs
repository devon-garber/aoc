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
            IEnumerable<string> input = System.IO.File.ReadLines("input4.1.txt");
            int validPassportCount = 0;

            StringBuilder fullPassportString = new StringBuilder();
            foreach (string line in input)
            {
                if (line == string.Empty)
                {
                    if (IsPassportValid(fullPassportString.ToString()))
                    {
                        validPassportCount++;
                    }
                    fullPassportString.Clear();
                }
                fullPassportString.Append(line + " ");
            }

            // Also remember to do the very last one as EOF is not string.empty
            if (IsPassportValid(fullPassportString.ToString()))
            {
                validPassportCount++;
            }

            Console.WriteLine(validPassportCount);
        }

        private static bool IsPassportValid(string passportString)
        {
            Passport passport = new Passport();
            foreach (string field in passportString.Split(' '))
            {
                if (field.Contains("byr:"))
                {
                    passport.HasBirthYear = true;
                }
                if (field.Contains("iyr:"))
                {
                    passport.HasIssueYear = true;
                }
                if (field.Contains("eyr:"))
                {
                    passport.HasExpirationYear = true;
                }
                if (field.Contains("hgt:"))
                {
                    passport.HasHeight = true;
                }
                if (field.Contains("hcl:"))
                {
                    passport.HasHairColor = true;
                }
                if (field.Contains("ecl:"))
                {
                    passport.HasEyeColor = true;
                }
                if (field.Contains("pid:"))
                {
                    passport.HasPassportId = true;
                }
                if (field.Contains("cid:"))
                {
                    passport.HasCountryId = true;
                }
            }

            if (passport.HasBirthYear && 
                passport.HasIssueYear && 
                passport.HasExpirationYear && 
                passport.HasHeight && 
                passport.HasHairColor && 
                passport.HasEyeColor && 
                passport.HasPassportId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private class Passport
        { 
            public bool HasBirthYear { get; set; }
            public bool HasIssueYear { get; set; }
            public bool HasExpirationYear { get; set; }
            public bool HasHeight { get; set; }
            public bool HasHairColor { get; set; }
            public bool HasEyeColor { get; set; }
            public bool HasPassportId { get; set; }
            public bool HasCountryId { get; set; }

            public Passport()
            {
                this.HasBirthYear = false;
                this.HasIssueYear = false;
                this.HasExpirationYear = false;
                this.HasHeight = false;
                this.HasHairColor = false;
                this.HasEyeColor = false;
                this.HasPassportId = false;
                this.HasCountryId = false;
            }
        }
    }
}
