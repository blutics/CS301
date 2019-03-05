using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A305 {
    public class Employee
    {
        public string name;
        public int id;
        int age;
        string job;
        int year;
        public string rawdata;
        private int index;
        public Employee(string data)
        {
            string[] tmp = data.Split('|');
            name = tmp[0];
            id = int.Parse(tmp[1]);
            age = int.Parse(tmp[2]);
            job = tmp[3];
            year = int.Parse(tmp[4]);
            rawdata = data;
        }
        public void print()//This will print out employee's information with a strict format
        {
            Console.Write(String.Format("Attempting to hash {0,20:s} at index {1,10:d}...", name, index));
        }
        public void setIndex(int k)
        {
            this.index = k;
        }
    }
}