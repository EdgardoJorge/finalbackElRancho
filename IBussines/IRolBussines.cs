using Model.Request;
using Model.Response;

namespace IBussines{

public interface IRolBussines
{
  public Task<List<RolResponse>> GetAll();
  public Task<RolResponse> Create(RolRequest request);
  public Task<RolResponse> GetById(int id);
}}