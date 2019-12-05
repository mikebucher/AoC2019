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
            string strReadFile = @"C:\Dev\AoC2019\Day5.txt";
            string[] separator = { "," };

            int i = 0;

            var line = File.ReadAllLines(strReadFile);
            //var line = "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99";

            int[] temp = line[0].Substring(0).Split(separator, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();

            while (i < temp.Length)
            {
                var opcode = new int[5];
                var calc = temp[i];
                opcode[4] = calc % 10;
                calc /= 10;
                opcode[3] = calc % 10;
                calc /= 10;
                opcode[2] = calc % 10;
                calc /= 10;
                opcode[1] = calc % 10;
                calc /= 10;
                opcode[0] = calc % 10;
                calc /= 10;

                int firstparam;
                int secondparam;
                int thirdparam;

                if (opcode[4] == 3)
                {
                    Console.WriteLine("Opcode 3, please provide input: ");
                    temp[temp[i + 1]] = int.Parse(Console.ReadLine());
                    i += 2;
                }
                else if (opcode[4] == 4)
                {
                    if(opcode[2] == 0) Console.WriteLine("Output: " + temp[temp[i + 1]]);
                    else if (opcode[2] == 1) Console.WriteLine("Output: " + temp[i + 1]);
                    i += 2;
                }
                else if (opcode[3] == 9 && opcode[4] == 9)
                {
                    Console.WriteLine("finished");
                    break;
                }
                else
                {

                    if (opcode[2] == 0)
                    {
                        firstparam = temp[temp[i + 1]];
                    }
                    else
                    {
                        firstparam = temp[i + 1];
                    }
                    if (opcode[1] == 0)
                    {
                        secondparam = temp[temp[i + 2]];
                    }
                    else
                    {
                        secondparam = temp[i + 2];
                    }
                
                    thirdparam = temp[i + 3];
                

                    if (opcode[4] == 1)
                    {
                        Console.WriteLine("addition");
                        int calc2 = firstparam + secondparam;
                        temp[thirdparam] = calc2;
                        i += 4;
                    }
                    else if (opcode[4] == 2)
                    {
                        Console.WriteLine("multiplication");
                        int calc2 = firstparam * secondparam;
                        temp[thirdparam] = calc2;
                        i += 4;
                    }
                    else if (opcode[4] == 5)
                    {
                        Console.WriteLine("jump if true");
                        if (!firstparam.Equals(0)) i = secondparam;
                        else i += 3;
                    }
                    else if (opcode[4] == 6)
                    {
                        Console.WriteLine("jump if false");
                        if (firstparam.Equals(0)) i = secondparam;
                        else i += 3;
                    }
                    else if (opcode[4] == 7)
                    {
                        Console.WriteLine("less than");
                        if (firstparam < secondparam) temp[thirdparam] = 1;
                        else temp[thirdparam] = 0;
                        i += 4;
                    }
                    else if (opcode[4] == 8)
                    {
                        Console.WriteLine("equals");
                        if (firstparam.Equals(secondparam)) temp[thirdparam] = 1;
                        else temp[thirdparam] = 0;
                        i += 4;
                    }
                    else { break; }
                }

            }
            Console.ReadKey();
        }
        public static int NumDigits(int n)
        {
            if (n < 0)
            {
                n = (n == Int32.MinValue) ? Int32.MaxValue : -n;
            }
            if (n < 10) return 1;
            if (n < 100) return 2;
            if (n < 1000) return 3;
            if (n < 10000) return 4;
            if (n < 100000) return 5;
            if (n < 1000000) return 6;
            if (n < 10000000) return 7;
            if (n < 100000000) return 8;
            if (n < 1000000000) return 9;
            return 10;
        }
    }
}
