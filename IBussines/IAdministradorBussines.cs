using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Request;
using Model.Response;

namespace IBusiness
{
    public interface IAdministradorBusiness
    {
        Task<List<AdministradorResponse>> GetAll();
        Task<AdministradorResponse?> GetById(int id);
        Task<AdministradorResponse> Create(AdministradorRequest request);
        Task<AdministradorResponse> Update(int id, AdministradorRequest request);
        Task<int> DeleteById(int id);
        Task<int> DeleteMultiple(List<int> ids);
        Task<List<AdministradorResponse>> CreateMultiple(List<AdministradorRequest> requests);
        Task<List<AdministradorResponse>> UpdateMultiple(Dictionary<int, AdministradorRequest> requests);
        Task<AdministradorResponse?> GetByName(string name);
    }
}
