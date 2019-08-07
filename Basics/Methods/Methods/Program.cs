using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            int cubeNumber = NumToPower(5);
            // method, similar to functions 
            SayHi("Jose");// calling from main method
            SayHi("Yoshi", 38);// calling from main method
            Console.Write(NumToPower(3));//need to pass on console write 
            Console.ReadLine();
        }

        //when creating a method declare 
        //void means it is not returning anything naming convention in relation to use
        static void SayHi(string name, int age = 18) //takes in args the variable/parameters are the actual value
        {
            Console.WriteLine($"Hello {name}! Your age is {age}");
        }
        //return statement
        static int NumToPower(int num, int factor = 3)
        {
            int result = num * num *num;
            return result;
        }
    }
}
