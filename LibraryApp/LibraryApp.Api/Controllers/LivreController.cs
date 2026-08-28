using LibraryApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static LibraryApp.Shared.DTOs.LivreDTO;

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
    }
}
