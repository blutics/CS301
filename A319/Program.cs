using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A319
{
    class Program
    {
        public static int PrintLCS(int [,] table2, string x, int i, int j)
        {
            if(i==0 || j == 0)//when it reaches to the point either x is 0 or y is 0, it start to print words
            {
                return 0;
            }
            if (table2[i, j] == 2)
            {
                PrintLCS(table2, x, i - 1, j - 1);
                Console.Write(x[i-1]);//when it reaches to the diagonal signal, print the word not in i, but in i-1
            }else if (table2[i, j] == 1)
            {
                PrintLCS(table2, x, i - 1, j);
            }
            else
            {
                PrintLCS(table2, x, i, j - 1);
            }
            return 0;
        }
        static void Main(string[] args)
        {
            try
            {
                StreamReader file = new StreamReader(args[0]);
                //StreamReader file = new StreamReader("lcs4.txt");
                string x = file.ReadLine();
                string y = file.ReadLine();
                int m = x.Length;
                int n = y.Length;
                int[,] table = new int[m + 1, n + 1];
                int[,] table2 = new int[m + 1, n + 1];
                for (int i = 1; i < m + 1; i++)//initiating the first column
                {
                    table[i, 0] = 0;
                }
                for (int j = 0; j < n + 1; j++)//initiating the first row with 0
                {
                    table[0, j] = 0;
                }
                for(int i = 1; i <= m; i++)
                {
                    for(int j = 1; j <= n; j++)
                    {
                        if (x[i-1] == y[j-1])//different point from the pseudo code!
                        {
                            table[i, j] = table[i - 1, j - 1] + 1;
                            table2[i, j] = 2;//diagonal
                        }else if (table[i - 1, j] >= table[i, j - 1])
                        {
                            table[i, j] = table[i - 1, j];
                            table2[i, j] = 1;
                        }
                        else
                        {
                            table[i, j] = table[i, j - 1];
                            table2[i, j] = 3;
                        }
                    }
                }
                Console.WriteLine(String.Format("String X: {0}", x));
                Console.WriteLine(String.Format("String Y: {0}", y));
                Console.Write("LCS : ");
                PrintLCS(table2, x, m, n);
                Console.Write("\n");
                file.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("file was not found!");

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("This program requires a file!");
            }
        }
    }
}
