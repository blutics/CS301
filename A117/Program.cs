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
            StreamReader file = new StreamReader("test.txt");//SteamReader will be used for reading text from file
            int n = int.Parse(file.ReadLine());
            Employee[] employeelist = new Employee[n];//making a array for employee objects
            for(int i = 0; i < n; i++)//instanciating each employee, n times
            {
                employeelist[i] = new Employee(file.ReadLine());//init!
                employeelist[i].print();
            }
        }
    }
}
