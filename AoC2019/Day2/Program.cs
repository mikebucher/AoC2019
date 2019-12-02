using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string strReadFile = @"C:\Dev\AoC2019\Day2.txt";
            string[] separator = { "," };

            int i = 0;

            var line = File.ReadAllLines(strReadFile);

            List<int> temp = line[0].Substring(0).Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToList();

            temp[1] = 22;
            temp[2] = 54;

            while (i < temp.Count)
            {
                if (temp[i] == 1)
                {
                    int calc = temp[temp[i + 1]] + temp[temp[i + 2]];
                    temp[temp[i + 3]] = calc;
                }
                else if (temp[i] == 2)
                {
                    int calc = temp[temp[i + 1]] * temp[temp[i + 2]];
                    temp[temp[i + 3]] = calc;
                }
                else if(temp[i] == 99)
                {
                    break;
                }
                else { break; }
                i += 4;
            }
            Console.WriteLine("Result :" + temp[0].ToString());
            Console.ReadKey();
        }
    }
}
