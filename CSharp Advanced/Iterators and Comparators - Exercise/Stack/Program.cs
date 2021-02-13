using System;

namespace Stack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stack<int> myStack = new Stack<int>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] commandData = command
                    .Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);

                switch (commandData[0])
                {
                    case "Push":
                        for (int i = 1; i < commandData.Length; i++)
                        {
                            myStack.Push(int.Parse(commandData[i]));
                        }
                        break;
                    case "Pop":
                        try
                        {
                            myStack.Pop();
                        }
                        catch (InvalidOperationException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(Environment.NewLine, myStack));
            Console.WriteLine(string.Join(Environment.NewLine, myStack));
        }
    }
}
