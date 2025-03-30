using DbModel.ElRancho;
using IBusiness;
using IRepository;
using Model.Request;
using Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class ReservaBusiness : IReservaBusiness
    {
        private readonly IReservaRepository _reservaRepository;

        public ReservaBusiness(IReservaRepository reservaRepository)
        {
            _reservaRepository = reservaRepository;
        }

        public async Task<List<ReservaResponse>> GetAll()
        {
            var reservas = await _reservaRepository.GetAllAsync();
            return reservas.Select(MapToResponse).ToList();
        }

        public async Task<ReservaResponse?> GetById(int id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);
            return reserva == null ? null : MapToResponse(reserva);
        }

        public async Task<ReservaResponse> Create(ReservaRequest request)
        {
            var reserva = MapToEntity(request);
            await _reservaRepository.AddAsync(reserva);
            await _reservaRepository.SaveChangesAsync();
            return MapToResponse(reserva);
        }

        public async Task<ReservaResponse> Update(int id, ReservaRequest request)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);
            if (reserva == null) return null;

            UpdateEntity(reserva, request);
            await _reservaRepository.UpdateAsync(reserva);
            await _reservaRepository.SaveChangesAsync();

            return MapToResponse(reserva);
        }

        public async Task<int> DeleteById(int id)
        {
            var reserva = await _reservaRepository.GetByIdAsync(id);
            if (reserva == null) return 0;

            await _reservaRepository.DeleteAsync(reserva);
            await _reservaRepository.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteMultiple(List<int> ids)
        {
            var reservas = await _reservaRepository.GetByIdsAsync(ids);
            if (!reservas.Any()) return 0;

            foreach (var reserva in reservas)
            {
                await _reservaRepository.DeleteAsync(reserva);
            }
            await _reservaRepository.SaveChangesAsync();
            return reservas.Count();
        }

        public async Task<List<ReservaResponse>> UpdateMultiple(Dictionary<int, ReservaRequest> reservasRequest)
        {
            var ids = reservasRequest.Keys.ToList();
            var reservas = await _reservaRepository.GetByIdsAsync(ids);
            var updatedReservas = new List<ReservaResponse>();

            foreach (var reserva in reservas)
            {
                if (reservasRequest.TryGetValue(reserva.Id, out var request))
                {
                    UpdateEntity(reserva, request);
                    await _reservaRepository.UpdateAsync(reserva);
                    updatedReservas.Add(MapToResponse(reserva));
                }
            }
            await _reservaRepository.SaveChangesAsync();
            return updatedReservas;
        }

        public async Task<List<ReservaResponse>> CreateMultiple(List<ReservaRequest> requests)
        {
            var reservas = requests.Select(MapToEntity).ToList();
            await _reservaRepository.AddRangeAsync(reservas);
            await _reservaRepository.SaveChangesAsync();
            return reservas.Select(MapToResponse).ToList();
        }

        public async Task<List<ReservaResponse>> GetByClienteId(int clienteId)
        {
            var reservas = await _reservaRepository.GetByClienteIdAsync(clienteId);
            return reservas.Select(MapToResponse).ToList();
        }

        public async Task<List<ReservaResponse>> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            var reservas = await _reservaRepository.GetByDateRangeAsync(startDate, endDate);
            return reservas.Select(MapToResponse).ToList();
        }

        private Reserva MapToEntity(ReservaRequest request)
        {
            return new Reserva
            {
                ClienteId = request.ClienteId,
                MesaId = request.MesaId,
                FechaReserva = request.FechaReserva,
                NumeroPersonas = request.NumeroPersonas // Corregido nombre del campo
            };
        }

        private ReservaResponse MapToResponse(Reserva reserva)
        {
            return new ReservaResponse
            {
                Id = reserva.Id,
                ClienteId = reserva.ClienteId,
                MesaId = reserva.MesaId,
                FechaReserva = reserva.FechaReserva,
                NumeroPersonas = reserva.NumeroPersonas // Corregido nombre del campo
            };
        }

        private void UpdateEntity(Reserva reserva, ReservaRequest request)
        {
            reserva.ClienteId = request.ClienteId;
            reserva.MesaId = request.MesaId;
            reserva.FechaReserva = request.FechaReserva;
            reserva.NumeroPersonas = request.NumeroPersonas; // Corregido nombre del campo
        }
    }
}
