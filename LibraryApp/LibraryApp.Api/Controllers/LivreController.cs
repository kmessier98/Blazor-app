using LibraryApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivreController : ControllerBase
    {
        private ILivreService _livreService;
        public LivreController(ILivreService livreService)
        {
            _livreService = livreService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<GetAllLivresDto>> GetAll()
        {
            try
            {
                var livres = await _livreService.GetAll();

                return Ok(livres);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Une erreur interne est survenue sur le serveur." });
            }
        }

        [HttpGet("GetLivreInfos/{livreId}")]
        public async Task<ActionResult<GetLivreInfosDto>> GetLivreInfos([FromRoute] int livreId)
        {
            try
            {
                var livreInfos = await _livreService.GetLivreInfos(livreId);

                return Ok(livreInfos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Une erreur interne est survenue sur le serveur." });
            }
        }

        [HttpPut("{livreId}/user/{userId}/emprunt")]
        public async Task<ActionResult> EmprunterLivre([FromRoute] int livreId, [FromRoute] int userId)
        {
            try
            {
                await _livreService.EmprunterLivre(livreId, userId);
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
