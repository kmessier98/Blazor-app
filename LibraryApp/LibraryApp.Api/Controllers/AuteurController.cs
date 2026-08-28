using LibraryApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult> GetAuteurInfos([FromRoute] int auteurId)
        {
            await _auteurService.GetAuteurInfos(auteurId);
            return null;
        }
    }
}
