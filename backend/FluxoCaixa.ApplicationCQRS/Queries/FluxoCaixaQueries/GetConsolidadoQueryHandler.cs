using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluxoCaixa.Core.Interfaces;
using FluxoCaixa.Core.ViewModel;
using MediatR;

namespace FluxoCaixa.ApplicationCQRS.Queries.FluxoCaixaQueries
{
    public class GetConsolidadoQueryHandler : IRequestHandler<GetConsolidadoQuery, FluxoCaixaConsolidadoViewModel>
    {
        private readonly IFluxoCaixaRepository _fluxoCaixaRepository;
         
        public GetConsolidadoQueryHandler(IFluxoCaixaRepository fluxoCaixaRepository)
        {
            _fluxoCaixaRepository = fluxoCaixaRepository;
        }

        public async Task<FluxoCaixaConsolidadoViewModel> Handle(GetConsolidadoQuery request, CancellationToken cancellationToken)
        {
            var listaMovimentos = await _fluxoCaixaRepository.GetLancamentos();            
            var totalCredito = listaMovimentos.Where(x => x.tp_movimento.Equals("CREDITO")).Sum(s => s.vl_movimento);
            var totalDebito = listaMovimentos.Where(x => x.tp_movimento.Equals("DEBITO")).Sum(s => s.vl_movimento);
            var saldoAtual = totalCredito - totalDebito;

            var saldoConsolidado = new FluxoCaixaConsolidadoViewModel(){
                date = DateTime.Now,
                totalcredito = totalCredito,
                totaldebito = totalDebito,
                saldoatual = saldoAtual
            };
            
            return saldoConsolidado;
        }
    }
}