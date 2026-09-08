using LibraryApp.Application.Interfaces;
using LibraryApp.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembreController : ControllerBase
    {
        private readonly IMembreService _utilisateurService;

        public MembreController(IMembreService utilisateurService)
        {
            _utilisateurService = utilisateurService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<MembreDto>> GetAll()
        {
            var dto = await _utilisateurService.GetAll();
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<MembreDto>> Create(CreateMembreDto dto)
        {
            var result = await _utilisateurService.Create(dto);

            return Ok(result); //TODO createdAtAction

            /*
            return CreatedAtAction(
                nameof(GetById),           
                new { id = membreCree.Id },
                membreCree                 
)           ; */
        }
    }
}
