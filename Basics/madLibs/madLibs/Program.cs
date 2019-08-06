using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madLibs
{
    class Program
    {
        static void Main(string[] args)
        {
            string color, pluralNoun, random; //can declare multiple times
            Console.Write("Enter a color: ");
            color = Console.ReadLine();
            Console.Write("Enter a plural noun: ");
            pluralNoun = Console.ReadLine();
            Console.Write("Enter something random : ");
            random = Console.ReadLine();

            Console.WriteLine($"\nRoses are {color}");
            Console.WriteLine($"{pluralNoun} are blue");
            Console.WriteLine($"Marco..... {random}");


            Console.ReadLine();
        }
    }
}
