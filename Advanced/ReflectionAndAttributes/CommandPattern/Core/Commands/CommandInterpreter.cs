using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core.Commands
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split(' ');
            string command = tokens[0];
            string[] comArgs = tokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type cmdType = assembly.GetTypes().FirstOrDefault(cmdType => cmdType.Name == $"{command}Command");

            if(cmdType == null)
            {
                throw new ArgumentException("Invalid Type!");
            }

            ICommand commandInstance = (ICommand)Activator.CreateInstance(cmdType);

            return commandInstance.Execute(comArgs);
        }
    }
}
