using System;

namespace Giraffe // Needs to be the same namespace 
{ //signifies program starting
    class Program //class is just a container where store can be contained. 
    {
        static void Main(string[] args)
        {
            //declaring the type of variable
            string characterName = "Jimmy";
            int characterAge; // declaring and can assign after
            characterAge = 25;
            Console.WriteLine($"There once was a named {characterName}" );
            Console.WriteLine($"He was {characterAge} Years old");
            characterName = "Jim";
            Console.WriteLine("He really liked the name " +  characterName);
            Console.WriteLine($"But he didn't like being {characterAge}");
            Console.ReadLine();
        }
    }
}