using LibraryApp.Application.Interfaces;
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
        public async Task<ActionResult> GetAllActive()
        {
            await _empruntService.GetAllActiveAsync();

            return Ok();
        }
    }
}
