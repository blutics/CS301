using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A305
{
    class HashTableThree
    {
        private List<Employee>[] hashTable;
        private List<Employee> employees = new List<Employee>();
        private int count = 0;
        public HashTableThree(string filename)
        {
            try
            {
                StreamReader file = new StreamReader(filename);
                int m = int.Parse(file.ReadLine());
                int n = int.Parse(file.ReadLine());
                this.hashTable = new List<Employee>[m + 1];
                int k;
                for(int i = 0; i < m; i++)
                {
                    hashTable[i] = new List<Employee>();
                }
                Console.WriteLine(String.Format("Hashing Algorithm Part 3 >>>> FileName : {0}", filename));
                for (int i = 0; i < n; i++)//instanciating each employee, n times, also put the item in a right place
                {
                    employees.Add(new Employee(file.ReadLine()));//init!
                    k = employees[i].id % m;//calculating key number!
                    employees[i].setIndex(k);
                    employees[i].print();
                    Console.WriteLine(String.Format(" ({0} collisions)", hashTable[k].Count));
                    if (hashTable[k].Count != 0)
                    {
                        count++;
                    }
                    hashTable[k].Add(employees[i]);
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
