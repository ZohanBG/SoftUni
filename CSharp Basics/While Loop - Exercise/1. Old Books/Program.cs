using System;

namespace _1._Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string bookWanted = Console.ReadLine();
            int bookCount = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (bookWanted == input)
                {
                    Console.WriteLine($"You checked {bookCount} books and found it.");
                    break;
                }
                else if (input == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {bookCount} books.");
                    break;
                }
                else
                {
                    bookCount++;
                }
            }
        }
    }
}
