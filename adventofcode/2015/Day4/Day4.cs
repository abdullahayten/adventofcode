using System;
using System.Security.Cryptography;
using System.Text;

namespace adventofcode._2015.Day4
{
    public class Day4
    {
        string input = "bgvyzdsv";
        private int GetLowestPositiveNumber(int zeroCount, string zeros)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] dizi = Encoding.UTF8.GetBytes($"{input}{i}");
                dizi = md5.ComputeHash(dizi);
                StringBuilder sb = new StringBuilder();
                foreach (byte ba in dizi)
                {
                    sb.Append(ba.ToString("x2").ToLower());
                }

                if (sb.ToString().Substring(0, zeroCount).Equals(zeros))
                    return i;
            }
            return 0;
        }

        public void ShowResult()
        {
            Console.WriteLine("P1: " + GetLowestPositiveNumber(5, "00000"));
            Console.WriteLine("P2: " + GetLowestPositiveNumber(6, "000000"));
        }
    }
}
