using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A117
{
    public class Employee
    {
        string name;
        int id;
        int age;
        string job;
        int year;
        public Employee(string data)
        {
            string[] tmp = data.Split('|');
            name = tmp[0];
            id = int.Parse(tmp[1]);
            age = int.Parse(tmp[2]);
            job = tmp[3];
            year = int.Parse(tmp[4]);
        }
        public void print()//This will print out employee's information with a strict format
        {
            Console.WriteLine("===================================");
            Console.WriteLine(String.Format("|{0,-10:s} : {1,-20:s}|", "Name", name));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,-20:d}|", "ID", id));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,-20:d}|", "Age", age));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,-20:s}|", "Job", job));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,-20:d}|", "year", year));
            Console.WriteLine("===================================");
        }
    }
}