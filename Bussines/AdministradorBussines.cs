using AutoMapper;
using DbModel.ElRancho;
using IBussnies;
using IRepository;
using Microsoft.EntityFrameworkCore;
using Model.Request;
using Model.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public class AdministradorBusiness : IAdministradorBusiness
    {
        private readonly ICrudRepository<Administrador> _administradorRepository;
        private readonly IMapper _mapper;
        private readonly ElRanchoDbContext _dbContext;

        public AdministradorBusiness(
            ICrudRepository<Administrador> administradorRepository,
            IMapper mapper,
            ElRanchoDbContext dbContext)
        {
            _administradorRepository = administradorRepository;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        // ------------------------- CREATE -------------------------
        public async Task<AdministradorResponse> Create(AdministradorRequest request)
        {
            // Mapeo de Request → Entidad
            var administrador = _mapper.Map<Administrador>(request); 

            await _administradorRepository.AddAsync(administrador);
            await _dbContext.SaveChangesAsync();

            // Mapeo de Entidad → Response
            return _mapper.Map<AdministradorResponse>(administrador); 
        }

        // -------------------------- READ ---------------------------
        public async Task<List<AdministradorResponse>> GetAll()
        {
            var administradores = await _administradorRepository.GetAllAsync();
            return _mapper.Map<List<AdministradorResponse>>(administradores);
        }

        public async Task<AdministradorResponse> GetById(object id)
        {
            var administrador = await _administradorRepository.GetByIdAsync(id);
            return administrador == null ? null : _mapper.Map<AdministradorResponse>(administrador);
        }

        public async Task<AdministradorResponse?> GetByName(string nombre)
        {
            var administrador = await _dbContext.Administradores
                .FirstOrDefaultAsync(a => a.Nombre == nombre); // Asegúrate que la propiedad se llame "Nombre"
            return administrador == null ? null : _mapper.Map<AdministradorResponse>(administrador);
        }

        // ------------------------- UPDATE -------------------------
        public async Task<AdministradorResponse> Update(AdministradorRequest request)
        {
            var administradorExistente = await _administradorRepository.GetByIdAsync(request.Id);
            if (administradorExistente == null) return null;

            // Mapeo de Request → Entidad existente
            _mapper.Map(request, administradorExistente); 

            await _administradorRepository.UpdateAsync(administradorExistente);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<AdministradorResponse>(administradorExistente);
        }

        // ... (resto de los métodos se mantienen igual)
    }
}