
using System;
using System.Threading.Tasks;
using Dapper;
using FluxoCaixa.Core.Entities;
using FluxoCaixa.Core.Interfaces;


namespace FluxoCaixa.Infrastructure.Repositories
{
    public class FluxoCaixaRepository : IFluxoCaixaRepository
    {
        private readonly IConnectionManager _connectionManager;
        public FluxoCaixaRepository(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public async Task<int> CreateMovto(MovtoFluxoCaixa fluxoCaixa)
        {
            int result = 0;

            using (var connection = await _connectionManager.GetConnectionAsync())
            {
                try
                {                    
                    var query = "INSERT INTO fluxocaixa (dtmovto, tpmovto, descricao, vlmovto, vlsaldoatual) VALUES (@dtMovito, @TipoMovto, @Descricao, @VlMovito, @VlSaldoAtual) RETURNING ID;";
                    var FluxoCaixaQuery = await connection.QueryFirstOrDefaultAsync<MovtoFluxoCaixa>(query, new
                    {
                        dtMovito = fluxoCaixa.dt_movimento,
                        TipoMovto = fluxoCaixa.tp_movimento,
                        Descricao = fluxoCaixa.descricao,
                        VlMovito = fluxoCaixa.vl_movimento,
                        VlSaldoAtual = fluxoCaixa.vl_saldoatual
                    });

                    result = 1;
                }
                catch (Exception e)
                {
                    var error = e.Message;                    
                    return result = 0;
                }

            }

            return result;
        }
    }
}