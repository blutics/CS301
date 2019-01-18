using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace A122
{
    class Program
    {
        static void Main(string[] args)
        {
            int current = 0;
            try
            {
                //StreamReader file = new StreamReader(args[0]);//SteamReader will be used for reading text from file
                StreamReader file = new StreamReader("roster100.txt");
                current = 1;
                int n = int.Parse(file.ReadLine());
                Employee[] employeelist = new Employee[n];//making a array for employee objects
                for (int i = 0; i < n; i++)//instanciating each employee, n times
                {
                    employeelist[i] = new Employee(file.ReadLine());//init!
                }
                //StreamReader query = new StreamReader(args[1]);
                StreamReader query = new StreamReader("queries_linear.txt");
                int m = int.Parse(query.ReadLine());
                for(int i = 0; i < m; i++)
                {
                    int target = int.Parse(query.ReadLine());
                    for (int j = 0; j < employeelist.Length; j++)
                    {
                        if (employeelist[j].id == target)
                        {
                            Console.WriteLine("===================================");
                            Console.WriteLine(String.Format("|{0,-10:s} : {1,-20:s}|", "Target ID", target));
                            Console.WriteLine(String.Format("|{0,-10:s} : {1,-20:d}|", "Resulted Name", employeelist[j].name));
                            Console.WriteLine(String.Format("|{0,-10:s} : {1,-20:d}|", "Position", j));
                            Console.WriteLine(String.Format("|{0,-10:s} : {1,-20:s}|", "Comparison Time", j+1));
                            Console.WriteLine("===================================");
                        }
                    }
                }

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
