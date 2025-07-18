using Model.Response;

namespace IBussines{

public interface IRolBussines
{
  public Task<List<RolResponse>> GetAll();
}}