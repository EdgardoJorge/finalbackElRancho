using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbModel.ElRancho;
using IBusiness;
using IRepository;
using Model.Request;
using Model.Response;

namespace Business
{
    public class MesaBusiness : IMesaBusiness
    {
        private readonly IMesaRepository _mesaRepository;

        public MesaBusiness(IMesaRepository mesaRepository)
        {
            _mesaRepository = mesaRepository;
        }

        public async Task<List<MesaResponse>> GetAll()
        {
            var mesas = await _mesaRepository.GetAllAsync();
            return mesas.Select(MapToResponse).ToList();
        }

        public async Task<MesaResponse?> GetById(int id)
        {
            var mesa = await _mesaRepository.GetByIdAsync(id);
            return mesa == null ? null : MapToResponse(mesa);
        }

        public async Task<MesaResponse> Create(MesaRequest request)
        {
            var mesa = MapToEntity(request);
            await _mesaRepository.AddAsync(mesa);
            await _mesaRepository.SaveChangesAsync();
            return MapToResponse(mesa);
        }

        public async Task<List<MesaResponse>> CreateMultiple(List<MesaRequest> requests)
        {
            var mesas = requests.Select(MapToEntity).ToList();
            await _mesaRepository.AddRangeAsync(mesas);
            await _mesaRepository.SaveChangesAsync();
            return mesas.Select(MapToResponse).ToList();
        }

        public async Task<MesaResponse> Update(int id, MesaRequest request)
        {
            var mesa = await _mesaRepository.GetByIdAsync(id);
            if (mesa == null) return null;

            UpdateEntity(mesa, request);
            await _mesaRepository.UpdateAsync(mesa);
            await _mesaRepository.SaveChangesAsync();

            return MapToResponse(mesa);
        }

        public async Task<List<MesaResponse>> UpdateMultiple(Dictionary<int, MesaRequest> requests)
        {
            var mesas = await _mesaRepository.GetAllAsync();
            var updatedMesas = new List<Mesa>();

            foreach (var request in requests)
            {
                var mesa = mesas.FirstOrDefault(m => m.Id == request.Key);
                if (mesa != null)
                {
                    UpdateEntity(mesa, request.Value);
                    updatedMesas.Add(mesa);
                }
            }

            await _mesaRepository.SaveChangesAsync();
            return updatedMesas.Select(MapToResponse).ToList();
        }

        public async Task<int> DeleteById(int id)
        {
            var mesa = await _mesaRepository.GetByIdAsync(id);
            if (mesa == null) return 0;

            await _mesaRepository.DeleteAsync(mesa);
            await _mesaRepository.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteMultiple(List<int> ids)
        {
            var mesas = await _mesaRepository.FindAsync(m => ids.Contains(m.Id));
            await _mesaRepository.DeleteRangeAsync(mesas);
            await _mesaRepository.SaveChangesAsync();
            return mesas.Count;
        }

        public async Task<List<MesaResponse>> GetMesasDisponibles()
        {
            var mesas = await _mesaRepository.FindAsync(m => m.Disponible);
            return mesas.Select(MapToResponse).ToList();
        }

        // Métodos auxiliares
        private Mesa MapToEntity(MesaRequest request)
        {
            return new Mesa
            {
                Numero = request.NumeroMesa,  // Verifica que la propiedad en la entidad `Mesa` se llama `Numero`
                Capacidad = request.Capacidad,
                Disponible = request.Disponible
            };
        }

        private MesaResponse MapToResponse(Mesa mesa)
        {
            return new MesaResponse
            {
                Id = mesa.Id,
                NumeroMesa = mesa.Numero,  // Asegúrate de que `Mesa` tiene la propiedad `Numero`
                Capacidad = mesa.Capacidad,
                Disponible = mesa.Disponible
            };
        }

        private void UpdateEntity(Mesa mesa, MesaRequest request)
        {
            mesa.Numero = request.NumeroMesa;  // Asegúrate de que `Mesa` tiene `Numero`
            mesa.Capacidad = request.Capacidad;
            mesa.Disponible = request.Disponible;
        }
    }
}
