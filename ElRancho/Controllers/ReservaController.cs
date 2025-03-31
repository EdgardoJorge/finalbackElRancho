using IBusiness;
using Microsoft.AspNetCore.Mvc;
using Model.Request;
using Model.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaBusiness _reservaBusiness;

        public ReservaController(IReservaBusiness reservaBusiness)
        {
            _reservaBusiness = reservaBusiness;
        }

        // GET: api/reservas
        [HttpGet]
        public async Task<ActionResult<List<ReservaResponse>>> GetAll()
        {
            var reservas = await _reservaBusiness.GetAll();
            return Ok(reservas);
        }

        // GET: api/reservas/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaResponse>> GetById(int id)
        {
            var reserva = await _reservaBusiness.GetById(id);
            if (reserva == null) return NotFound(new { mensaje = "Reserva no encontrada" });
            return Ok(reserva);
        }

        // POST: api/reservas
        [HttpPost]
        public async Task<ActionResult<ReservaResponse>> Create([FromBody] ReservaRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var reserva = await _reservaBusiness.Create(request);
            return CreatedAtAction(nameof(GetById), new { id = reserva.Id }, reserva);
        }

        // PUT: api/reservas/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ReservaResponse>> Update(int id, [FromBody] ReservaRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedReserva = await _reservaBusiness.Update(id, request);
            if (updatedReserva == null) return NotFound(new { mensaje = "Reserva no encontrada" });

            return Ok(updatedReserva);
        }

        // DELETE: api/reservas/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _reservaBusiness.DeleteById(id);
            if (result == 0) return NotFound(new { mensaje = "Reserva no encontrada" });

            return NoContent();
        }

        // DELETE: api/reservas/delete-multiple
        [HttpPost("delete-multiple")]
        public async Task<ActionResult> DeleteMultiple([FromBody] List<int> ids)
        {
            var deletedCount = await _reservaBusiness.DeleteMultiple(ids);
            if (deletedCount == 0) return NotFound(new { mensaje = "No se encontraron reservas para eliminar" });

            return Ok(new { mensaje = $"{deletedCount} reservas eliminadas" });
        }

        // POST: api/reservas/create-multiple
        [HttpPost("create-multiple")]
        public async Task<ActionResult<List<ReservaResponse>>> CreateMultiple([FromBody] List<ReservaRequest> requests)
        {
            var reservas = await _reservaBusiness.CreateMultiple(requests);
            return Ok(reservas);
        }

        // PUT: api/reservas/update-multiple
        [HttpPut("update-multiple")]
        public async Task<ActionResult<List<ReservaResponse>>> UpdateMultiple([FromBody] Dictionary<int, ReservaRequest> requests)
        {
            var updatedReservas = await _reservaBusiness.UpdateMultiple(requests);
            return Ok(updatedReservas);
        }

        // GET: api/reservas/cliente/{clienteId}
        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<List<ReservaResponse>>> GetByClienteId(int clienteId)
        {
            var reservas = await _reservaBusiness.GetByClienteId(clienteId);
            return Ok(reservas);
        }

        // GET: api/reservas/rango-fechas?inicio=YYYY-MM-DD&fin=YYYY-MM-DD
        [HttpGet("rango-fechas")]
        public async Task<ActionResult<List<ReservaResponse>>> GetByDateRange([FromQuery] DateTime inicio, [FromQuery] DateTime fin)
        {
            var reservas = await _reservaBusiness.GetByDateRange(inicio, fin);
            return Ok(reservas);
        }

        // POST: api/reservas/{id}/confirmar
        [HttpPost("{id}/confirmar")]
        public async Task<ActionResult> ConfirmarReserva(int id)
        {
            var resultado = await _reservaBusiness.ConfirmReservation(id);
            if (!resultado) return NotFound(new { mensaje = "Reserva no encontrada o ya confirmada" });

            return Ok(new { mensaje = "Reserva confirmada con éxito" });
        }

        // POST: api/reservas/{id}/cancelar
        [HttpPost("{id}/cancelar")]
        public async Task<ActionResult> CancelarReserva(int id)
        {
            var resultado = await _reservaBusiness.CancelReservation(id);
            if (!resultado) return NotFound(new { mensaje = "Reserva no encontrada o ya cancelada" });

            return Ok(new { mensaje = "Reserva cancelada con éxito" });
        }
    }
}
