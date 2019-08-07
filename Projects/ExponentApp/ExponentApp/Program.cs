using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExponentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(GetPower(5, 5));
            Console.ReadLine();
        }
        static int GetPower(int baseNum, int powNum)
        {
            int result = 1;
            for(int i = 0; i< powNum; i++)
            {
                result = result * baseNum;
            }
            return result;
        }
    }
}
