using System;
using System.Threading.Tasks;
using Dapper;
using FluxoCaixa.Core.Entities;
using FluxoCaixa.Core.Interfaces;
using FluxoCaixa.Infrastructure.Commands.Interface;

namespace FluxoCaixa.Infrastructure.Commands
{
    public class AddFluxoCaixaHandler : ICommandHandler<MovtoFluxoCaixa>
    {
        private readonly IConnectionManager _connectionManager;

        public AddFluxoCaixaHandler(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public async Task Execute(MovtoFluxoCaixa command)
        {
            using (var connection = await _connectionManager.GetConnectionAsync())
            {
                try
                {
                    var query = "INSERT INTO fluxocaixa (dt_movimento, tp_movimento, descricao, vl_movimento, vl_saldoatual) VALUES (now(), @TipoMovto, @Descricao, @VlMovito, @VlSaldoAtual) RETURNING ID;";
                    var FluxoCaixaQuery = await connection.QueryFirstOrDefaultAsync<MovtoFluxoCaixa>(query, new
                    {                      
                        TipoMovto = command.tp_movimento,
                        Descricao = command.descricao,
                        VlMovito = command.vl_movimento,
                        VlSaldoAtual = command.vl_saldoatual
                    });

                }
                catch (Exception e)
                {
                    var error = e.Message;                    
                }
            }

        }
    }
}