using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var dictionary = new Dictionary<string,string>()
            {
                {"+","Random"},
            };
            Console.Write("Enter a number: ");                 
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Operator: ");
            string op = Console.ReadLine();

            Console.Write("Enter another number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            if(op == "+")
            {
                Console.Write(num1 + num2);
            }else if(op == "*")
            {
                Console.Write(num1 * num2);
            }else if(op == "/")
            {
                Console.Write(num1 / num2);
            }
            else
            {
                Console.WriteLine("Sorry, invalid operator");
            }

            Console.ReadLine();
        }

    }
}
