using System;
using System.Linq;

namespace _7._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();
            Func<string, bool> filter = n => n.Length <= length;
            string[] filteredNames = names.Where(filter).ToArray();
            Action<string[]> printer = n => Console.WriteLine(string.Join(Environment.NewLine, n));
            printer(filteredNames);
        }
    }
}
