using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        // Exceptions are errors that c# can't handle. 
        {
            try //all the code that could potentially crash the code will pass to catch 
            {
                // We could throw an exception with 5/0 --> can't divide by 0
                Console.Write("Enter a number: ");
                int num1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter another number: ");
                int num2 = Convert.ToInt32(Console.ReadLine());

                Console.Write(num1 / num2);
            }
            catch(DivideByZeroException e) //takes exception called e
            {
                Console.Write("Error!!! Something went sideways \n");
                Console.Write(e.Message);

            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            /* Although the catch clause can be used without arguments to catch any type of exception, this usage is not recommended. 
            In general, you should only catch those exceptions that you know how to recover from. 
                Therefore, you should always specify an object argument derived from System.Exception */

            Console.ReadLine();
        }
    }
}
