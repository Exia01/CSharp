using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            //creating an instance from the class-> specification
            Book book1 = new Book("Gone with the Wind", "Some Author", 200);
            Book book2 = new Book("Gone with the Earth", "Some Author", 400);

            Console.WriteLine(book2.title);
            Console.WriteLine(book1.HasPages());
            book1.Rating = "Slakeddsafd";
            Console.WriteLine(book1.Rating);
            Console.WriteLine(Book.TotalBookCount());
            Tools.Distributor("Amazon");
           
            Console.ReadLine();

        }
    }
}

//Please see inheritance Here:https://csharp.hotexamples.com/examples/-/Chef/-/php-chef-class-examples.html
