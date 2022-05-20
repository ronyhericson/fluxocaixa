using System.Threading;
using System.Threading.Tasks;
using FluxoCaixa.Core.Entities;
using FluxoCaixa.Core.Interfaces;
using MediatR;

namespace FluxoCaixa.ApplicationCQRS.Commands.FluxoCaixa.AddFluxoCaixa
{
    public class AddFluxoCaixaCommandHandler : IRequestHandler<AddFluxoCaixaCommand, int>
    {
        private readonly IFluxoCaixaRepository _fluxoCaixaRepository;
        public AddFluxoCaixaCommandHandler(IFluxoCaixaRepository fluxoCaixaRepository)
        {
            _fluxoCaixaRepository = fluxoCaixaRepository;
        }

        public async Task<int> Handle(AddFluxoCaixaCommand request, CancellationToken cancellationToken)
        {
            var ultimoMovimento = await _fluxoCaixaRepository.GetUltimoLancamento();
            var fluxoCaixa = new FluxoCaixaEntity(request.tp_movimento, request.descricao, request.vl_movimento, 0);
            if (ultimoMovimento != null)
                fluxoCaixa.vl_saldoatual = fluxoCaixa.tp_movimento == "DEBITO" ? 
                     ultimoMovimento.vl_saldoatual - fluxoCaixa.vl_movimento : ultimoMovimento.vl_saldoatual + fluxoCaixa.vl_movimento;
            else    
                fluxoCaixa.vl_saldoatual = fluxoCaixa.vl_movimento;

            
            var resultId = await _fluxoCaixaRepository.CreateMovto(fluxoCaixa);
            return resultId;
        }
    }
}