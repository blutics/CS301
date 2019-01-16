using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A115
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = 0;//the variable for the input of age
            while (true)
            {
                Console.WriteLine("This is a TeenPower Detector of DG Company.");
                Console.Write("How old are you? ");//the line for asking age
                age = int.Parse(Console.ReadLine());
                if (age < 13)
                {
                    //Condition under teen age
                    Console.WriteLine("No Teen Power on You!");
                    Console.WriteLine(String.Format("After {0} year(s), You will feel Almighty Strength on you body!\n", 13 - age));
                }
                else if (age > 19)
                {
                    //Condition over teen age 
                    Console.WriteLine("No Teen Power on You!");
                    Console.WriteLine(String.Format("You lost your TeenPower {0} years ago.", age - 19));
                    Console.WriteLine("It's time to find another energy for the rest of your life.\n");
                }
                else
                {
                    //TeenAge Condition
                    for (int i = 1; i <= age; i++)//Iterating age times
                    {
                        Console.WriteLine(String.Format("TEEN POWER!!! {0}", i));
                    }
                    Console.WriteLine(String.Format("\nWe found total of {0} TEEN POWER on you.\nCongratulation!\n", age));
                }
                Console.Write("Play again? [y/n] ");
                string again = Console.ReadLine();
                //the line for asking the player to keep playing.
                if (again != "y") break;//if the input is yes plays again, otherwise it goes out of while loop
                Console.Clear();//when the player choose to play again, the last round output goes away
                                //This make console clean.
            }


        }
    }
}
