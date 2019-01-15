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
            StreamReader file = new StreamReader("test.txt");
            int n = int.Parse(file.ReadLine());
            Employee[] employeelist = new Employee[n];
            for(int i = 0; i < n; i++)
            {
                employeelist[i] = new Employee(file.ReadLine());
                employeelist[i].print();
            }
        }
    }
}
