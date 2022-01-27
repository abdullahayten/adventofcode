using System;
using System.IO;
using System.Linq;

namespace adventofcode._2015.Day2
{
    public class Day2
    {
        int total = 0;
        string input = File.ReadAllText(@"../../../2015/Day2/Day2Input.txt");
        public int GetTotalSquare()
        {
            total = 0;
            foreach (string s in input.Split("\r\n"))
            {
                int[] dimensions = s.Split("x").OrderBy(x=>Convert.ToInt32(x)).Select(x => Convert.ToInt32(x)).ToArray();
                total += 3 * dimensions[0] * dimensions[1];
                total += 2 * dimensions[1] * dimensions[2];
                total += 2 * dimensions[0] * dimensions[2];
            }

            return total;
        }

        public int GetTotalRibbon()
        {
            total = 0;
            foreach (string s in input.Split("\r\n"))
            {
                int[] dimensions = s.Split("x").OrderBy(x=>Convert.ToInt32(x)).Select(x => Convert.ToInt32(x)).ToArray();
                total += 2 * (dimensions[0] + dimensions[1]);
                total += dimensions[0] * dimensions[1] * dimensions[2];
            }

            return total;
        }

        public void ShowResult()
        {
            Console.WriteLine(GetTotalSquare());
            Console.WriteLine(GetTotalRibbon());
        }
    }
}
