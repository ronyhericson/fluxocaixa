using System;
using System.Collections.Generic;
using System.Linq;
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
            else    
                fluxoCaixa.vl_saldoatual = fluxoCaixa.vl_movimento;

            return 0;//await _fluxoCaixaRepository.CreateMovto(fluxoCaixa);
        }

        public async Task<IEnumerable<MovtoFluxoCaixa>> GetLancamentos(int id = 0)
        {
            //return await _fluxoCaixaRepository.GetLancamentos(id);
            return null;
        }

        public async Task<long> RemoveMovimento(int id)
        {
            return await _fluxoCaixaRepository.RemoveMovimento(id);
        }

        public async Task<dynamic> GetSaldoConsolidado()
        {            
            var listaMovimentos = await _fluxoCaixaRepository.GetLancamentos();            
            var totalCredito = listaMovimentos.Where(x => x.tp_movimento.Equals("Credito")).Sum(s => s.vl_movimento);
            var totalDebito = listaMovimentos.Where(x => x.tp_movimento.Equals("Debito")).Sum(s => s.vl_movimento);
            var saldoAtual = totalCredito - totalDebito;

            var saldoConsolidado = new {
                date = DateTime.Now,
                totalCredito,
                totalDebito,
                saldoAtual
            };
           
            return saldoConsolidado;
        }
    }
}