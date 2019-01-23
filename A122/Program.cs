using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//pwd : C:\Users\Student\Desktop\CS301\A122\bin\Debug
//potential running command : A122.exe roster100.txt queries_linear.txt
//running command with manual file : A122.exe roster100k.txt queries_10k.txt
namespace A122
{
    class Program
    {
        static void Main(string[] args)
        {
            int current = 0;
            try
            {
                StreamReader file = new StreamReader(args[0]);//SteamReader will be used for reading text from file
                //StreamReader file = new StreamReader("roster100k.txt");
                current = 1;
                int n = int.Parse(file.ReadLine());
                Employee[] employeelist = new Employee[n];//making a array for employee objects
                for (int i = 0; i < n; i++)//instanciating each employee, n times
                {
                    employeelist[i] = new Employee(file.ReadLine());//init!
                }
                StreamReader query = new StreamReader(args[1]);
                //StreamReader query = new StreamReader("queries_10k.txt");
                double total = 0;
                int m = int.Parse(query.ReadLine());
                for(int i = 0; i < m; i++)
                {
                    int target = int.Parse(query.ReadLine());
                    for (int j = 0; j < employeelist.Length; j++)
                    {
                        if (employeelist[j].id == target)
                        {
                            Console.WriteLine("==============================================");
                            Console.WriteLine(String.Format("|{0,-15:s} : {1,25:d} |", "Query Number", i+1));
                            Console.WriteLine(String.Format("|{0,-15:s} : {1,25:d} |", "Target ID", target));
                            Console.WriteLine(String.Format("|{0,-15:s} : {1,25:s} |", "Resulted Name", employeelist[j].name));
                            Console.WriteLine(String.Format("|{0,-15:s} : {1,25:d} |", "Position", j));
                            Console.WriteLine(String.Format("|{0,-15:s} : {1,25:d} |", "Comparison Time", j+1));
                            Console.WriteLine("==============================================");
                            total += j + 1;
                            break;
                        }
                    }
                }
                Console.WriteLine(String.Format("The average comparison time is {0}.", total/m));

            }
            catch (FileNotFoundException)
            {
                if (current == 0)
                {
                    Console.WriteLine(String.Format("{0} does not exist!", args[0]));
                }
                else
                {
                    Console.WriteLine(String.Format("{0} does not exist!", args[1]));
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Not enough parameters!");
            }
        }
    }
}
