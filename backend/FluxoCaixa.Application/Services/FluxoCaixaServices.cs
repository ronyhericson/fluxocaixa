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
            return await _fluxoCaixaRepository.CreateMovto(fluxoCaixa);
        }
    }
}