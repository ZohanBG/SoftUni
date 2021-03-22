using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter command;

        public Engine(ICommandInterpreter command)
        {
            this.command = command;
        }

        public void Run()
        {
            while (true)
            {
                string line = Console.ReadLine();

                string result = command.Read(line);

                if (result == null)
                {
                    break;
                }
                Console.WriteLine(result);
            }
        }
    }
}