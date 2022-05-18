using System.Threading.Tasks;

namespace FluxoCaixa.Infrastructure.Commands.Interface
{
    public interface ICommandHandler<TCommand>
    {
        Task Execute(TCommand command);
    }
}