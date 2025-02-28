using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Request;
using Model.Response;

namespace IBussnies
{
    public interface IAdministradorBussnies
    {
        Task<AdministradorResponse> Create(AdministradorRequest request);
        Task<List<AdministradorResponse>> CreateMultiple(List<AdministradorRequest> request);
        Task<int> DeleteById(object id);
        Task<int> DeleteMultiple(List<AdministradorRequest> request);
        Task<List<AdministradorResponse>> GetAll();
        Task<AdministradorResponse> GetById(object id);
        Task<AdministradorResponse?> GetByName(string AdministradorName);
        Task<AdministradorRequest> Update(AdministradorRequest request);
        Task<List<AdministradorResponse>> UpdateMultiple(List<AdministradorRequest> request);
    }
}
