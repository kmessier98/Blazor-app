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

        [HttpGet("GetAllActive")]
        public async Task<ActionResult<List<EmpruntDto>>> GetAllActive()
        {
            var emprunts = await _empruntService.GetAllActiveAsync();
            return Ok(emprunts);
        }

        [HttpPut("{empruntId}/retour")]
        public async Task<ActionResult> RetournerExemplaire([FromRoute] int empruntId)
        {

            await _empruntService.RetournerExemplaire(empruntId);
            return NoContent();
        }
    }
}
