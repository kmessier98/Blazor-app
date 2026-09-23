using LibraryApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static LibraryApp.Shared.DTOs.LivreDto;

namespace LibraryApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivresController : ControllerBase
    {
        private ILivreService _livreService;
        public LivresController(ILivreService livreService)
        {
            _livreService = livreService;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllLivresDto>> GetAll()
        {
            var livres = await _livreService.GetAll();
            return Ok(livres);
        }

        [HttpGet("GetLivreInfos/{livreId}")]
        public async Task<ActionResult<GetLivreInfosDto>> GetLivreInfos([FromRoute] int livreId)
        {
            var livreInfos = await _livreService.GetLivreInfos(livreId);
            return Ok(livreInfos);
        }
    }
}
