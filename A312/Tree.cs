using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A312
{
    class Tree
    {
        public Node Root=null;//once a tree object is instantiated, this Root is empty.

        public void TreeInsert(int inputKey)
        {
            Console.WriteLine(String.Format("Adding {0}", inputKey));
            Node x = this.Root;
            Node y = null;
            Node z = new Node(inputKey);
            while (x != null)
            {
                y = x;
                if (z.key < x.key)//the key value we are going to insert is less than x.key, this loop goes to the left
                {
                    x = x.Left;
                }
                else//otherwise, right side!
                {
                    x = x.Right;
                }
            }
            z.Parent = y;//setting the new node's parents
            if (y == null)
            {
                this.Root = z;//y is null means there's no node in tree, so z will be located at the root
            }
            else if(z.key < y.key)
            {
                y.Left = z;//z will be placed at the left node of the current
            }
            else
            {
                y.Right = z;//to the right node
            }
        }

        public Node TreeSearch(Node x, int key)
        {
            if (x == this.Root)
            {
                Console.Write(String.Format("Looking for {0} :: ", key));//only print this line when the node is root
            }
            if (x==null || key== x.key)
            {
                //when x is null, not found and when key is equal to x.key, x is the one we are looking for
                Console.WriteLine(x!=null?String.Format("{0} : found",x.key):" : not found");
                return x;//this print line is the last print of this recursive line
            }
            if (key < x.key)
            {
                Console.Write("{0} ", x.key);
                return TreeSearch(x.Left, key);
            }
            else
            {
                Console.Write("{0} ", x.key);
                return TreeSearch(x.Right, key);
            }
        }
        
        public void TreeClear()
        {
            this.Root = null;
        }

        public void TreePrint(Node n)
        {
            if (n != null)
            {//controlling for null. when the next node is null, it has to be printed as a string for null
                Console.WriteLine(String.Format("Node: {0,5}.... Left: {1,5}.... Right: {2,5} "
                    , n.key, n.Left!=null?n.Left.key.ToString():"null", n.Right != null ? n.Right.key.ToString() : "null"));
                TreePrint(n.Left);
                TreePrint(n.Right);
            }
        }
        public void Preorder(Node n)
        {
            if (n == this.Root)
            {
                Console.Write("PREORDER: ");
            }
            if (n != null)
            {
                Console.Write(String.Format("{0} ", n.key));//in preorder, print the key first
                Preorder(n.Left);
                Preorder(n.Right);
            }
            if (n == this.Root)
            {
                Console.WriteLine();
            }
        }
        public void Inorder(Node n)
        {
            if (n == this.Root)
            {
                Console.Write("INORDER: ");
            }
            if (n != null)
            {
                Inorder(n.Left);
                Console.Write(String.Format("{0} ", n.key));//in inorder, print the key when the left node is completed
                Inorder(n.Right);
            }
            if (n == this.Root)
            {
                Console.WriteLine();
            }
        }
        public void Postorder(Node n)
        {
            if (n == this.Root)
            {
                Console.Write("POSTORDER: ");
            }
            if (n != null)
            {
                Postorder(n.Left);
                Postorder(n.Right);
                Console.Write(String.Format("{0} ", n.key));//in postorder, print the key when both nodes are completed
            }
            if (n == this.Root)
            {
                Console.WriteLine();
            }
        }

    }
}
