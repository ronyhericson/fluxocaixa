using System;

namespace FluxoCaixa.Core.ViewModel
{
    public class FluxoCaixaConsolidadoViewModel
    {
        public DateTime date { get; set; }
        public decimal totalcredito { get; set; }
        public decimal totaldebito { get; set; }
        public decimal saldoatual { get; set; }
    }
}