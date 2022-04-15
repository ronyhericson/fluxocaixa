using System.Threading.Tasks;
using FluxoCaixa.Core.Entities;

namespace FluxoCaixa.Core.Interfaces
{
    public interface IFluxoCaixaRepository 
    {
        Task<int> CreateMovto(MovtoFluxoCaixa fluxoCaixa);
    }
}