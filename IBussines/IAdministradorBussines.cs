using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Request;
using Model.Response;

namespace IBussnies // Asegúrate de que el namespace sea correcto
{
    public interface IAdministradorBusiness // Corrige el nombre a "Business"
    {
        Task<List<AdministradorResponse>> GetAll();
        Task<AdministradorResponse> GetById(object id);
        Task<AdministradorResponse> Create(AdministradorRequest request);
        Task<AdministradorResponse> Update(AdministradorRequest request);
        Task<int> DeleteById(object id);
        Task<int> DeleteMultiple(List<AdministradorRequest> requests);
        Task<List<AdministradorResponse>> CreateMultiple(List<AdministradorRequest> requests);
        Task<List<AdministradorResponse>> UpdateMultiple(List<AdministradorRequest> requests);
        Task<AdministradorResponse?> GetByName(string name);
    }
}