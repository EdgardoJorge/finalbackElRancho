using Model.Request;
using Model.Response;

namespace IBussines
{

public interface IImagenBusiness
{
  Task<List<ImagenResponse>> GetAll();
  Task<ImagenResponse> GetById(int id);
  Task<ImagenResponse> Create(ImagenRequest request);
  Task<int> Delete(int id);
  Task<ImagenResponse> Update(int id, ImagenRequest request);
}

}