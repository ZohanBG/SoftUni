using CommandPattern.Core.Comands;
using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] parts = args.Split();
            string commandType = parts[0];
            string[] commandArgs = parts.Skip(1).ToArray();

            Type type = Assembly.GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.StartsWith(commandType));
            if (type == null)
            {
                throw new NotImplementedException("Wrong command!");
            }
            ICommand command = (ICommand)Activator.CreateInstance(type);

            return command.Execute(commandArgs);
        }
    }
}