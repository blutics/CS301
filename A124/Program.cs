using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Command : A124.exe sorted100.txt query4sorted.txt
//Command with manual file : A124.exe custom100.txt customquery.txt
namespace A124
{
    class Program
    {
        static int Main(string[] args)
        {      
            if (args.Length != 2)
            {
                Console.WriteLine("This program requires 2 input text files.");
                return 0;
            }
            Elist employeelist = new Elist(args[0]);
            //Elist employeelist = new Elist("sorted100.txt");
            try
            {
                StreamReader queryfile = new StreamReader(args[1]);//SteamReader will be used for reading text from file
                //StreamReader queryfile = new StreamReader("query4sorted.txt");

                int n = int.Parse(queryfile.ReadLine());
                for (int i = 0; i < n; i++)//instanciating each employee, n times
                {
                    employeelist.Query(i, int.Parse(queryfile.ReadLine()));
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(String.Format("{0} does not exist!", args[1]));
                //Console.WriteLine(String.Format("{0} does not exist!", "query4sorted.txt"));
            }
            return 0;
        }
    }
}
