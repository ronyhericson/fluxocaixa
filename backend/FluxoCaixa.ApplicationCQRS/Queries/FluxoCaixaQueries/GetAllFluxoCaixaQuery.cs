using System.Collections.Generic;
using FluxoCaixa.Core.ViewModel;
using MediatR;

namespace FluxoCaixa.ApplicationCQRS.Queries.FluxoCaixaQueries
{
    public class GetAllFluxoCaixaQuery : IRequest<List<FluxoCaixaViewModel>>
    {

    }
}