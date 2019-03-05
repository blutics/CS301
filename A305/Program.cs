using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A305
{
    class Program
    {
        static void Main(string[] args)
        {
            //making tables!
            if (args.Length == 0)
            {
                Console.WriteLine("We need a file!");
            }
            else
            {
                new HashTableOne(args[0]);
                new HashTableTwo(args[0]);
                new HashTableThree(args[0]);
            }
            
        }
    }
}
