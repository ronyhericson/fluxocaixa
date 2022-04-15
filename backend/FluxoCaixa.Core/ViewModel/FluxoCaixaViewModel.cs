using System;

namespace FluxoCaixa.Core.ViewModel
{
    public class FluxoCaixaViewModel
    {
        public DateTime dt_movimento { get; set; }
        public string tp_movimento { get; set; }
        public string descricao { get; set; }
        public decimal vl_movimento { get; set; }
        public decimal vl_saldoatual { get; set; }
    }
}