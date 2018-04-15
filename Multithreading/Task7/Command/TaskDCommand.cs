using System.Threading;
using System.Threading.Tasks;

namespace Task7.Command
{
    public class TaskDCommand : ITaskCommand
    {
        public Task ExecuteCommand(CancellationToken token)
        {
            token.Register(ConsoleActions.WriteConsoleChild, false);
            var task = Task.Factory.StartNew(ConsoleActions.WriteConsoleParent)
                .ContinueWith(x => ConsoleActions.WriteConsoleChild(), token);
            return task;
        }
    }
}
