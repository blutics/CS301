using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A129
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
        public void BubbleSort()//bubble sort algorithm
        {
            Employee tmp;
            int count = 0;
            int n = elist.Count;
            for(int i = 1; i <= n-1; i++)
            {
                for(int j = n-1; j >= i; j--)//starts from the last to i
                {
                    if (elist[j].id < elist[j - 1].id)
                    {
                        tmp = elist[j];
                        elist[j] = elist[j - 1];
                        elist[j - 1] = tmp;
                        count += 1;
                        if (sfile.Equals("small.txt"))//once the small.txt case
                        {
                            this.PrintState();
                        }
                    }
                }
            }
            StreamWriter file = new StreamWriter("output.txt");//the output goes into the output file.
            foreach(Employee i in elist)
            {
                file.WriteLine(i.RawPrint());
            }
            Console.WriteLine("===================================");
            Console.WriteLine(String.Format("|{0,-30:s}|", "  *** Bubble Sorting Result ***  "));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,20:d}|", "Comparison", n*(n-1)/2));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,20:d}|", "Exchange", count));
            Console.WriteLine("===================================");
        }
        private void PrintState()//print out the current order of ids
        {
            foreach(Employee i in elist)
            {
                Console.Write(String.Format("{0} ",i.id));
            }
            Console.Write("\n");
        }
    }
}
