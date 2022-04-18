using AutoMapper;
using FluxoCaixa.Core.Entities;
using FluxoCaixa.Core.ViewModel;

namespace FluxoCaixa.API.Mapper
{
    public class FluxoCaixaProfile : Profile
    {
        public FluxoCaixaProfile()
        {
            CreateMap<FluxoCaixaViewModel, MovtoFluxoCaixa>().ReverseMap();
            CreateMap<FluxoCaixaConsolidadoViewModel, MovtoFluxoCaixaConsolidado>().ReverseMap();
        }
    }
}