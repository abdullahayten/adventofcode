using System;
using System.IO;
using System.Linq;

namespace adventofcode._2015.Day3
{
    public class Day3
    {
        int total;
        string homeCoord;
        string[] coordsSanta;
        int x, y, z, t;
        string input = File.ReadAllText(@"../../../2015/Day3/Day3Input.txt");

        private int GetTotalHouse()
        {
            total = 0;
            homeCoord = "";
            x = 0; y = 0;
            int length = input.ToCharArray().Length;
            coordsSanta = new string[length];
            for (int i = 0; i < length; i++)
            {
                switch (input[i])
                {
                    case '^':
                        y++;
                        break;
                    case '>':
                        x++;
                        break;
                    case 'v':
                        y--;
                        break;
                    case '<':
                        x--;
                        break;
                    default: break;
                }
                homeCoord = string.Concat(x, ',', y);
                if (!coordsSanta.Contains(homeCoord))
                    coordsSanta[i] = homeCoord;
            }
            total = coordsSanta.Where(x => x != null).ToList().Count() + 1;
            return total;
        }

        private int GetTotalHouseWithRobot()
        {
            total = 0;
            homeCoord = "";
            x = 0; y = 0; z = 0; t = 0;
            int length = input.ToCharArray().Length;
            coordsSanta = new string[length];
            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0)
                {
                    switch (input[i])
                    {
                        case '^':
                            y++;
                            break;
                        case '>':
                            x++;
                            break;
                        case 'v':
                            y--;
                            break;
                        case '<':
                            x--;
                            break;
                        default: break;
                    }
                    homeCoord = string.Concat(x, ',', y);
                }
                else
                {
                    switch (input[i])
                    {
                        case '^':
                            z++;
                            break;
                        case '>':
                            t++;
                            break;
                        case 'v':
                            z--;
                            break;
                        case '<':
                            t--;
                            break;
                        default: break;
                    }
                    homeCoord = string.Concat(t, ',', z);
                }
                if (!coordsSanta.Contains(homeCoord))
                    coordsSanta[i] = homeCoord;
            } 
            total = coordsSanta.Where(x => x != null).ToList().Count() ;
            return total;
        }

        public void ShowResult()
        {
            Console.WriteLine("P1: " + GetTotalHouse());
            Console.WriteLine("P2: " + GetTotalHouseWithRobot());
        }
    }
}
