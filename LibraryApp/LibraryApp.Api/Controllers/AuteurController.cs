using LibraryApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static LibraryApp.Shared.DTOs.AuteurDto;

namespace LibraryApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuteurController : ControllerBase
    {
        private readonly IAuteurService _auteurService;

        public AuteurController(IAuteurService auteurService)
        {
            _auteurService = auteurService;
        }

        [HttpGet("GetAuteurInfos/{auteurId}")]
        public async Task<ActionResult<GetAuteurInfosDto>> GetAuteurInfos([FromRoute] int auteurId)
        {
            try
            {
                var auteurInfos = await _auteurService.GetAuteurInfos(auteurId);

                return Ok(auteurInfos);
            }
            catch (Exception ex) //TODO catch notFoundException....
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Une erreur interne est survenue sur le serveur." });
            }

        }
    }
}
