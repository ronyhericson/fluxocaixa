using System;

namespace FluxoCaixa.Core.Entities
{
    public class MovtoFluxoCaixa
    {
        public int id { get; set; }
        public DateTime dt_movimento { get; set; }
        public string tp_movimento { get; set; }
        public string descricao { get; set; }
        public decimal vl_movimento { get; set; }
        public decimal vl_saldoatual { get; set; }
    }
}