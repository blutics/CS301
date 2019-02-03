using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A207
{
    class Elist
    {
        public double total = 0;
        private string sfile;
        public List<Employee> elist = new List<Employee>();
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
        public void Merge(int p, int q, int r)
        {
            int n1 = q - p + 1;
            int n2 = r - q ;
            Employee[] Left = new Employee[n1+1];
            Employee[] Right = new Employee[n2+1];
            for(int i = 0; i < n1; i++)
            {
                Left[i] = elist[p+i];
            }
            for(int j = 0; j < n2; j++)
            {
                Right[j] = elist[q+j+1];
            }
            Left[n1] = new Employee(elist[0].rawdata);
            Right[n2] = new Employee(elist[0].rawdata);
            Left[n1].id = 999999999;
            Right[n2].id = 999999999;
            int a = 0;
            int b = 0;
            for(int k = p; k <= r; k++)
            {
                count += 1;
                if (Left[a].id <= Right[b].id)
                {
                    elist[k] = Left[a];
                    a += 1;
                }
                else
                {
                    elist[k] = Right[b];
                    b += 1;
                }
            }
        }
        public void MergeSort(int p, int r)
        {
            if (p < r)
            {
                int q = (int)((p + r) / 2);
                
                MergeSort(p, q);
                MergeSort(q+1, r);
                Merge(p, q, r);
                if (sfile == "small.txt")
                {
                    PrintState();
                }
            }
            
        }
        public void MergeStart()
        {
            MergeSort(0, elist.Count - 1);
            StreamWriter file = new StreamWriter("output.txt");
            foreach (Employee k in elist)//the resulte stores at the output.txt file
            {
                file.WriteLine(k.RawPrint());
            }
            file.Close();
            Console.WriteLine("===================================");
            Console.WriteLine(String.Format("|{0,-30:s}|", " ** Insertion Sorting Result *** "));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,20:d}|", "Comparison", count));
            Console.WriteLine("===================================");
        }
        private void PrintState()
        {
            foreach (Employee i in elist)
            {
                Console.Write(String.Format("{0} ", i.id));
            }
            Console.Write("\n");
        }
    }
}
