using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace A117
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StreamReader file = new StreamReader(args[0]);//SteamReader will be used for reading text from file
                int n = int.Parse(file.ReadLine());
                Employee[] employeelist = new Employee[n];//making a array for employee objects
                for (int i = 0; i < n; i++)//instanciating each employee, n times
                {
                    employeelist[i] = new Employee(file.ReadLine());//init!
                    employeelist[i].print();
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(String.Format("{0} does not exist!", args[0]));
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Require a text file.");
            }
        }
    }
}
