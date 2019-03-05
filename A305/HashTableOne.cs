using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A305
{
    class HashTableOne
    {
        private Employee[] hashTable;
        private List<Employee> employees = new List<Employee>();
        private int count = 0;
        public HashTableOne(string filename)
        {
            try
            {
                StreamReader file = new StreamReader(filename);
                int m = int.Parse(file.ReadLine());
                int n = int.Parse(file.ReadLine());
                this.hashTable = new Employee[m+1];
                int k;
                Console.WriteLine(String.Format("Hashing Algorithm Part 1 >>>> FileName : {0}", filename));
                for (int i = 0; i < n; i++)//instanciating each employee, n times
                {
                    employees.Add(new Employee(file.ReadLine()));//init!
                    k = employees[i].id % m;
                    employees[i].setIndex(k);
                    employees[i].print();
                    if (hashTable[k] != null)
                    {
                        Console.WriteLine(String.Format("Collision with {0}!", hashTable[k].name));
                        count++;
                    }
                    else
                    {
                        hashTable[k] = employees[i];
                        Console.WriteLine("Success!");
                    }
                }
                Console.WriteLine(String.Format("Total collisions : {0}\n\n", count));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("the file does not exit!");
            }
        }
    }
}
