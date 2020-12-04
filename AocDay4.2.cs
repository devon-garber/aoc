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
                    passport.ValidBirthYear = BirthYearValid(field);
                }
                else if (field.Contains("iyr:"))
                {
                    passport.ValidIssueYear = IssueYearValid(field);
                }
                else if(field.Contains("eyr:"))
                {
                    passport.ValidExpirationYear = ExpirationYearValid(field);
                }
                else if(field.Contains("hgt:"))
                {
                    passport.ValidHeight = HeightValid(field);
                }
                else if(field.Contains("hcl:"))
                {
                    passport.ValidHairColor = HairColorValid(field);
                }
                else if(field.Contains("ecl:"))
                {
                    passport.ValidEyeColor = EyeColorValid(field);
                }
                else if(field.Contains("pid:"))
                {
                    passport.ValidPassportId = PassportIdValid(field);
                }
            }

            if (passport.ValidBirthYear && 
                passport.ValidIssueYear && 
                passport.ValidExpirationYear && 
                passport.ValidHeight && 
                passport.ValidHairColor && 
                passport.ValidEyeColor && 
                passport.ValidPassportId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool BirthYearValid(string birthYear)
        {
            int year = int.Parse(birthYear.Split(':')[1]);

            if (year >= 1920 && year <= 2002)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IssueYearValid(string issueYear)
        {
            int year = int.Parse(issueYear.Split(':')[1]);

            if (year >= 2010 && year <= 2020)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool ExpirationYearValid(string expirationYear)
        {
            int year = int.Parse(expirationYear.Split(':')[1]);

            if (year >= 2020 && year <= 2030)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool HeightValid(string heightString)
        {
            string height = heightString.Split(':')[1];
            int heightNum = 0;
            if (height.EndsWith("in"))
            {
                int.TryParse(height.Substring(0, 2), out heightNum);
                if (heightNum >= 59 && heightNum <= 76)
                {
                    return true;
                }
            }
            else if (height.EndsWith("cm"))
            {
                int.TryParse(height.Substring(0, 3), out heightNum);
                if (heightNum >= 150 && heightNum <= 193)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HairColorValid(string hairColorString)
        {
            string hairColor = hairColorString.Split(':')[1];
            char[] acceptableChars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f' };
            if (hairColor[0] == '#' && hairColor.Substring(1).All(x => char.IsDigit(x) || acceptableChars.Contains(x)))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private static bool EyeColorValid(string eyeColorString)
        {
            string eyeColor = eyeColorString.Split(':')[1];
            if (eyeColor == "amb" ||
                eyeColor == "blu" ||
                eyeColor == "brn" ||
                eyeColor == "gry" ||
                eyeColor == "grn" ||
                eyeColor == "hzl" ||
                eyeColor == "oth")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool PassportIdValid(string passportIdString)
        {
            string passportId = passportIdString.Split(':')[1];
            if (passportId.Length == 9 && passportId.All(x => char.IsDigit(x)))
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
            public bool ValidBirthYear { get; set; }
            public bool ValidIssueYear { get; set; }
            public bool ValidExpirationYear { get; set; }
            public bool ValidHeight { get; set; }
            public bool ValidHairColor { get; set; }
            public bool ValidEyeColor { get; set; }
            public bool ValidPassportId { get; set; }

            public Passport()
            {
                this.ValidBirthYear = false;
                this.ValidIssueYear = false;
                this.ValidExpirationYear = false;
                this.ValidHeight = false;
                this.ValidHairColor = false;
                this.ValidEyeColor = false;
                this.ValidPassportId = false;
            }
        }
    }
}
