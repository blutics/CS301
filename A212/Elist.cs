using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A212
{
    class Elist
    {
        public double total = 0;
        private string sfile;
        public List<Employee> elist = new List<Employee>();
        private int count = 0;
        private int exchange = 0;
        private int heapsize;
        public Elist(string filename, StreamReader file)
        {
            sfile = filename;
            this.Dataset(file);
        }
        public void Dataset(StreamReader file)
        {
            int n = int.Parse(file.ReadLine());
            heapsize = n-1;
            elist.Add(new Employee("FirstElement|0|0|0|0"));
            for (int i = 0; i < n; i++)//instanciating each employee, n times
            {
                elist.Add(new Employee(file.ReadLine()));//init!
            }
        }
        private int Left(int i)
        {
            return 2 * i;
        }
        private int Right(int i)
        {
            return 2 * i + 1;
        }
        public int Parent(int i)
        {
            return (int)(i / 2);
        }
        public void MaxHeapify(int i)
        {
            int l = Left(i);
            int r = Right(i);
            int largest;
            count += 5;
            if(l<=heapsize && elist[l].id > elist[i].id)
            {
                largest = l;
            }
            else
            {
                largest = i;
            }
            if(r<=heapsize && elist[r].id > elist[largest].id)
            {
                largest = r;
            }
            if (largest != i)
            {
                Employee tmp = elist[i];
                elist[i] = elist[largest];
                elist[largest] = tmp;
                exchange += 1;
                MaxHeapify(largest);
            }
        }
        public void BuildMaxHeap()
        {
            heapsize = elist.Count-1;
            for(int i = (int)(elist.Count / 2); i >= 1; i--)
            {
                MaxHeapify(i);
            }
            
        }
        public void HeapSort()
        {
            if (sfile == "small.txt")
            {
                PrintState();
            }
            BuildMaxHeap();
            for (int i = elist.Count-1; i >= 2; i--)
            {
                if (sfile == "small.txt")
                {
                    PrintState();
                }
                Employee tmp = elist[1];
                elist[1] = elist[i];
                elist[i] = tmp;
                heapsize -= 1;
                exchange += 1;
                MaxHeapify(1);
                
            }
            if (sfile == "small.txt")
            {
                PrintState();
            }
            Console.WriteLine("===================================");
            Console.WriteLine(String.Format("|{0,-30:s}|", " ** Heap Sorting Result *** "));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,20:d}|", "Comparison", count));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,20:d}|", "Exchange", exchange));
            Console.WriteLine("===================================");

            StreamWriter file = new StreamWriter("output.txt");
            for (int i=1;i<elist.Count;i++)//the resulte stores at the output.txt file
            {
                file.WriteLine(elist[i].RawPrint());
            }
            file.Close();
        }
        public void PrintState()
        {
            for (int i= 1;i < elist.Count;i++)
            {
                Console.Write(String.Format("{0} ", elist[i].id));
            }
            Console.Write("\n");
        }
    }
}
