using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    class Book
    {
        public string title; //declaring attribute
        public string author;
        public int pages;
        private int year; //only code inside the book class will be able to access it 
        private string rating;
        static string distributor;
        private static int totalBookCount = 0;

        //this is a constructor takes args to set attributes --> gets executing every time
        public Book(string aTitle, string aAuthor, int aPages, string aRating="PG")
        {
            title = aTitle;
            author = aAuthor;
            pages = aPages;
            Rating = aRating;
            totalBookCount++;
        }

        public bool HasPages()
        {
            return pages >= 1 ? true : false;
        }


        public string Rating
        {
            get { return rating; }
            set
            {
                if (value == "G" || value == "PG-13")
                { //value represents whatever the new value is
                    rating = value;
                }
                else
                {
                    rating = "NR";
                }
            }

        }
        public static int TotalBookCount()
        {
            return totalBookCount;
        }
        //static attribute --> special type. Attribute that is share by the class itself not the instance
    }
}
