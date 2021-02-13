using System;
using System.Collections.Generic;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<string> elements = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToList();
            ListyIterator<string> iterator = new ListyIterator<string>(elements);

            string[] commands = Console.ReadLine().Split();

            while (commands[0]!="END")
            {
                switch (commands[0])
                {
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            iterator.Print();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ",iterator));
                        break;
                    default:
                        break;
                }
                commands = Console.ReadLine().Split();
            }
        }
    }
}
