using System.Threading.Tasks;

namespace FluxoCaixa.Infrastructure.Commands.Interface
{
    public interface ICommandsProcessor
    {
        Task Process<TCommand>(TCommand command);
    }
}