using System;
using System.Collections.Generic;

namespace Task7.Command
{
    public class TaskCommandManager
    {
        private Dictionary<string, ITaskCommand> commands;
        public TaskCommandManager()
        {
            commands = new Dictionary<string, ITaskCommand>()
            {
                { "A", new TaskACommand() },
                { "B", new TaskBCommand() },
                { "C", new TaskCCommand() },
                { "D", new TaskDCommand() }
            };
        }

        public ITaskCommand GetCommand(string key)
        {
            if (!commands.ContainsKey(key))
                throw new ArgumentException("Command not found");
            return commands[key];
        }
    }
}
