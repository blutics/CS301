﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//pwd : cd C:\Users\Student\Desktop\CS301\A131\bin\Debug
//Command with small text       : A131.exe small.txt 
//Command with input text       : A131.exe input.txt
//Command with input_100   text : A131.exe input_100.txt
//Command with input_1000  text : A131.exe input_1000.txt
//Command with input_10000 text : A131.exe input_10000.txt
namespace A131
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
            try
            {
                //Elist employeelist = new Elist("input_10000.txt");
                Elist employeelist = new Elist(args[0]);
                employeelist.InsertionSort();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(String.Format("{0} does not exist!", args[0]));
                //Console.WriteLine(String.Format("{0} does not exist!", "query4sorted.txt"));
            }
            return 0;
        }
    }
}
