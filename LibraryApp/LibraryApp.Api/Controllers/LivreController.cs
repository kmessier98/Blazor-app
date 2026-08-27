using LibraryApp.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAll()
        {
             await _livreService.GetAll();
            return Ok();
        }
    }
}
