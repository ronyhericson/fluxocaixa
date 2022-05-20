using MediatR;

namespace FluxoCaixa.ApplicationCQRS.Commands.FluxoCaixa.AddFluxoCaixa
{
    public class AddFluxoCaixaCommand : IRequest<int>
    {
        public AddFluxoCaixaCommand(string tp_movimento, string descricao, decimal vl_movimento)
        {
            this.tp_movimento = tp_movimento;
            this.descricao = descricao;
            this.vl_movimento = vl_movimento;
        }
        
        public string tp_movimento { get; set; }
        public string descricao { get; set; }
        public decimal vl_movimento { get; set; }
    }
}