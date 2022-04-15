using System.Data;
using System.Threading.Tasks;

namespace FluxoCaixa.Core.Interfaces
{
    public interface IConnectionManager
    {
        Task<IDbConnection> GetConnectionAsync(string database = null);
    }
}