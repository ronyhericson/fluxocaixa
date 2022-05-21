using System.Threading;
using System.Threading.Tasks;
using FluxoCaixa.Core.Interfaces;
using MediatR;

namespace FluxoCaixa.ApplicationCQRS.Commands.FluxoCaixa.RemoveFluxoCaixa
{
    public class RemoveFluxoCaixaCommandHandler : IRequestHandler<RemoveFluxoCaixaCommand, int>
    {
        private readonly IFluxoCaixaRepository _fluxoCaixaRepository;
        public RemoveFluxoCaixaCommandHandler(IFluxoCaixaRepository fluxoCaixaRepository)
        {
            _fluxoCaixaRepository = fluxoCaixaRepository;
        }

        public async Task<int> Handle(RemoveFluxoCaixaCommand request, CancellationToken cancellationToken)
        {
            var resultId = await _fluxoCaixaRepository.RemoveMovimento(request.id);
            return (int)resultId;
        }
    }
}