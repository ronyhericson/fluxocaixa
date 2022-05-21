using MediatR;

namespace FluxoCaixa.ApplicationCQRS.Commands.FluxoCaixa.RemoveFluxoCaixa
{
    public class RemoveFluxoCaixaCommand : IRequest<int>
    {
        public RemoveFluxoCaixaCommand(int id)
        {
            this.id = id;            
        }
        
        public int id { get; set; }        
    }
}