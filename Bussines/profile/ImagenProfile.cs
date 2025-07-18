using AutoMapper;
using DbModel.ElRancho;
using Model.Request;
using Model.Response;

namespace Business.Profiles{

public class ImagenProfile : Profile
{
    public ImagenProfile()
    {
        CreateMap<ImagenRequest, Imagen>();
        CreateMap<Imagen, ImagenResponse>();
    }
}}