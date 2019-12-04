using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> result = new List<int>();
            for (int i = 134792; i <= 675810; i++)
            {
                int input = i;
                bool doubledigit = false;
                bool increasedigit = false;

                List<int> listOfInts = new List<int>();
                while (input > 0)
                {
                    listOfInts.Add(input % 10);
                    input /=  10;
                }
                listOfInts.Reverse();

                if (listOfInts[0] <= listOfInts[1] &&
                    listOfInts[1] <= listOfInts[2] &&
                    listOfInts[2] <= listOfInts[3] &&
                    listOfInts[3] <= listOfInts[4] &&
                    listOfInts[4] <= listOfInts[5]) increasedigit = true;

                if ((listOfInts[0] == listOfInts[1] && listOfInts[1] != listOfInts[2]) ||
                    (listOfInts[1] == listOfInts[2] && listOfInts[2] != listOfInts[3] && listOfInts[0] != listOfInts[1]) ||
                    (listOfInts[2] == listOfInts[3] && listOfInts[3] != listOfInts[4] && listOfInts[1] != listOfInts[2]) ||
                    (listOfInts[3] == listOfInts[4] && listOfInts[4] != listOfInts[5] && listOfInts[2] != listOfInts[3]) ||
                    (listOfInts[4] == listOfInts[5] && listOfInts[3] != listOfInts[4] )

                    ) doubledigit = true;

                int temp = 0;

                if(increasedigit && doubledigit)
                {
                    for (int j = 0; j < listOfInts.Count; j++)
                    {
                        temp += listOfInts[j] * Convert.ToInt32(Math.Pow(10, listOfInts.Count - j - 1));
                    }
                    result.Add(temp);
                }


            }


            Console.WriteLine("result: " + result.Count);
            Console.ReadKey();
        }
    }
}
