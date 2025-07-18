using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles;

public class rolProfile : Profile
{
    public rolProfile()
    {
        CreateMap<RolRequest, Rol>();
        CreateMap<Rol, RolResponse>();
    }
}