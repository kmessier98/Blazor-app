using LibraryApp.Application.Interfaces;
using LibraryApp.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MembreDto>> Get(int id)
        {
            var dto = await _reservationService.Get(id);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<MembreDto>> Create(CreateReservationDto dto)
        {
            var result = await _reservationService.Create(dto);

            return CreatedAtAction(
                nameof(Get),
                new { id = result.Id },
                result);
        }

        [HttpPatch("{id}/annuler")]
        public async Task<ActionResult> Cancel([FromRoute] int id)
        {
            await _reservationService.Cancel(id);
            return NoContent();
        }
    }
}
