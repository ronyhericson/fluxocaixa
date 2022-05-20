using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FluxoCaixa.Application.Services.Interfaces;
using FluxoCaixa.ApplicationCQRS.Commands.FluxoCaixa.AddFluxoCaixa;
using FluxoCaixa.Core.Entities;
using FluxoCaixa.Core.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class FluxoCaixaController : ControllerBase
    {
        private readonly IFluxoCaixaServices _fluxoCaixaService;
        private readonly IMapper _mapper;
        private readonly IMediator mediator;

        public FluxoCaixaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // public FluxoCaixaController(IFluxoCaixaServices fluxoCaixaService, IMapper mapper)
        // {
        //     _fluxoCaixaService = fluxoCaixaService;
        //     _mapper = mapper;
        // }

        [HttpPost]
        [Route("AddFluxoCaixa")]
        public async Task<IActionResult> Create([FromBody] AddFluxoCaixaCommand request)
        {
            try
            {
                await mediator.Send(request);
                return Ok(new { message = "Movimento inserido com sucesso." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Problemas para inserir este movimento." });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(FluxoCaixaViewModel), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<FluxoCaixaViewModel>> CreateFluxoCaixa([FromBody] FluxoCaixaViewModel fluxoCaixa)
        {
            var fluxoCaixaViewModel = new FluxoCaixaViewModel();
            var domainFLuxoCaixa = _mapper.Map<MovtoFluxoCaixa>(fluxoCaixa);
            var retunCreatedFluxoCaixa = await _fluxoCaixaService.CreateMovto(domainFLuxoCaixa);

            if (retunCreatedFluxoCaixa == 0)
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

        [HttpGet]
        [ProducesResponseType(typeof(FluxoCaixaConsolidadoViewModel), (int)HttpStatusCode.OK)]
        [Route("GetConsolidado")]
        public async Task<ActionResult<dynamic>> GetConsolidado() => Ok(await _fluxoCaixaService.GetSaldoConsolidado());

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(IEnumerable<FluxoCaixaViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<FluxoCaixaViewModel>>> GetLancamentoById(int id = 0)
        {
            var listLancamentos = await _fluxoCaixaService.GetLancamentos(id);

            var listLançamentosViewModel = _mapper.Map<List<FluxoCaixaViewModel>>(listLancamentos);

            return Ok(listLançamentosViewModel);
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> RemoveLancamento(int id)
        {
            var removeMovto = await _fluxoCaixaService.RemoveMovimento(id);

            if (removeMovto == 0)
                return BadRequest(new { message = "Problemas para remover este movimento." });

            return Ok(new { message = "Movimento removido com sucesso." });
        }
    }
}