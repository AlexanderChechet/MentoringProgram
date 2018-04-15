using System.Threading;
using System.Threading.Tasks;

namespace Task7.Command
{
    public interface ITaskCommand
    {
        Task ExecuteCommand(CancellationToken token); 
    }
}
