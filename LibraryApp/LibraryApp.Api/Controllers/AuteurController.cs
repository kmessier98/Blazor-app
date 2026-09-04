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
            var auteurInfos = await _auteurService.GetAuteurInfos(auteurId);
            return Ok(auteurInfos);
        }
    }
}
