using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using FluxoCaixa.Application.Services.Interfaces;
using FluxoCaixa.ApplicationCQRS.Commands.FluxoCaixa.AddFluxoCaixa;
using FluxoCaixa.ApplicationCQRS.Commands.FluxoCaixa.RemoveFluxoCaixa;
using FluxoCaixa.ApplicationCQRS.Queries.FluxoCaixaQueries;
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
        private readonly IMediator mediator;

        public FluxoCaixaController(IMediator mediator)
        {
            this.mediator = mediator;
        }

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

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FluxoCaixaViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<FluxoCaixaViewModel>>> GetLancamentos()
        {
            try
            {
                var getAll = new GetAllFluxoCaixaQuery();
                return Ok(await mediator.Send(getAll));
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Problemas para listar os movimentos." });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(FluxoCaixaConsolidadoViewModel), (int)HttpStatusCode.OK)]
        [Route("GetConsolidado")]
        public async Task<ActionResult<FluxoCaixaConsolidadoViewModel>> GetConsolidado()
        {
            try
            {
                var getConsolidado = new GetConsolidadoQuery();
                return Ok(await mediator.Send(getConsolidado));
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Problemas para listar os movimentos." });
            }            
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(IEnumerable<FluxoCaixaViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<FluxoCaixaViewModel>>> GetLancamentoById(int id = 0)
        {
            // var listLancamentos = await _fluxoCaixaService.GetLancamentos(id);

            // var listLançamentosViewModel = _mapper.Map<List<FluxoCaixaViewModel>>(listLancamentos);

            // return Ok(listLançamentosViewModel);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Remove([FromBody] RemoveFluxoCaixaCommand request)
        {
            try
            {
                await mediator.Send(request);
                return Ok(new { message = "Movimento removido com sucesso." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Problemas para remover este movimento." });
            }

        }
    }
}