using LibraryApp.Application.Interfaces;
using LibraryApp.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpruntsController : ControllerBase
    {
        private readonly IEmpruntService _empruntService;

        public EmpruntsController(IEmpruntService empruntService)
        {
            _empruntService = empruntService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpruntDto>> Get(int id)
        {
            var dto = await _empruntService.Get(id);
            return Ok(dto);
        }

        [HttpGet("GetAllActive")]
        public async Task<ActionResult<List<EmpruntDto>>> GetAllActive()
        {
            var emprunts = await _empruntService.GetAllActiveAsync();
            return Ok(emprunts);
        }

        [HttpPost]
        public async Task<ActionResult<EmpruntDto>> EmprunterExemplaire(CreerEmpruntDto dto)
        {
            var result = await _empruntService.EmprunterExemplaire(dto.ExemplaireId, dto.MembreId);

            return CreatedAtAction(
                nameof(Get),
                new { id = result.Id },
                result);

        }

        [HttpPut("{empruntId}/retour")]
        public async Task<ActionResult> RetournerExemplaire([FromRoute] int empruntId)
        {

            await _empruntService.RetournerExemplaire(empruntId);
            return NoContent();
        }
    }
}
