using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbModel.ElRancho;
using IRepository;
using IBusiness;
using Model.Request;
using Model.Response;
using BCrypt.Net;

namespace Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteBusiness(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<ClienteResponse>> GetAll()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return clientes.Select(MapToResponse).ToList();
        }

        public async Task<ClienteResponse> GetById(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            return cliente == null ? null : MapToResponse(cliente);
        }

        public async Task<ClienteResponse> GetByDni(string dni)
        {
            var cliente = (await _clienteRepository.FindAsync(c => c.DNI == dni)).FirstOrDefault();
            return cliente == null ? null : MapToResponse(cliente);
        }

        public async Task<ClienteResponse> Create(ClienteRequest request)
        {
            var cliente = MapToEntity(request);
            await _clienteRepository.AddAsync(cliente);
            await _clienteRepository.SaveChangesAsync();
            return MapToResponse(cliente);
        }

        public async Task<List<ClienteResponse>> CreateMultiple(List<ClienteRequest> requests)
        {
            var clientes = requests.Select(MapToEntity).ToList();
            await _clienteRepository.AddRangeAsync(clientes);
            await _clienteRepository.SaveChangesAsync();
            return clientes.Select(MapToResponse).ToList();
        }

        public async Task<ClienteResponse> Update(int id, ClienteRequest request)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return null;

            UpdateEntity(cliente, request);
            await _clienteRepository.UpdateAsync(cliente);
            await _clienteRepository.SaveChangesAsync();

            return MapToResponse(cliente);
        }

        public async Task<List<ClienteResponse>> UpdateMultiple(Dictionary<int, ClienteRequest> requests)
        {
            var clientes = await _clienteRepository.GetAllAsync();
            var updatedClientes = new List<Cliente>();

            foreach (var request in requests)
            {
                var cliente = clientes.FirstOrDefault(c => c.Id == request.Key);
                if (cliente != null)
                {
                    UpdateEntity(cliente, request.Value);
                    updatedClientes.Add(cliente);
                }
            }

            await _clienteRepository.SaveChangesAsync();
            return updatedClientes.Select(MapToResponse).ToList();
        }

        public async Task<int> DeleteById(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return 0;

            await _clienteRepository.DeleteAsync(cliente);
            await _clienteRepository.SaveChangesAsync();
            return 1;
        }

        public async Task<int> DeleteMultiple(List<int> ids)
        {
            var clientes = await _clienteRepository.FindAsync(c => ids.Contains(c.Id));
            await _clienteRepository.DeleteRangeAsync(clientes);
            await _clienteRepository.SaveChangesAsync();
            return clientes.Count;
        }

        // 🔹 Métodos auxiliares para mapeo

        private Cliente MapToEntity(ClienteRequest request)
        {
            return new Cliente
            {
                Nombres = request.Nombres,
                ApellidoPaterno = request.ApellidoPaterno,
                ApellidoMaterno = request.ApellidoMaterno,
                DNI = request.DNI,
                RUC = request.RUC,
                TelefonoMovil = request.TelefonoMovil,
                CorreoElectronico = request.CorreoElectronico,
                Direccion = request.Direccion,
                ContraseñaHash = BCrypt.Net.BCrypt.HashPassword(request.Contraseña) // ✅ Encriptar la contraseña antes de guardar
            };
        }

        private ClienteResponse MapToResponse(Cliente cliente)
        {
            return new ClienteResponse
            {
                Id = cliente.Id,
                Nombres = cliente.Nombres,
                ApellidoPaterno = cliente.ApellidoPaterno,
                ApellidoMaterno = cliente.ApellidoMaterno,
                DNI = cliente.DNI,
                RUC = cliente.RUC,
                TelefonoMovil = cliente.TelefonoMovil,
                CorreoElectronico = cliente.CorreoElectronico,
                Direccion = cliente.Direccion,

                // 🔹 No devolvemos la contraseña por seguridad
            };
        }

        private void UpdateEntity(Cliente cliente, ClienteRequest request)
        {
            cliente.Nombres = request.Nombres;
            cliente.ApellidoPaterno = request.ApellidoPaterno;
            cliente.ApellidoMaterno = request.ApellidoMaterno;
            cliente.DNI = request.DNI;
            cliente.RUC = request.RUC;
            cliente.TelefonoMovil = request.TelefonoMovil;
            cliente.CorreoElectronico = request.CorreoElectronico;
            cliente.Direccion = request.Direccion;

            if (!string.IsNullOrEmpty(request.Contraseña))
            {
                cliente.ContraseñaHash = BCrypt.Net.BCrypt.HashPassword(request.Contraseña); // ✅ Encriptar solo si hay una nueva contraseña
            }
        }
    }
}
