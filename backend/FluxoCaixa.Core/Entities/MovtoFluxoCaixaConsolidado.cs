using System;

namespace FluxoCaixa.Core.Entities
{
    public class MovtoFluxoCaixaConsolidado
    {        
        public DateTime date { get; set; }
        public decimal totalcredito { get; set; }
        public decimal totaldebito { get; set; }
        public decimal saldoatual { get; set; }
    }
}