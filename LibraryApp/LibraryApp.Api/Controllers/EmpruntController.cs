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
            try
            {
                var emprunts = await _empruntService.GetAllActiveAsync();

                return Ok(emprunts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Une erreur interne est survenue sur le serveur." });
            }
        }

        [HttpPut("{empruntId}/user/{userId}/retour")]
        public async Task<ActionResult> RetournerLivre([FromRoute] int empruntId, [FromRoute] int userId)
        {
            try
            {
                await _empruntService.RetournerLivre(empruntId, userId);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Une erreur interne est survenue sur le serveur." });
            }

            return NoContent();
        }
    }
}
