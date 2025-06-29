using Model.Request;
using Model.Response;

namespace IBussines{

public interface IImagenBusiness
{
  Task<List<ImagenResponse>> GetAll();
  Task<List<ImagenResponse>> GetById(int id);
  Task<ImagenResponse> Create(ImagenRequest request);
  Task<ImagenResponse> Update(int id, ImagenRequest request);
  Task<ImagenResponse> GetByProduct(int id,ProductoRequest request);
}}