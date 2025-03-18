using DbModel.ElRancho;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IClienteRepository : ICrudRepository<Cliente>
    {
        Task<Cliente> GetByDniAsync(string dni);
        Task<int> DeleteMultipleAsync(List<int> ids);
        Task<List<Cliente>> CreateMultipleAsync(List<Cliente> clientes);
        Task<List<Cliente>> UpdateMultipleAsync(Dictionary<int, Cliente> clientes);
    }
}
