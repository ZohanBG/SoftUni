using System;

namespace Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            string data = input[0] +" "+ input[1];
            Tuple<string, string> person = new Tuple<string, string>(data, input[2]);
            input = Console.ReadLine().Split();
            Tuple<string, int> person2 = new Tuple<string, int>(input[0],int.Parse(input[1]));
            input = Console.ReadLine().Split();
            Tuple<int, double> person3 = new Tuple<int, double>(int.Parse(input[0]), double.Parse(input[1]));
            Console.WriteLine(person);
            Console.WriteLine(person2);
            Console.WriteLine(person3);
        }
    }
}
