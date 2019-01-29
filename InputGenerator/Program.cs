using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Name:        Megaboz Pibepo
ID:          75534
Age:         52
Job:         Granola Taster
Hire year:   1982
**************************** 
 */
namespace InputGenerator
{
    class Program
    {
        static int Main(string[] args)
        {
            string[] firsta  = new string[1000];
            string[] lasta   = new string[1000];
            string[] joblist = {"Programmer", "Accountant", "Project Manager", "Graphic Designer", "Tester", "Systems Administrator",
            "Analyst", "Technician", "Engineer", "Custodian", "Consierge", "Director", "Consultant", "Bookkeeper",
            "Physicist", "Granola Taster", "Blacksmith", "Game Show Host", "Granola Miner", "Granola Smelter" };

            try
            {
                StreamReader first = new StreamReader("firstname.txt");
               
                for (int i = 0; i < 1000; i++)
                {
                    firsta[i] = first.ReadLine();
                }

                StreamReader last = new StreamReader("lastname.txt");
                
                for (int i = 1; i < 1000; i++)
                {
                    string tmp = last.ReadLine();
                    lasta[i] = tmp[0] + tmp.Substring(1).ToLower();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("requires firstname.txt and lastname.txt");
                return 0;
            }
            int[] firstc = new int[1000];

            while (true)
            {
                Console.Write("How many people do you need?? ");
                int n = int.Parse(Console.ReadLine());
                StreamWriter file = new StreamWriter(String.Format("input_{0}.txt", n));
                int id = 1;
                Random rnd = new Random();
                int[] randomCheck = new int[900000];
                file.WriteLine(n);
                int t = 0;
                for (int i = 0; i < n; i++)
                {
                    int firstn;
                    firstn = rnd.Next(0, 1000);
                    int lastn = rnd.Next(0, 1000);
                    int year = rnd.Next(1950, 2019);
                    while (true)
                    {
                        t = rnd.Next(0, 900000 - 1);
                        if (randomCheck[t] == 0)
                        {
                            id = t;
                            randomCheck[t] = 1;
                            break;
                        }
                    }
                    int age = 2019 - year + rnd.Next(20, 30);
                    file.WriteLine(String.Format("{0} {1}|{2}|{3}|{4}|{5}", firsta[firstn], lasta[lastn], id, age, joblist[rnd.Next(0, joblist.Length)], year));
                }
                file.Close();
                Console.Write("Do you need more files?[y/n] : ");
                if (Console.ReadLine() == "n")
                {
                    break;
                }
            }
            return 0;   
        }

    }
}
