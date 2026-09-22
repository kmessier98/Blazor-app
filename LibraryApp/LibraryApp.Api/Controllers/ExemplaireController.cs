using LibraryApp.Application.Interfaces;
using LibraryApp.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExemplaireController : ControllerBase
    {
        private readonly IExemplaireService _exemplaireService;

        public ExemplaireController(IExemplaireService exemplaireService)
        {
            _exemplaireService = exemplaireService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExemplaireDto>> Get([FromRoute] int id)
        {
            var dto = await _exemplaireService.Get(id);
            return Ok(dto);
        }

        [HttpPost("Emprunts")]
        public async Task<ActionResult<ExemplaireDto>> EmprunterExemplaire(CreerEmpruntDto dto)
        {
            var result = await _exemplaireService.EmprunterExemplaire(dto.ExemplaireId, dto.MembreId);

            return CreatedAtAction(
                nameof(Get),
                new { id = result.Id },
                result);
        }
    }
}
