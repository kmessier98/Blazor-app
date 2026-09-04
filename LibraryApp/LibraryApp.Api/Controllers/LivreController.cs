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
            var livres = await _livreService.GetAll();
            return Ok(livres);
        }

        [HttpGet("GetLivreInfos/{livreId}")]
        public async Task<ActionResult<GetLivreInfosDto>> GetLivreInfos([FromRoute] int livreId)
        {
            var livreInfos = await _livreService.GetLivreInfos(livreId);
            return Ok(livreInfos);
        }

        [HttpPut("{livreId}/membre/{membreId}/emprunt")]
        public async Task<ActionResult> EmprunterLivre([FromRoute] int livreId, [FromRoute] int membreId)
        {
            await _livreService.EmprunterLivre(livreId, membreId);
            return NoContent();
        }

    }
}
