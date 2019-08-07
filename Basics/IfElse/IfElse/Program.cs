using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IfElse
{
    class Program
    {
        static void Main(string[] args)
        {
            Sample1();
            Console.WriteLine(GetMax(9, 200,100));
            Console.ReadLine();
        }

        static int GetMax(int num1, int num2, int num3)
        {
            int result;
            if (num1 >= num2 && num1 >= num3)
            {
                result = num1;
            }
            else if (num2 >= num1 && num2>=num3)
            {
                result = num2;
            }
            else
            {
                result = num3;
            }
            return result;
        }
        static void Sample1()
        {
            bool isMale = true;
            bool isTall = false;

            if (isMale && isTall) //check operators 
            {
                Console.Write("Is male and tall");
            }
            else if (isMale || !isTall)
            {
                Console.WriteLine("Is Male and not tall");
            }
            else
            {
                Console.Write("Male and height not verified");
            }

        }
    }
}
