using System;

namespace FluxoCaixa.Core.Entities
{
    public class FluxoCaixaEntity
    {
        public FluxoCaixaEntity(string tp_movimento, string descricao, decimal vl_movimento, decimal vl_saldoatual)
        {
            this.id = 0;
            this.dt_movimento = DateTime.Now;
            this.tp_movimento = tp_movimento.ToUpper();
            this.descricao = descricao;
            this.vl_movimento = vl_movimento;
            this.vl_saldoatual = vl_saldoatual;
        }

        public int id { get; set; }
        public DateTime dt_movimento { get; set; }
        public string tp_movimento { get; set; }
        public string descricao { get; set; }
        public decimal vl_movimento { get; set; }
        public decimal vl_saldoatual { get; set; }
    }
}