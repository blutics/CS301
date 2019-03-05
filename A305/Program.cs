using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A305
{
    class Program
    {
        static void Main(string[] args)
        {
            new HashTableOne("hash1.txt");
            new HashTableOne("hash2.txt");
            new HashTableOne("hash3.txt");

            new HashTableTwo("hash1.txt");
            new HashTableTwo("hash2.txt");
            new HashTableTwo("hash3.txt");

            new HashTableThree("hash4.txt");
            new HashTableThree("hash5.txt");
            new HashTableThree("hash6.txt");
        }
    }
}
