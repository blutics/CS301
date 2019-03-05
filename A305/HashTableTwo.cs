using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A305
{
    class HashTableTwo
    {
        private Employee[] hashTable;
        private List<Employee> employees = new List<Employee>();
        private int count = 0;
        public HashTableTwo(string filename)
        {
            try
            {
                StreamReader file = new StreamReader(filename);
                int m = int.Parse(file.ReadLine());
                int n = int.Parse(file.ReadLine());
                this.hashTable = new Employee[m + 1];
                int k;
                Console.WriteLine(String.Format("Hashing Algorithm Part 2 >>>> FileName : {0}", filename));
                for (int i = 0; i < n; i++)//instanciating each employee, n times, also put the item in a right place
                {
                    employees.Add(new Employee(file.ReadLine()));//init!
                    k = (int)(m*((employees[i].id*(Math.Sqrt(5)-1)/2) % 1));//calculating key number!
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

