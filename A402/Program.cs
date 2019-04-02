using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A402
{
    class Program
    {
        static int[] root = new int[100];
        static int length = 0;
        static int weight = 0;
        static Hashtable T = new Hashtable();
        static List<Edge> Edges = new List<Edge>();
        static List<Edge> Result = new List<Edge>();
        static void Main(string[] args)
        {
            try {
                StreamReader file = new StreamReader(args[0]);
                string letters = file.ReadLine();
                length = letters.Length;
                for (int i = 0; i < letters.Length; i++)//setting up the hashtable
                {
                    T[letters[i]] = i;
                }
                for (int i = 0; i < 100; i++)
                {
                    root[i] = i;
                }
                while (!file.EndOfStream)//saving outputs
                {
                    string input = file.ReadLine();
                    Edges.Add(new Edge(input));
                }
                Edges.Sort(delegate (Edge A, Edge B)//sorting
                {
                    if (A.w > B.w) return 1;
                    else if (A.w < B.w) return -1;
                    else return 0;
                });
                foreach (Edge k in Edges)//calulating
                {
                    if (find((int)T[k.vertex[0]]) != find((int)T[k.vertex[1]]))//figuring out if it is making cycle or not
                    {
                        union((int)T[k.vertex[0]], (int)T[k.vertex[1]]);
                        Result.Add(k);
                        weight += k.w;
                    }
                }
                Console.WriteLine(String.Format("MST has a weight of {0} and consists of these edges:", weight));
                foreach (Edge k in Result)//printing result
                {
                    k.print();
                }
            } catch (FileNotFoundException)
            {
                Console.WriteLine("Fie is not found!");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("File necessary!");
            }
            
        }
        static int find(int x)//looking up the root node
        {
            return root[x]==x?x:find(root[x]);
        }
        static void union(int x, int y)//grouping!
        {
            int a = find(x);
            int b = find(y);
            root[b] = a;
        }
    }
}
