using System;
using System.Collections.Generic;
using System.Collections; //allows the use of dynamic array 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // the [] signifies we're declaring an array of integers
            int[] luckyNumbers = { 4, 7, 15, 42 }; // populating right away

            Console.WriteLine(luckyNumbers[1]); // first index of the array
            luckyNumbers[2] = 9;

            string[] friends = new string[9];
            //if not sure how many elements will fill, declaring a new element with sizing limits

            //dynamic array
            ArrayList al = new ArrayList();

            al.Add(577);
            al.Add(286);


            Console.ReadLine();
        }
    }
}


//int[] x;  // can store int values
//string[] s; // can store string values
//double[] d; // can store double values
//Student[] stud1; // can store instances of Student class which is custom class
//Dynamic arrays: https://www.tutorialspoint.com/What-are-dynamic-arrays-in-Chash