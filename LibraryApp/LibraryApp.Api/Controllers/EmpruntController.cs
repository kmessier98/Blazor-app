using LibraryApp.Application.Interfaces;
using LibraryApp.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpruntController : ControllerBase
    {
        private readonly IEmpruntService _empruntService;

        public EmpruntController(IEmpruntService empruntService)
        {
            _empruntService = empruntService;
        }

        [HttpGet("GetAllActive")]
        public async Task<ActionResult<List<EmpruntDto>>> GetAllActive()
        {
            var emprunts = await _empruntService.GetAllActiveAsync();
            return Ok(emprunts);
        }

        [HttpPut("{empruntId}/membre/{membreId}/retour")]
        public async Task<ActionResult> RetournerLivre([FromRoute] int empruntId, [FromRoute] int membreId)
        {

            await _empruntService.RetournerLivre(empruntId, membreId);
            return NoContent();
        }
    }
}
