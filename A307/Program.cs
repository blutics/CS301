using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A307
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable tmp = null;
            //making tables!
            if (args.Length == 0)
            {
                Console.WriteLine("We need a file!");
            }
            else
            {
                tmp = new HashTable(args[0]);
                Console.WriteLine(String.Format("Total collisions during lookup phase: {0}", tmp.count));
            }
        }
    }
}
