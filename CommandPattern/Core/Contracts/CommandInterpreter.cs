using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Core.Commands;

namespace CommandPattern.Core.Contracts
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputTokens = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string cmdType = inputTokens[0].ToLower();
            string[] comandArgument = inputTokens.Skip(1).ToArray();

            string result = string.Empty;

            

            Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x => x.Name.ToLower() == $"{cmdType}Command".ToLower());

            ICommand instance = (ICommand) Activator.CreateInstance(type);

            //if (cmdType == "HelloCommand")
            //{
            //    command = new HelloCommand();

            //}
            //else if (cmdType == "ExitCommand")
            //{
            //    command = new ExitCommand();
            //}

            result = instance.Execute(comandArgument);

            return result;
        }
    }
}
