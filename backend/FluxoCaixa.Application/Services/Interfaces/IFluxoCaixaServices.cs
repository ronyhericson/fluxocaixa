using System.Collections.Generic;
using System.Threading.Tasks;
using FluxoCaixa.Core.Entities;

namespace FluxoCaixa.Application.Services.Interfaces
{
    public interface IFluxoCaixaServices
    {
        Task<int> CreateMovto(MovtoFluxoCaixa fluxoCaixa);
        Task<IEnumerable<MovtoFluxoCaixa>> GetLancamentos(int id = 0);
        Task<long> RemoveMovimento(int id);
        Task<MovtoFluxoCaixaConsolidado> GetSaldoConsolidado();
    }
}