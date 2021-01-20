using System;

namespace _2._Password
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            string passwordTry = Console.ReadLine();
            while (passwordTry != password)
            {
                passwordTry = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {username}!");
        }
    }
}
