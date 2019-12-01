using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string strReadFile = @"C:\Dev\AoC2019\Day1.txt";
            double result = 0;

            var fileLines = File.ReadAllLines(strReadFile).ToList();

            foreach (string line in fileLines)
            {
                double fuelcalc = double.Parse(line);
                
                while (fuelcalc > 0 )
                {
                    fuelcalc /= 3;
                    fuelcalc = Math.Floor(fuelcalc) - 2;
                    if (fuelcalc < 0) fuelcalc = 0;
                    result += fuelcalc;
                }

            }


            Console.WriteLine("Result: " + result);
            Console.ReadKey();

        }
    }
}
