using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            WhileLoopSample();
            ForLoopSample();
            
            Console.ReadLine();
        }
    
    static void ForLoopSample()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Value of i: {0}", i);
            }
        }
    static void DoWhileLoopSample()
        {
            int index = 2;
            do
            {
                Console.WriteLine("Running do while");
            } while (index <= 2);
        }
    static void WhileLoopSample() {
            int index = 1;
            while (index <= 10)
            {
                Console.WriteLine($"Current count = {index}");
                index++;

            }
        }
    }
}
