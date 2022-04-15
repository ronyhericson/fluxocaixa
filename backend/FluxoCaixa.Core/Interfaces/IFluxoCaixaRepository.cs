using System.Collections.Generic;
using System.Threading.Tasks;
using FluxoCaixa.Core.Entities;

namespace FluxoCaixa.Core.Interfaces
{
    public interface IFluxoCaixaRepository 
    {
        Task<int> CreateMovto(MovtoFluxoCaixa fluxoCaixa);
        Task<MovtoFluxoCaixa> GetUltimoLancamento();
        Task<IEnumerable<MovtoFluxoCaixa>> GetLancamentos();
    }
}