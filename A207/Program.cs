using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//pwd : cd C:\Users\Student\Desktop\CS301\A207\bin\Debug
//Command with small text        : A207.exe small.txt 
//Command with input text        : A207.exe input.txt
//Command with input_1000  text  : A207.exe input_1000.txt
//Command with input_10000 text  : A207.exe input_10000.txt
//Command with input_100000 text : A207.exe input_100000.txt
namespace A207
{
    class Program
    {
        static int Main(string[] args)
        {      
            if (args.Length != 1)
            {
                Console.WriteLine("This program requires input text files.");
                return 0;
            }
            //string filename = "input_10000.txt";
            string filename = args[0];
            try
            {
                StreamReader file = new StreamReader(filename);//SteamReader will be used for reading text from file
                Elist employeelist = new Elist(filename, file);
                employeelist.MergeStart();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(String.Format("{0} does not exist!", filename));
                //Console.WriteLine(String.Format("{0} does not exist!", "query4sorted.txt"));
            }
            return 0;
        }
    }
}
