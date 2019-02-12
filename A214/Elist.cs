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
            List<Employee> tmp = new List<Employee>(elist);
            QuickSort(0,elist.Count-1);
            Console.WriteLine("====================================================");
            Console.WriteLine(String.Format("|{0,-50:s}|", " ** Regular Quick Sorting Result *** "));
            Console.WriteLine(String.Format("|{0,-30:s} : {1,17:d}|", "Comparison", count));
            Console.WriteLine(String.Format("|{0,-30:s} : {1,17:d}|", "Exchange", exchange));
            Console.WriteLine(String.Format("|{0,-30:s} : {1,17:d}|", "Recursive", recursive - 1));
            Console.WriteLine("====================================================");
            OutputToFile("output_regular.txt");
            elist = tmp;
            exchange = 0;
            count = 0;
            recursive = 0;
            tmp = new List<Employee>(elist);
            RandomizedQuickSort(0, elist.Count - 1);
            Console.WriteLine("====================================================");
            Console.WriteLine(String.Format("|{0,-50:s}|", " ** Randomized Quick Sorting Result *** "));
            Console.WriteLine(String.Format("|{0,-30:s} : {1,17:d}|", "Comparison", count));
            Console.WriteLine(String.Format("|{0,-30:s} : {1,17:d}|", "Exchange", exchange));
            Console.WriteLine(String.Format("|{0,-30:s} : {1,17:d}|", "Recursive", recursive - 1));
            Console.WriteLine("====================================================");
            OutputToFile("output_randomized.txt");
            elist = tmp;
            exchange = 0;
            count = 0;
            recursive = 0;
            tmp = new List<Employee>(elist);
            TailRecursiveQuickSort(0, elist.Count - 1);
            Console.WriteLine("====================================================");
            Console.WriteLine(String.Format("|{0,-50:s}|", " ** Tail-Recursive Quick Sorting Result *** "));
            Console.WriteLine(String.Format("|{0,-30:s} : {1,17:d}|", "Comparison", count));
            Console.WriteLine(String.Format("|{0,-30:s} : {1,17:d}|", "Exchange", exchange));
            Console.WriteLine(String.Format("|{0,-30:s} : {1,17:d}|", "Recursive", recursive - 1));
            Console.WriteLine("====================================================");
            OutputToFile("output_tail.txt");
            elist = tmp;
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
        public int RandomizedPartition(int p, int r)
        {
            Random rnd = new Random();
            int i = rnd.Next(p, r);
            Employee tmp = elist[i];
            elist[i] = elist[r];
            elist[r] = tmp;
            exchange += 1;
            return Partition(p, r);
        }
        public void RandomizedQuickSort(int p, int r)
        {
            recursive += 1;
            if (p < r)
            {
                int q = RandomizedPartition(p, r);
                RandomizedQuickSort(p, q - 1);
                RandomizedQuickSort(q + 1, r);
            }
        }
        public void TailRecursiveQuickSort(int p, int r)
        {
            int q;
            recursive += 1;
            while (p < r)
            {
                q = Partition(p, r);
                TailRecursiveQuickSort(p, q - 1);
                p = q + 1;
            }
        }
        public void PrintState()
        {
            foreach (Employee i in elist)
            {
                Console.Write(String.Format("{0} ", i.id));
            }
            Console.Write("\n");
        }
        public void OutputToFile(string filename)
        {
            StreamWriter file = new StreamWriter(filename);
            for (int i = 0; i < elist.Count; i++)//the resulte stores at the output.txt file
            {
                file.WriteLine(elist[i].RawPrint());
            }
            file.Close();
        }
    }
}
