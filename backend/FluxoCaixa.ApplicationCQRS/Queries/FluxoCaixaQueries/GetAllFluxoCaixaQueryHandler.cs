using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluxoCaixa.Core.Interfaces;
using FluxoCaixa.Core.ViewModel;
using MediatR;

namespace FluxoCaixa.ApplicationCQRS.Queries.FluxoCaixaQueries
{
    public class GetAllFluxoCaixaQueryHandler : IRequestHandler<GetAllFluxoCaixaQuery, List<FluxoCaixaViewModel>>
    {
        private readonly IFluxoCaixaRepository _fluxoCaixaRepository;
         
        public GetAllFluxoCaixaQueryHandler(IFluxoCaixaRepository fluxoCaixaRepository)
        {
            _fluxoCaixaRepository = fluxoCaixaRepository;
        }
        public async Task<List<FluxoCaixaViewModel>> Handle(GetAllFluxoCaixaQuery request, CancellationToken cancellationToken)
        {
            var lista = await _fluxoCaixaRepository.GetLancamentos();
            var listaReturn = lista.ToList();
            
            return listaReturn;
        }
    }
}