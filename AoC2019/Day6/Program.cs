using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string strReadFile = @"C:\Dev\AoC2019\Day6.txt";
            var lines = File.ReadAllLines(strReadFile);
            int result = 1;

            List<Orbit> orbits = new List<Orbit>();

            List<Orbit> MeToStart = new List<Orbit>();
            List<Orbit> SantaToStart = new List<Orbit>();
            foreach (var item in lines)
            {
                orbits.Add(new Orbit { origin = item.Substring(0, 3), orbiting = item.Substring(4, 3) });
            }

            Orbit temp = orbits.FirstOrDefault(x => x.orbiting == "YOU");

            while (temp != null)
            {
                MeToStart.Add(temp);
                temp = orbits.FirstOrDefault(x => x.orbiting == temp.origin);
            }

            temp = orbits.FirstOrDefault(x => x.orbiting == "SAN");

            while (temp != null)
            {
                SantaToStart.Add(temp);
                temp = orbits.FirstOrDefault(x => x.orbiting == temp.origin);
            }

            var test = MeToStart.Intersect(SantaToStart);

            result = (MeToStart.Count - test.Count() + (SantaToStart.Count - test.Count()) - 2); 
            Console.WriteLine("Result: " + result);
            Console.ReadKey();
        }
    }

    public class Orbit
    {
        public string origin { get; set; }
        public string orbiting { get; set; }
    }
}
