using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A214
{
    class Elist
    {
        public double total = 0;
        private string sfile;
        public List<Employee> elist = new List<Employee>();
        private int exchange = 0;
        private int recursive = 0;
        private int count = 0;
        public Elist(string filename, StreamReader file)
        {
            sfile = filename;
            this.Dataset(file);
        }
        public void Dataset(StreamReader file)
        {
            int n = int.Parse(file.ReadLine());
            for (int i = 0; i < n; i++)//instanciating each employee, n times
            {
                elist.Add(new Employee(file.ReadLine()));//init!
            }
        }
        public void QuickStart()
        {
            QuickSort(0,elist.Count-1);
            Console.WriteLine("===================================");
            Console.WriteLine(String.Format("|{0,-30:s}|", " ** Insertion Sorting Result *** "));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,20:d}|", "Comparison", count));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,20:d}|", "Exchange", exchange));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,20:d}|", "Recursive", recursive-1));
            Console.WriteLine("===================================");
        }
        public void QuickSort(int p, int r)
        {
            recursive += 1;
            if (p < r)
            {
                int q = Partition(p, r);
                QuickSort(p, q - 1);
                QuickSort(q + 1, r);
            }
        }
        public int Partition(int p, int r)
        {
            
            Employee tmp;
            Employee x = elist[r];
            int i = p - 1;
            for(int j = p; j <= r - 1; j++)
            {
                if (elist[j].id <= x.id)
                {
                    i += 1;
                    tmp = elist[i];
                    elist[i] = elist[j];
                    elist[j] = tmp;
                    exchange += 1;
                    if (sfile == "small.txt")
                    {
                        PrintState();
                    }
                }
                count += 1;
            }
            tmp = elist[i+1];
            elist[i+1] = elist[r];
            elist[r] = tmp;
            exchange += 1;
            if (sfile == "small.txt")
            {
                PrintState();
            }
            return i + 1;
        }
        public void PrintState()
        {
            foreach (Employee i in elist)
            {
                Console.Write(String.Format("{0} ", i.id));
            }
            Console.Write("\n");
        }
    }
}
