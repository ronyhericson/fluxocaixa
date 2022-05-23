using System.Collections.Generic;
using System.Threading.Tasks;
using FluxoCaixa.Core.Entities;
using FluxoCaixa.Core.ViewModel;

namespace FluxoCaixa.Core.Interfaces
{
    public interface IFluxoCaixaRepository 
    {
        Task<int> CreateMovto(FluxoCaixaEntity fluxoCaixa);
        Task<FluxoCaixaEntity> GetUltimoLancamento();
        Task<IEnumerable<FluxoCaixaViewModel>> GetLancamentos(int id = 0);
        Task<long> RemoveMovimento(int id);
      
    }
}