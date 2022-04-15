using System.Collections.Generic;
using System.Threading.Tasks;
using FluxoCaixa.Application.Services.Interfaces;
using FluxoCaixa.Core.Entities;
using FluxoCaixa.Core.Interfaces;

namespace FluxoCaixa.Application.Services
{
    public class FluxoCaixaServices : IFluxoCaixaServices
    {
        private readonly IFluxoCaixaRepository _fluxoCaixaRepository;

        public FluxoCaixaServices(IFluxoCaixaRepository fluxoCaixaRepository)
        {
            _fluxoCaixaRepository = fluxoCaixaRepository;
        }
        
        public async Task<int> CreateMovto(MovtoFluxoCaixa fluxoCaixa)
        {
            var ultimoMovimento = await _fluxoCaixaRepository.GetUltimoLancamento();

            if (ultimoMovimento != null)
                fluxoCaixa.vl_saldoatual = fluxoCaixa.tp_movimento == "DEBITO" ? 
                     ultimoMovimento.vl_saldoatual - fluxoCaixa.vl_movimento : ultimoMovimento.vl_saldoatual + fluxoCaixa.vl_movimento;


            return await _fluxoCaixaRepository.CreateMovto(fluxoCaixa);
        }

        public async Task<IEnumerable<MovtoFluxoCaixa>> GetLancamentos()
        {
            return await _fluxoCaixaRepository.GetLancamentos();
        }
    }
}