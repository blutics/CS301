using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A124
{
    class Elist
    {
        public List<Employee> elist = new List<Employee>();
        public Elist(string filename)
        {
            this.Dataset(filename);
        }
        public void Dataset(string filename)
        {
            try
            {
                Console.WriteLine(filename);
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
        public void Query(int number, int target)
        {
            int[] result = BinarySearch(target);//index 0 : position, index 1 : comparision time
            int j = result[0];
            Console.WriteLine("==============================================");
            Console.WriteLine(String.Format("|{0,-15:s} : {1,25:d} |", "Query Number", number + 1));
            Console.WriteLine(String.Format("|{0,-15:s} : {1,25:d} |", "Target ID", target));
            Console.WriteLine(String.Format("|{0,-15:s} : {1,25:s} |", "Resulted Name", elist[j].name));
            Console.WriteLine(String.Format("|{0,-15:s} : {1,25:d} |", "Position", j));
            Console.WriteLine(String.Format("|{0,-15:s} : {1,25:d} |", "Comparison Time", result[1]));
            Console.WriteLine("==============================================");
        }
        private int[] BinarySearch(int target)
        {
            int low = 0;//This case always start from index 0
            int high  = elist.Count;//high value should be the size of the range
            int mid  = 0;
            int times = 0;
            while (low < high)//when high is equal to or less than low, this loop ends
            {
                mid = (int)((low + high) / 2);//for every loop, reset the middle position
                if (target <= elist[mid].id)//target value is less than or equal to the value in the middle
                {
                    high = mid;//set high with the value in the mid variable
                }
                else//otherwise, low sets with the mid value + 1
                {
                    low = mid + 1;
                }
                times += 1;//counting comparison time
            }
            return new int[] { high, times };//return position with high and comparison time with times
        }
    }
}
