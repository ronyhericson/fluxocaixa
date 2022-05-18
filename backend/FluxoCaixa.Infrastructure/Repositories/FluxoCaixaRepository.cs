
using System;
using System.Collections.Generic;
using System.Text;
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
        public async Task<IEnumerable<MovtoFluxoCaixa>> GetLancamentos(int id = 0)
        {
            var result = new List<MovtoFluxoCaixa>();

            using (var connection = await _connectionManager.GetConnectionAsync())
            {
                try
                {
                    var query = string.Format("Select * from fluxocaixa {0} order by id ", id > 0 ? " Where id = " + id.ToString() : string.Empty);
                   
                    result =(List<MovtoFluxoCaixa>)await connection.QueryAsync<MovtoFluxoCaixa>(query);;
                }
                catch (Exception e)
                {
                    var error = e.Message;
                    return result;
                }

            }

            return result;
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
                    var query = "INSERT INTO fluxocaixa (dt_movimento, tp_movimento, descricao, vl_movimento, vl_saldoatual) VALUES (now(), @TipoMovto, @Descricao, @VlMovito, @VlSaldoAtual) RETURNING ID;";
                    var FluxoCaixaQuery = await connection.QueryFirstOrDefaultAsync<MovtoFluxoCaixa>(query, new
                    {                      
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

        public async Task<long> RemoveMovimento(int id)
        {
            long result = 0;
            using (var connection = await _connectionManager.GetConnectionAsync())
            {
                try
                {
                    var deleteItem = @"delete from fluxocaixa where id = @idMovto";
                    var deleteItemQuery = await connection.QueryFirstOrDefaultAsync<MovtoFluxoCaixa>(deleteItem, new
                    {
                        idMovto = id
                    });

                    result = 1;
                }
                catch (Exception ex)
                {
                    var error = ex.Message; 
                }
            }

            return result;
        }
    }
}