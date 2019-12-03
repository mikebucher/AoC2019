using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string strReadFile = @"C:\Dev\AoC2019/Day3.txt";
            string[] separator = { "," };
            List<points> firstwire = new List<points>();

            var fileLines = File.ReadAllLines(strReadFile).ToList();
            string line = fileLines[0];
            List<string> temp = line.Substring(0).Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();

            int x = 0;
            int y = 0;

            foreach (var item in temp)
            {
                int index = int.Parse(item.Substring(1));
                switch (item.Substring(0,1))
                {
                    case "U":
                        for (int i = 0; i < index; i++)
                        {
                            firstwire.Add(new points { xpos = x, ypos = y });
                            y++;
                        }
                        break;
                    case "D":
                        for (int i = 0; i < index; i++)
                        {
                            firstwire.Add(new points { xpos = x, ypos = y });
                            y--;
                        }
                        break;
                    case "L":
                        for (int i = 0; i < index; i++)
                        {
                            firstwire.Add(new points { xpos = x, ypos = y });
                            x--;
                        }
                        break;
                    case "R":
                        for (int i = 0; i < index; i++)
                        {
                            firstwire.Add(new points { xpos = x, ypos = y });
                            x++;
                        }
                        break;
                    default:
                        break;
                }
            }

            line = fileLines[1];
            temp = line.Substring(0).Split(separator, StringSplitOptions.RemoveEmptyEntries).ToList();

            x = 0;
            y = 0;
            int step = 0;
            int lowestmatch = 999999;

            foreach (var item in temp)
            {
                Console.WriteLine(item);
                int index = int.Parse(item.Substring(1));
                switch (item.Substring(0, 1))
                {
                    case "U":
                        for (int i = 0; i < index; i++)
                        {
                            if (checkForIntersection(x, y, firstwire))
                            {
                                int calc = step + firstwire.FindIndex(match => match.xpos == x && match.ypos == y);
                                if (calc < lowestmatch) lowestmatch = calc;
                            }
                            step++;
                            y++;
                        }
                        break;
                    case "D":
                        for (int i = 0; i < index; i++)
                        {
                            if (checkForIntersection(x, y, firstwire))
                            {
                                int calc = step + firstwire.FindIndex(match => match.xpos == x && match.ypos == y);
                                if (calc < lowestmatch) lowestmatch = calc;
                            }
                            step++;
                            y--;
                        }
                        break;
                    case "L":
                        for (int i = 0; i < index; i++)
                        {
                            if (checkForIntersection(x, y, firstwire))
                            {
                                int calc = step + firstwire.FindIndex(match => match.xpos == x && match.ypos == y);
                                if (calc < lowestmatch) lowestmatch = calc;
                            }
                            step++;
                            x--;
                        }
                        break;
                    case "R":
                        for (int i = 0; i < index; i++)
                        {
                            if (checkForIntersection(x, y, firstwire))
                            {
                                int calc = step + firstwire.FindIndex(match => match.xpos == x && match.ypos == y);
                                if (calc < lowestmatch) lowestmatch = calc;
                            }
                            step++;
                            x++;
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("lowestmatch: " + lowestmatch);
            Console.ReadKey();
        }
        public static bool checkForIntersection(int xpos, int ypos, List<points> list)
        {
            if (xpos == 0 && ypos == 0) return false;
            if (list.FirstOrDefault(x => x.xpos == xpos && x.ypos == ypos) != null) return true;
            return false;
        }
    }

    public class points
    {
        public int xpos { get; set; }
        public int ypos { get; set; }
    }
}

