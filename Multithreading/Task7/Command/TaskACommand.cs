﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task7.Command
{
    public class TaskACommand : ITaskCommand
    {
        public Task ExecuteCommand(CancellationToken token)
        {
            var task = Task.Run((Action)ConsoleActions.WriteConsoleParent, token)
                .ContinueWith(x => ConsoleActions.WriteConsoleChild());
            return task;
        }
    }
}
