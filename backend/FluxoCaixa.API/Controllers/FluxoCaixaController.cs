using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FluxoCaixa.Application.Services.Interfaces;
using FluxoCaixa.Core.Entities;
using FluxoCaixa.Core.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FluxoCaixaController : ControllerBase
    {
        private readonly IFluxoCaixaServices _fluxoCaixaService;
        private readonly IMapper _mapper;

        public FluxoCaixaController(IFluxoCaixaServices fluxoCaixaService, IMapper mapper)
        {
            _fluxoCaixaService = fluxoCaixaService;
            _mapper = mapper;
        }

        [HttpPost]        
        [ProducesResponseType(typeof(FluxoCaixaViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<FluxoCaixaViewModel>> CreateFluxoCaixa([FromBody] FluxoCaixaViewModel fluxoCaixa)
        {
            var fluxoCaixaViewModel = new FluxoCaixaViewModel();
            var domainFLuxoCaixa = _mapper.Map<MovtoFluxoCaixa>(fluxoCaixa);
            var retunCreatedFluxoCaixa = await _fluxoCaixaService.CreateMovto(domainFLuxoCaixa);

            if(retunCreatedFluxoCaixa == 0)
                return BadRequest(new { message = "Problemas para inserir este movimento." });

            
            return Ok(new { message = "Movimento inserido com sucesso." });
        }

        [HttpGet]        
        [ProducesResponseType(typeof(IEnumerable<FluxoCaixaViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<FluxoCaixaViewModel>>> GetLancamentos()
        {
            var listLancamentos = await _fluxoCaixaService.GetLancamentos();

            var listLançamentosViewModel = _mapper.Map<List<FluxoCaixaViewModel>>(listLancamentos);

            return Ok(listLançamentosViewModel);
        }
    }
}