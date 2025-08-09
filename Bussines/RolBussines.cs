using DbModel.ElRancho;
using IBussines;
using IRepository;
using Model.Request;
using Model.Response;
using Repository;

namespace Bussines{

public class RolBussines : IRolBussines
{
    private readonly IRolRepository _repository;

    public RolBussines(IRolRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<RolResponse>> GetAll()
    {
        var result = await _repository.GetAllAsync();
        return result.Select(MapToResponse).ToList();
    }

    public async Task<RolResponse> Create(RolRequest request)
    {
        var rol = MapToEntity(request);
        await _repository.AddAsync(rol);
        await _repository.SaveChangesAsync();
        return MapToResponse(rol);
    }

    public async Task<RolResponse> GetById(int id)
    {
        var rol = await _repository.GetByIdAsync(id);
        if (rol == null)
        {
            return null;
        }

        return new RolResponse
        {
            Id = rol.Id,
            Name = rol.Name,
            Permisos = rol.Permisos,
        };
    }

    private Rol MapToEntity(RolRequest request)
    {
        return new Rol()
        {
            Name = request.Name,
            Permisos = request.Permisos
        };
    }
    private RolResponse MapToResponse(Rol rol)
    {
        return new RolResponse()
        {
            Id = rol.Id,
            Name = rol.Name,
            Permisos = rol.Permisos
        };
    }
}}