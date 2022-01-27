using System;
using System.IO;

namespace adventofcode._2015
{
    public class Day1
    {
        int floor = 0; 
        string input = File.ReadAllText(@"../../../2015/Day1/Day1Input.txt");

        private int GetFloor()
        {
            floor = 0;
            foreach (char c in input)
            {
                if (c.Equals('('))
                    floor++;
                else
                    floor--;
            }
            return floor;
        }

        private int FindPositionIndex()
        {
            floor = 0;
            for(int i = 0; i < input.ToCharArray().Length; i++)
            {
                if (input[i].Equals('('))
                    floor++;
                else
                    floor--;
                if (floor == -1)
                    return i + 1;
            }
            return floor;
        }

        public void ShowResult()
        {
            Console.WriteLine("P1: " + GetFloor());
            Console.WriteLine("P2: " + FindPositionIndex());
        }
    }
}
