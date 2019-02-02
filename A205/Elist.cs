using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A205
{
    class Elist
    {
        public double total = 0;
        private string sfile;
        public List<Employee> elist = new List<Employee>();
        public Elist(string filename)
        {
            sfile = filename;
            this.Dataset(filename);
        }
        public void Dataset(string filename)
        {
            try
            {
                StreamReader file = new StreamReader(filename);//SteamReader will be used for reading text from file
                int n = int.Parse(file.ReadLine());
                for (int i = 0; i < n; i++)//instanciating each employee, n times
                {
                    elist.Add(new Employee(file.ReadLine()));//init!
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(String.Format("{0} does not exist!", filename));
            }
        }
        private void SwapEmployees(int a, int b)
        {
            Employee tmp = elist[b];
            elist[b] = elist[a];
            elist[a] = tmp;
        }
        public void SelectionSort()
        {
            int min;
            int minIndex;
            int n = elist.Count;
            for(int i = 0; i < n-1; i++)
            {
                min = elist[i].id;
                minIndex = i;
                for(int j = i; j < n; j++)
                {
                    if (elist[j].id < min)
                    {
                        min = elist[j].id;
                        minIndex = j;
                    }
                }
                SwapEmployees(i, minIndex);
                if (sfile == "small.txt")
                {
                    PrintState();
                }
            }
            StreamWriter file = new StreamWriter("output.txt");
            foreach(Employee k in elist)//the resulte stores at the output.txt file
            {
                file.WriteLine(k.RawPrint());
            }
            file.Close();
            Console.WriteLine("===================================");
            Console.WriteLine(String.Format("|{0,-30:s}|", " ** Insertion Sorting Result *** "));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,20:d}|", "Comparison", n*(n+1)/2-1));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,20:d}|", "Exchange", elist.Count-1));
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
