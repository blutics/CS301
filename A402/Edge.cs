using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A402
{
    class Edge
    {
        public char[] vertex = new char[2];
        public int w;
        public string line;
        public Edge(string line)
        {
            this.line = line;
            string[] data = line.Split(' ');
            this.vertex[0] = data[0][0];
            this.vertex[1] = data[1][0];
            this.w = int.Parse(data[2]);
        }
        public void print()
        {
            Console.WriteLine(this.line);
        }

    }
}
