using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A312
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                if (args.Count() == 0)//for the condition file name was not input
                {
                    Console.WriteLine("File name Required!");
                    return 0;
                }
                StreamReader file = new StreamReader(args[0]);
                Tree T = new Tree();
                int n = int.Parse(file.ReadLine());//read the number of command
                while (file.EndOfStream == false)//when meet the end of the file, it ends
                {
                    string[] command = file.ReadLine().Split();
                    switch (command[0])//Figuring out which function requested!
                    {
                        case "ADD":
                            T.TreeInsert(int.Parse(command[1]));
                            break;
                        case "FIND":
                            T.TreeSearch(T.Root, int.Parse(command[1]));
                            break;
                        case "CLEAR":
                            T.TreeClear();
                            break;
                        case "PRINT":
                            T.TreePrint(T.Root);
                            break;
                        case "PREORDER":
                            T.Preorder(T.Root);
                            break;
                        case "INORDER":
                            T.Inorder(T.Root);
                            break;
                        case "POSTORDER":
                            T.Postorder(T.Root);
                            break;
                        default:
                            break;

                    }
                }
            }
            catch (FileNotFoundException)//when file was not found
            {
                Console.WriteLine("File does not Exist!");
            }
            return 1;
        }
    }
}
