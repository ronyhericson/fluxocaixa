
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

        public async Task<MovtoFluxoCaixa> GetUltimoLancamento()
        {
            var result = new MovtoFluxoCaixa();

            using (var connection = await _connectionManager.GetConnectionAsync())
            {
                try
                {
                    var query = " Select * from fluxocaixa order by dt_movimento desc  limit 1";
                    var FluxoCaixaQuery = await connection.QueryFirstOrDefaultAsync<MovtoFluxoCaixa>(query);

                    result = FluxoCaixaQuery;
                }
                catch (Exception e)
                {
                    var error = e.Message;
                    return null;
                }

            }

            return result;
        }
        public async Task<int> CreateMovto(MovtoFluxoCaixa fluxoCaixa)
        {
            int result = 0;

            using (var connection = await _connectionManager.GetConnectionAsync())
            {
                try
                {
                    var query = "INSERT INTO fluxocaixa (dt_movimento, tp_movimento, descricao, vl_movimento, vl_saldoatual) VALUES (@dtMovito, @TipoMovto, @Descricao, @VlMovito, @VlSaldoAtual) RETURNING ID;";
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
                    result = 0;
                }

            }

            return result;
        }
    }
}