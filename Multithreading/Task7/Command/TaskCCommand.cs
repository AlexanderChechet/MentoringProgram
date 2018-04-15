using System.Threading;
using System.Threading.Tasks;

namespace Task7.Command
{
    public class TaskCCommand : ITaskCommand
    {
        public Task ExecuteCommand(CancellationToken token)
        {
            var task = Task.Factory.StartNew(ConsoleActions.WriteConsoleParent)
                .ContinueWith(x => ConsoleActions.WriteConsoleChild(), TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously);
            return task;
        }
    }
}
