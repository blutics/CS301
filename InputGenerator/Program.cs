using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader first = new StreamReader("firstname.txt");
            string[] firsta = new string[1000];
            for(int i = 0; i < 1000; i++)
            {
                firsta[i] = first.ReadLine();
            }
            StreamReader last = new StreamReader("lastname.txt");
            string[] lasta = new string[1000];
            for(int i = 0; i < 1000; i++)
            {
                lasta[i] = last.ReadLine();
            }

            int[] firstc = new int[1000];
            StreamWriter file = new StreamWriter("input.txt");
            Console.Write("How many people do you need?? ");
            int n = int.Parse(Console.ReadLine());
            int id = 1;
            Random rnd = new Random();
            for(int i = 0; i < n; i++)
            {
                int firstn;
                while (true)
                {
                    firstn = rnd.Next(0, 1000);
                    if (firstc[firstn] == 0)
                    {
                        firstc[firstn] = 1;
                        break;
                    }
                }
                int lastn = rnd.Next(0, 1000);
                int year = rnd.Next(1950, 2019);
                id += rnd.Next(0, 100);
                int age = 2019 - year + rnd.Next(5, 20));
                Console.WriteLine(rnd.Next(1,30));
            }
            
        }
    }
}
