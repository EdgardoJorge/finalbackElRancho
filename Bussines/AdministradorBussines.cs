using AutoMapper;
using DbModel.ElRancho;
using IBussnies;
using IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Model.Request;
using Model.Response;
using Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // Add this using directive for DbContext

namespace Bussnies
{
    public class AdministradorBussnies : IAdministradorBussnies
    {
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private readonly ICrudRepository<Administrador> _AdministradorRepository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext; // Add this field for DbContext

        public AdministradorBussnies(IHttpContextAccessor HttpContextAccessor, IConfiguration configuration, IMapper mapper, DbContext dbContext)
        {
            _HttpContextAccessor = HttpContextAccessor;
            _configuration = configuration;
            _mapper = mapper;
            _dbContext = dbContext; // Initialize the DbContext
            _AdministradorRepository = new AdministradorRepository(HttpContextAccessor, configuration, dbContext); // Pass the DbContext parameter
        }

        public Task<AdministradorResponse> Create(AdministradorRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdministradorResponse>> CreateMultiple(List<AdministradorRequest> request)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteMultiple(List<AdministradorRequest> request)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdministradorResponse>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AdministradorResponse> GetById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<AdministradorRequest> Update(AdministradorRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<AdministradorResponse>> UpdateMultiple(List<AdministradorRequest> request)
        {
            throw new NotImplementedException();
        }

        Task<AdministradorResponse?> IAdministradorBussnies.GetByName(string AdministradorName)
        {
            throw new NotImplementedException();
        }
    }
}