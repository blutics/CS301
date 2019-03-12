using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A312
{
    class Node
    {
        public int key;
        public Node Parent = null;
        public Node Right = null;
        public Node Left = null;
        public Node(int key)//constructor for Node class
        {
            this.key = key;
        }
    }
}
