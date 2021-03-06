﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//pwd : cd C:\Users\Student\Desktop\CS301\A214\bin\Debug
//Command with small text        : A214.exe small.txt 
//Command with input text        : A214.exe input.txt
//Command with input_1000  text  : A214.exe input_1000.txt
//Command with input_10000 text  : A214.exe input_10000.txt
//Command with input_100000 text : A214.exe input_100000.txt
namespace A214
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
            //string filename = "input_100000.txt";
            string filename = args[0];
            try
            {
                StreamReader file = new StreamReader(filename);//SteamReader will be used for reading text from file
                Elist employeelist = new Elist(filename, file);
                employeelist.QuickStart();
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
