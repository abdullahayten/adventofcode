using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace adventofcode._2015.Day5
{
    public class Day5
    {
        string input = File.ReadAllText(@"../../../2015/Day5/Day5Input.txt");
        int output;

        private int GetNiceWordCount()
        {
            output = 0;
            foreach (string s in input.Split("\r\n"))
            {
                int vowelCount = s.ToCharArray().Where(x => x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u').ToList().Count();
                bool isTwice = false;
                for (int i = 0; i < s.Length; i++)
                {
                    if (i < s.Length - 1 && s[i] == s[i + 1])
                        isTwice = true;
                }
                bool isContainRules = !s.Contains("ab") && !s.Contains("cd") && !s.Contains("pq") && !s.Contains("xy");
                if (vowelCount >= 3 && isTwice && isContainRules)
                    output++;
            }

            return output;
        }

        private int GetNiceWordCountP2()
        {
            output = 0;
            foreach (string s in input.Split("\r\n"))
            {
                bool betweenRule = false;
                bool twiceRule = false;
                for (int i = 0; i < s.Length; i++)
                {
                    if (i < s.Length - 2 && s[i] == s[i + 2])
                        betweenRule = true;

                    if (i < s.Length - 1)
                    { 
                        string tw = s.Substring(i, 2);
                        string tr = new String(s[i], 3);
                        string fr = new String(s[i], 4);
                        if (Regex.Matches(s, tw).Count > 1 && (Regex.Matches(s, tr).Count == 0|| Regex.Matches(s, fr).Count > 0))
                            twiceRule = true;
                    }
                }
                if (betweenRule && twiceRule) 
                    output++;
            }

            return output;
        }

        public void ShowResult()
        {
            Console.WriteLine("P1: " + GetNiceWordCount());
            Console.WriteLine("P2: " + GetNiceWordCountP2());
        }
    }
}
