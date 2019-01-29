using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A131
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
        public void InsertionSort()
        {
            Employee key;
            int count = 0;//exchange count
            int bcount = 0;//comparison count
            int n = elist.Count;
            int i;
            for (int j = 1; j < n; j++)
            {
                key = elist[j];//element in j will be swapped
                i = j - 1;
                while (i>=0)
                {
                    if(elist[i].id < key.id)
                    {
                        break;
                    }
                    elist[i + 1] = elist[i];
                    i -= 1;
                    count += 1;
                    bcount += 1;
                }
                elist[i + 1] = key;//put the key object in the right place
                count += 1;
                if (sfile.Equals("small.txt"))
                {
                    this.PrintState();
                }
            }
            StreamWriter file = new StreamWriter("output.txt");
            foreach(Employee k in elist)//the resulte stores at the output.txt file
            {
                file.WriteLine(k.RawPrint());
            }
            Console.WriteLine("===================================");
            Console.WriteLine(String.Format("|{0,-30:s}|", " ** Insertion Sorting Result *** "));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,20:d}|", "Comparison", bcount));
            Console.WriteLine(String.Format("|{0,-10:s} : {1,20:d}|", "Exchange", count));
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
