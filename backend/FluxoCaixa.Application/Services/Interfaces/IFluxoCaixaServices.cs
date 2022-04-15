using System.Threading.Tasks;
using FluxoCaixa.Core.Entities;

namespace FluxoCaixa.Application.Services.Interfaces
{
    public interface IFluxoCaixaServices
    {
        Task<int> CreateMovto(MovtoFluxoCaixa fluxoCaixa);
    }
}