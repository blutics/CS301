using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A307
{
    class HashTable
    {
        private List<Employee>[] hashTable;
        private List<Employee> employees = new List<Employee>();
        public int count = 0;
        private int secretNumber;
        public HashTable(string filename)
        {
            try
            {
                StreamReader file = new StreamReader(filename);
                secretNumber = int.Parse(file.ReadLine());
                int n = int.Parse(file.ReadLine());
                this.hashTable = new List<Employee>[secretNumber + 1];
                int k;
                for(int i = 0; i < secretNumber; i++)
                {
                    hashTable[i] = new List<Employee>();
                }
                Console.WriteLine(String.Format("Hashing Algorithm Part 3 >>>> FileName : {0}", filename));
                for (int i = 0; i < n; i++)//instanciating each employee, n times, also put the item in a right place
                {
                    employees.Add(new Employee(file.ReadLine()));//init!
                    k = MakeKey(employees[i].name);//calculating key number!
                    employees[i].setIndex(k);
                    employees[i].print();
                    Console.WriteLine(String.Format(" ( {0, 2} collisions )", hashTable[k].Count));
                    hashTable[k].Add(employees[i]);
                }
                Console.WriteLine("**********************************************************************");
                file.ReadLine();
                int q = int.Parse(file.ReadLine());
                for(int i = 0; i < q; i++)
                {
                    Query(file.ReadLine());
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("the file does not exit!  <<<<<<<<<<<<<<<<<");
            }
        }
        private int MakeKey(string given)
        {
            int seed = given.Length;
            foreach(char i in given)
            {
                seed += (int)i;
            }
            return (int)(secretNumber * ((seed * (Math.Sqrt(5) - 1) / 2) % 1));
        }
        public Boolean Query(string name)
        {
            int tmp = MakeKey(name);
            foreach(Employee i in hashTable[tmp])
            {
                count++;
                if (i.name == name)
                {
                    Console.WriteLine("=====================================================================");
                    Console.WriteLine(String.Format("{0} after {1} collisions at index {2} in the hashtable.", i.name, hashTable[tmp].Count, tmp));
                    i.PrintInfo();
                    return true;
                }
            }
            Console.WriteLine("===================================");
            Console.WriteLine(String.Format("|{0,-10:s} : {1,-30:s}|", name, "doesn't exist in the table."));
            Console.WriteLine("===================================");
            return false;
        }
    }
}
